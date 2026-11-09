import { router } from 'expo-router';
import { useEffect, useState } from 'react';
import { View } from 'react-native';

import { guardarAjuste, leerAjustes } from '@/datos/repositorio';
import { crearPartida, MAX_MCS, MIN_MCS } from '@/dominio/juego/turnos';
import { useSesion } from '@/estado/Sesion';
import { Boton, BotonIcono, Cabecera, Campo, Chips, Pantalla, T } from '@/ui/componentes';
import { FormularioRonda } from '@/ui/ConfigRonda';
import { espacio, paleta } from '@/ui/tema';

const rondas = [1, 2, 3, 5];
const intervalos = [10_000, 20_000, 30_000, 60_000];

export default function Turnos() {
  const { nuevaSesion, setPartida } = useSesion();
  const [nombres, setNombres] = useState<string[]>(['', '']);
  const [totalRondas, setTotalRondas] = useState(1);
  const [intervaloMs, setIntervaloMs] = useState<number | null>(null);

  useEffect(() => {
    leerAjustes().then((f) => {
      try {
        const guardado = JSON.parse(f.ultimosMcs ?? 'null') as { nombres: string[]; rondas: number; intervaloMs?: number | null } | null;
        if (guardado?.nombres?.length) setNombres(guardado.nombres.slice(0, MAX_MCS));
        if (guardado?.rondas) setTotalRondas(guardado.rondas);
        if (guardado?.intervaloMs) setIntervaloMs(guardado.intervaloMs);
      } catch {}
    });
  }, []);

  const cambiar = (i: number, texto: string) => setNombres((ns) => ns.map((n, j) => (j === i ? texto : n)));
  const quitar = (i: number) => setNombres((ns) => ns.filter((_, j) => j !== i));

  const empezar = () => {
    const mcs = nombres.map((n, i) => ({ id: String(i + 1), nombre: n.trim() || `MC ${i + 1}` }));
    guardarAjuste('ultimosMcs', JSON.stringify({ nombres: nombres.map((n) => n.trim()), rondas: totalRondas, intervaloMs }));
    nuevaSesion();
    setPartida(intervaloMs ? crearPartida(mcs, 1, intervaloMs) : crearPartida(mcs, totalRondas));
    router.push('/pase');
  };

  return (
    <Pantalla pie={<Boton texto="Empezar la batalla" icono="microphone-stage" onPress={empezar} />}>
      <Cabecera titulo="Por turnos" onAtras={() => router.back()} />

      <View style={{ gap: espacio.s }}>
        <T v="meta">MCS</T>
        {nombres.map((n, i) => (
          <View key={i} style={{ flexDirection: 'row', alignItems: 'flex-end', gap: espacio.s }}>
            <View style={{ flex: 1 }}>
              <Campo etiqueta={`MC ${i + 1}`} value={n} onChangeText={(t) => cambiar(i, t)} placeholder={`MC ${i + 1}`} maxLength={24} autoCapitalize="words" returnKeyType="next" />
            </View>
            {nombres.length > MIN_MCS && <BotonIcono icono="x" etiqueta={`Quitar a MC ${i + 1}`} onPress={() => quitar(i)} color={paleta.tenue} />}
          </View>
        ))}
        {nombres.length < MAX_MCS && (
          <Boton texto="Añadir MC" icono="plus" tipo="secundario" onPress={() => setNombres((ns) => [...ns, ''])} />
        )}
      </View>

      <View style={{ gap: espacio.s }}>
        <T v="meta">CÓMO OS TURNÁIS</T>
        <Chips
          opciones={[
            { valor: 'uno', texto: 'Uno a uno' },
            { valor: 'alternando', texto: 'Alternando' },
          ]}
          valor={intervaloMs ? 'alternando' : 'uno'}
          onCambio={(v) => setIntervaloMs(v === 'alternando' ? 20_000 : null)}
        />
        <T v="ayuda">
          {intervaloMs
            ? 'Una sola batalla seguida, con un reloj y el beat sin parar: cada cierto tiempo os pasáis el móvil. Al acabar votáis; si hay empate, réplica.'
            : 'Cada MC tiene su turno y su reloj. Al acabar cada ronda votáis quién ha ganado; si hay empate, réplica.'}
        </T>
      </View>

      {intervaloMs ? (
        <View style={{ gap: espacio.s }}>
          <T v="meta">CAMBIO DE MC CADA</T>
          <Chips
            opciones={intervalos.map((ms) => ({ valor: ms, texto: ms === 60_000 ? '1 min' : `${ms / 1000} s` }))}
            valor={intervaloMs}
            onCambio={setIntervaloMs}
          />
        </View>
      ) : (
        <View style={{ gap: espacio.s }}>
          <T v="meta">RONDAS</T>
          <Chips opciones={rondas.map((r) => ({ valor: r, texto: String(r) }))} valor={totalRondas} onCambio={setTotalRondas} />
        </View>
      )}

      <FormularioRonda duracionTitulo={intervaloMs ? 'Duración de la batalla' : 'Duración de cada turno'} />
    </Pantalla>
  );
}
