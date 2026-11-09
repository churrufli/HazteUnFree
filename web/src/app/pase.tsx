import { Redirect, router } from 'expo-router';
import { StyleSheet, View } from 'react-native';

import { siguienteMc, turnoActual } from '@/dominio/juego/turnos';
import { useSesion } from '@/estado/Sesion';
import { Boton, BotonIcono, Pantalla, T } from '@/ui/componentes';
import { useConfirm } from '@/ui/Dialogo';
import { Icono } from '@/ui/Icono';
import { espacio, paleta } from '@/ui/tema';

export default function Pase() {
  const { partida } = useSesion();
  const confirmar = useConfirm();
  if (!partida) return <Redirect href="/inicio" />;
  const mc = turnoActual(partida);
  if (!mc) return <Redirect href="/votacion" />;
  const despues = siguienteMc(partida);

  const etiqueta = partida.desempate
    ? 'DESEMPATE'
    : partida.replica
      ? `RÉPLICA DE LA RONDA ${partida.ronda}`
      : `RONDA ${partida.ronda} DE ${partida.rondasTotales}`;

  const abandonar = async () => {
    const ok = await confirmar({ title: '¿Abandonar la batalla?', message: 'Se pierde el marcador de esta partida.', confirmar: 'Abandonar', peligro: true });
    if (ok) router.back();
  };

  return (
    <Pantalla
      decoracion
      scroll={false}
      pie={<Boton texto={`Soy ${mc.nombre}, vamos`} icono="microphone-stage" onPress={() => router.replace({ pathname: '/ronda', params: { modo: 'turnos' } })} />}
    >
      <View style={estilos.cabecera}>
        <T v="meta" style={{ flex: 1, color: paleta.dorado }}>
          {etiqueta}
        </T>
        <BotonIcono icono="x" etiqueta="Abandonar la batalla" onPress={abandonar} />
      </View>
      <View style={estilos.centro}>
        <Icono nombre="hand-pointing" tam={56} color={paleta.acentoFuerte} />
        <T v="meta">{partida.intervaloMs ? 'EMPIEZA' : 'PÁSALE EL MÓVIL A'}</T>
        <T v="display" style={{ textAlign: 'center' }} numberOfLines={2} adjustsFontSizeToFit>
          {mc.nombre.toLocaleUpperCase('es')}
        </T>
        {despues && <T v="ayuda">Después va {despues.nombre}</T>}
      </View>
    </Pantalla>
  );
}

const estilos = StyleSheet.create({
  cabecera: { flexDirection: 'row', alignItems: 'center', minHeight: espacio.toque },
  centro: { flex: 1, alignItems: 'center', justifyContent: 'center', gap: espacio.m },
});
