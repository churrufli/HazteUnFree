import { activateKeepAwakeAsync, deactivateKeepAwake } from 'expo-keep-awake';
import { router, useLocalSearchParams } from 'expo-router';
import { useCallback, useEffect, useRef } from 'react';
import { BackHandler, StyleSheet, Vibration, View } from 'react-native';

import { infoFormato } from '@/dominio/juego/formatos';
import { mcAlternando, terminarTurno, turnoActual } from '@/dominio/juego/turnos';
import { useAjustes } from '@/estado/Ajustes';
import { useSesion } from '@/estado/Sesion';
import { useBocina } from '@/lib/bocina';
import { useRonda } from '@/lib/useRonda';
import { Barra, Boton, BotonIcono, Pantalla, T } from '@/ui/componentes';
import { useConfirm } from '@/ui/Dialogo';
import { BandaPalabra, RelojMedallon } from '@/ui/juego';
import { espacio, fuente as tamFuente, paleta } from '@/ui/tema';

export default function Ronda() {
  const { modo } = useLocalSearchParams<{ modo?: string }>();
  const turnos = modo === 'turnos';
  const { ajustes } = useAjustes();
  const { config, sacarPalabras, partida, setPartida, jugadas, apuntarJugada } = useSesion();
  const confirmar = useConfirm();
  const bocina = useBocina();
  const alternando = turnos && !!partida?.intervaloMs;
  const porMc = useRef<Record<string, string[]>>({});

  const alAcabar = useCallback(
    (usadas: string[]) => {
      if (ajustes.bocinaFinal) bocina();
      const enTurno = turnos && partida ? turnoActual(partida) : null;
      if (partida && enTurno) {
        if (alternando) partida.cola.forEach((id) => apuntarJugada({ mcId: id, ronda: partida.ronda, palabras: porMc.current[id] ?? [] }));
        else apuntarJugada({ mcId: enTurno.id, ronda: partida.ronda, palabras: usadas });
        const siguiente = terminarTurno(partida);
        setPartida(siguiente);
        router.replace(siguiente.fase === 'votacion' ? '/votacion' : '/pase');
        return;
      }
      apuntarJugada({
        mcId: null,
        ronda: jugadas.length + 1,
        palabras: usadas,
      });
      router.replace('/resultado');
    },
    [ajustes.bocinaFinal, bocina, turnos, alternando, partida, apuntarJugada, setPartida, jugadas.length],
  );

  const r = useRonda({ config, sacarPalabras, onFin: alAcabar });
  const { fase } = r;
  const enJuego = fase === 'jugando' || fase === 'pausa';
  const transcurridoMs = config.duracionMs - r.restanteMs;
  const mc = turnos && partida ? (alternando ? mcAlternando(partida, transcurridoMs) : turnoActual(partida)) : null;

  // En «Alternando» el aviso sale con la última palabra del MC, antes de que cambie el turno.
  const intervaloMs = partida?.intervaloMs ?? 0;
  const hastaCambio = intervaloMs - (transcurridoMs % (intervaloMs || 1));
  const ultimaPalabra = r.siguienteEnMs === null ? hastaCambio <= 3000 : r.tanda.length > 0 && r.siguienteEnMs >= hastaCambio;
  const siguiente =
    alternando && partida && enJuego && transcurridoMs + hastaCambio < config.duracionMs && ultimaPalabra
      ? mcAlternando(partida, transcurridoMs + hastaCambio)
      : null;
  const aviso = siguiente?.nombre ?? null;
  const mcId = mc?.id;
  useEffect(() => {
    if (aviso) Vibration.vibrate(400);
  }, [aviso]);

  const { tanda } = r;
  useEffect(() => {
    if (!alternando || !mcId || tanda.length === 0) return;
    porMc.current[mcId] = [...(porMc.current[mcId] ?? []), ...tanda];
    // Las palabras son del MC al que le tocaba cuando salieron.
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [alternando, tanda]);

  useEffect(() => {
    if (!ajustes.pantallaEncendida) return;
    activateKeepAwakeAsync('ronda');
    return () => {
      deactivateKeepAwake('ronda');
    };
  }, [ajustes.pantallaEncendida]);

  const empezar = r.empezar;
  const pausar = r.pausar;
  const reanudar = r.reanudar;

  const parar = useCallback(async () => {
    const estabaJugando = fase === 'jugando';
    if (estabaJugando) r.pausar();
    const ok = await confirmar({
      title: turnos && !alternando ? '¿Terminar este turno?' : '¿Terminar la ronda?',
      message: 'Se guardan las palabras que han salido hasta ahora.',
      confirmar: 'Terminar',
      icon: 'stop',
    });
    if (ok) r.terminar();
    else if (estabaJugando) r.reanudar();
  }, [fase, r, confirmar, turnos, alternando]);

  useEffect(() => {
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      if (!enJuego) return false;
      parar();
      return true;
    });
    return () => sub.remove();
  }, [enJuego, parar]);

  const libre = config.formato === 'libre';
  const manual = config.disparo === 'manual';
  const { nombre, descripcion } = infoFormato(config.formato);

  const preparando = fase === 'preparando';
  const vacio = preparando
    ? '¿LISTOS?'
    : libre
      ? 'MINUTO LIBRE'
      : manual
        ? 'TOCA PARA SACAR PALABRA'
        : '';

  return (
    <Pantalla
      scroll={preparando}
      decoracion
      pie={
        preparando ? (
          <>
            <Boton texto="Empezar la batalla" icono="play" onPress={empezar} />
          </>
        ) : (
          <View style={estilos.controles}>
            {fase === 'pausa' ? (
              <Boton texto="Seguir" icono="play" onPress={reanudar} estilo={{ flex: 1 }} />
            ) : (
              <Boton texto="Pausa" icono="pause" tipo="secundario" onPress={pausar} estilo={{ flex: 1 }} />
            )}
            <Boton texto="Terminar" icono="stop" tipo="peligro" onPress={parar} estilo={{ flex: 1 }} />
          </View>
        )
      }
    >
      <View style={estilos.cabecera}>
        {preparando && <BotonIcono icono="arrow-left" etiqueta="Atrás" onPress={() => router.back()} />}
        <T v="meta" style={{ flex: 1 }}>
          {(turnos && partida ? `RONDA ${partida.ronda}${partida.replica ? ' · RÉPLICA' : ''} · ` : '') +
            (mc ? `${mc.nombre} · ` : '') +
            `${nombre} · ${manual && !libre ? 'toca la banda para sacar palabra' : descripcion}`.toUpperCase()}
        </T>
        {fase === 'pausa' && (
          <T v="meta" style={{ color: paleta.dorado }}>
            EN PAUSA
          </T>
        )}
      </View>

      <View style={[estilos.juego, preparando && { justifyContent: 'flex-start' }]}>
        {(preparando || alternando) && mc && (
          <T v="titulo" style={{ textAlign: 'center' }}>
            Le toca a {mc.nombre}
          </T>
        )}
        <RelojMedallon
          restanteMs={r.restanteMs}
          tam={preparando ? 160 : 200}
          ondas={fase === 'jugando' && config.musica !== 'acapella'}
        />
        <BandaPalabra palabras={r.tanda} vacio={vacio} onPress={manual && fase === 'jugando' ? r.palabraManual : undefined} />
        {preparando ? (
          <T v="ayuda" style={estilos.modo}>
            {libre || manual
              ? 'Pulsa «Empezar la batalla»: arranca el reloj.'
              : 'Pulsa «Empezar la batalla»: arrancan a la vez el reloj y las palabras.'}
          </T>
        ) : aviso ? (
          <View style={estilos.aviso} accessibilityLiveRegion="assertive">
            <T v="display" style={estilos.textoAviso} numberOfLines={1} adjustsFontSizeToFit>
              PASA EL MÓVIL A {aviso.toLocaleUpperCase('es')}
            </T>
          </View>
        ) : r.progresoSiguiente !== null && r.siguienteEnMs !== null && fase === 'jugando' ? (
          <View style={{ gap: espacio.xs }}>
            <Barra progreso={r.progresoSiguiente} />
            <T v="meta" style={{ textAlign: 'center' }}>
              SIGUIENTE PALABRA EN {Math.ceil(r.siguienteEnMs / 1000)} S
            </T>
          </View>
        ) : (
          <View style={{ height: 8 }} />
        )}
        {preparando && (
          <T v="ayuda" style={estilos.modo}>
            {config.musica === 'acapella'
              ? 'A capella.'
              : 'Pon el beat donde quieras (otra pestaña, Spotify, un altavoz…) y pulsa «Empezar la batalla».'}
          </T>
        )}
      </View>
    </Pantalla>
  );
}

const estilos = StyleSheet.create({
  cabecera: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: espacio.s,
    minHeight: espacio.toque,
  },
  juego: { flex: 1, justifyContent: 'space-evenly', gap: espacio.l },
  controles: { flexDirection: 'row', alignItems: 'center', gap: espacio.s },
  modo: { textAlign: 'center' },
  aviso: { backgroundColor: paleta.acento, borderRadius: 8, paddingVertical: espacio.s, paddingHorizontal: espacio.m },
  textoAviso: { color: paleta.tinta, textAlign: 'center', fontSize: tamFuente.display },
});
