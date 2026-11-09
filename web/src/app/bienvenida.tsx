import { router } from 'expo-router';
import { useState } from 'react';
import { StyleSheet, View } from 'react-native';
import Animated, { FadeInDown, useReducedMotion } from 'react-native-reanimated';

import { useAjustes } from '@/estado/Ajustes';
import { Boton, Logo, Pantalla, T, Tarjeta } from '@/ui/componentes';
import { Icono, type NombreIcono } from '@/ui/Icono';
import { Medallon } from '@/ui/Medallon';
import { espacio, paleta, radio } from '@/ui/tema';

const tarjetas: { icono: NombreIcono; titulo: string; texto: string }[] = [
  {
    icono: 'microphone-stage',
    titulo: 'Entrena tu free',
    texto: 'Te voy soltando palabras al ritmo que elijas y tú las metes en tus barras antes de que salga la siguiente.',
  },
  {
    icono: 'users',
    titulo: 'Solo o por turnos',
    texto: 'Rapea tú solo o pásale el móvil a tu gente. Al final votáis quién se lo ha llevado.',
  },
  {
    icono: 'music-notes',
    titulo: 'La música la pones tú',
    texto: 'En otra pestaña, en Spotify, en un altavoz Bluetooth… donde quieras. Cuando suene el beat, pulsas «Empezar la batalla».',
  },
];

export default function Bienvenida() {
  const { cambiar } = useAjustes();
  const reducir = useReducedMotion();
  const [paso, setPaso] = useState(0);
  const tarjeta = tarjetas[paso]!;
  const ultimo = paso === tarjetas.length - 1;

  const terminar = async () => {
    await cambiar('bienvenidaVista', true);
    router.replace('/inicio');
  };

  return (
    <Pantalla
      decoracion
      scroll={false}
      pie={
        <>
          <Boton texto={ultimo ? '¡Al lío!' : 'Siguiente'} icono={ultimo ? 'fire' : undefined} onPress={ultimo ? terminar : () => setPaso(paso + 1)} />
          {!ultimo && <Boton texto="Saltar" tipo="secundario" onPress={terminar} />}
        </>
      }
    >
      <View style={estilos.centro}>
        <Medallon tam={160} />
        <Logo style={{ textAlign: 'center' }} />
        <Animated.View key={paso} entering={reducir ? undefined : FadeInDown.duration(250)} style={{ width: '100%' }}>
          <Tarjeta estilo={estilos.tarjeta}>
            <View style={estilos.icono}>
              <Icono nombre={tarjeta.icono} tam={32} color={paleta.acentoFuerte} />
            </View>
            <T v="subtitulo" style={{ textAlign: 'center' }}>
              {tarjeta.titulo}
            </T>
            <T v="cuerpo" style={{ textAlign: 'center', color: paleta.textoSecundario }}>
              {tarjeta.texto}
            </T>
          </Tarjeta>
        </Animated.View>
        <View style={estilos.puntos} accessibilityLabel={`Paso ${paso + 1} de ${tarjetas.length}`}>
          {tarjetas.map((t, i) => (
            <View key={t.titulo} style={[estilos.punto, i === paso && estilos.puntoActivo]} />
          ))}
        </View>
      </View>
    </Pantalla>
  );
}

const estilos = StyleSheet.create({
  centro: { flex: 1, alignItems: 'center', justifyContent: 'center', gap: espacio.xl },
  tarjeta: { alignItems: 'center', gap: espacio.m, paddingVertical: espacio.xl },
  icono: {
    width: 64,
    height: 64,
    borderRadius: radio.pildora,
    backgroundColor: paleta.acentoSuave,
    alignItems: 'center',
    justifyContent: 'center',
  },
  puntos: { flexDirection: 'row', gap: espacio.s },
  punto: { width: espacio.s, height: espacio.s, borderRadius: radio.pildora, backgroundColor: paleta.borde },
  puntoActivo: { width: espacio.xl, backgroundColor: paleta.dorado },
});
