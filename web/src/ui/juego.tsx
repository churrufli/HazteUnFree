import { useEffect } from 'react';
import { Pressable, StyleSheet, View } from 'react-native';
import Animated, {
  cancelAnimation,
  Easing,
  FadeInDown,
  useAnimatedStyle,
  useReducedMotion,
  useSharedValue,
  withRepeat,
  withDelay,
  withSequence,
  withTiming,
  ZoomIn,
} from 'react-native-reanimated';

import { formatoReloj } from '@/dominio/juego/reloj';
import { buscarEnGoogle } from '@/lib/navegador';
import { Fila, Separador, T, Tarjeta } from './componentes';
import { espacio, familia, fuente, paleta } from './tema';

function Onda({ tam, retraso, color }: { tam: number; retraso: number; color: string }) {
  const t = useSharedValue(0);
  useEffect(() => {
    t.value = withDelay(retraso, withRepeat(withTiming(1, { duration: 1800, easing: Easing.out(Easing.quad) }), -1));
    return () => cancelAnimation(t);
  }, [t, retraso]);
  const estilo = useAnimatedStyle(() => ({
    opacity: 0.55 * (1 - t.value),
    transform: [{ scale: 1 + t.value * 0.45 }],
  }));
  return (
    <Animated.View
      pointerEvents="none"
      style={[StyleSheet.absoluteFill, { borderRadius: tam / 2, borderWidth: 3, borderColor: color }, estilo]}
    />
  );
}

function Ondas({ tam, color }: { tam: number; color: string }) {
  return (
    <View
      pointerEvents="none"
      style={[StyleSheet.absoluteFill]}
      accessibilityElementsHidden
      importantForAccessibility="no-hide-descendants"
    >
      {[0, 600, 1200].map((r) => (
        <Onda key={r} tam={tam} retraso={r} color={color} />
      ))}
    </View>
  );
}

export function RelojMedallon({ restanteMs, tam = 200, ondas = false }: { restanteMs: number; tam?: number; ondas?: boolean }) {
  const reducir = useReducedMotion();
  const final = restanteMs > 0 && restanteMs <= 10_000;
  const escala = useSharedValue(1);
  useEffect(() => {
    escala.value =
      final && !reducir
        ? withRepeat(withSequence(withTiming(1.05, { duration: 150 }), withTiming(1, { duration: 350 })), -1)
        : withTiming(1);
  }, [final, reducir, escala]);
  const animado = useAnimatedStyle(() => ({
    transform: [{ scale: escala.value }],
  }));
  const texto = formatoReloj(restanteMs);
  const color = final ? paleta.peligro : paleta.acento;
  return (
    <View style={{ width: tam, height: tam, alignSelf: 'center' }}>
      {ondas && !reducir && <Ondas tam={tam} color={color} />}
      <Animated.View
        style={[
          estilos.medallon,
          {
            width: tam,
            height: tam,
            borderRadius: tam / 2,
            borderWidth: tam * 0.06,
            borderColor: color,
          },
          animado,
        ]}
        accessibilityRole="timer"
        accessibilityLabel={`Quedan ${texto}`}
        accessibilityLiveRegion="polite"
      >
        <T
          v="display"
          style={{
            color: paleta.tinta,
            fontSize: tam * (texto.length > 2 ? 0.28 : 0.38),
            lineHeight: tam * 0.6,
          }}
          maxFontSizeMultiplier={1}
        >
          {texto}
        </T>
      </Animated.View>
    </View>
  );
}

export function BandaPalabra({ palabras, vacio, onPress }: { palabras: string[]; vacio: string; onPress?: () => void }) {
  const reducir = useReducedMotion();
  const clave = palabras.join('|') || vacio;
  const cuatro = palabras.length > 1;
  const contenido = (
    <View style={estilos.banda}>
      <Animated.View
        key={clave}
        entering={reducir ? undefined : cuatro ? FadeInDown.duration(220) : ZoomIn.duration(220)}
      >
        {palabras.length === 0 ? (
          <T v="display" style={[estilos.palabra, { fontSize: fuente.display + 2, color: paleta.borde }]} numberOfLines={2}>
            {vacio}
          </T>
        ) : cuatro ? (
          <View style={estilos.rejilla}>
            {palabras.map((p) => (
              <T key={p} v="display" style={[estilos.palabra, estilos.celda]} numberOfLines={1} adjustsFontSizeToFit minimumFontScale={0.5}>
                {p.toLocaleUpperCase('es')}
              </T>
            ))}
          </View>
        ) : (
          <T
            v="display"
            style={estilos.palabra}
            numberOfLines={1}
            adjustsFontSizeToFit
            minimumFontScale={0.4}
            accessibilityLiveRegion="assertive"
          >
            {palabras[0]!.toLocaleUpperCase('es')}
          </T>
        )}
      </Animated.View>
    </View>
  );
  if (!onPress) return contenido;
  return (
    <Pressable
      onPress={onPress}
      accessibilityRole="button"
      accessibilityLabel="Sacar palabra"
      style={({ pressed }) => pressed && { opacity: 0.9 }}
    >
      {contenido}
    </Pressable>
  );
}

const estilos = StyleSheet.create({
  medallon: {
    backgroundColor: paleta.banda,
    alignItems: 'center',
    justifyContent: 'center',
    alignSelf: 'center',
  },
  banda: {
    backgroundColor: paleta.banda,
    minHeight: 150,
    justifyContent: 'center',
    marginHorizontal: -espacio.margen,
    paddingHorizontal: espacio.xl,
    paddingVertical: espacio.l,
    borderBottomWidth: 6,
    borderBottomColor: paleta.acento,
  },
  palabra: {
    color: paleta.tinta,
    textAlign: 'center',
    fontFamily: familia.display,
    fontSize: fuente.palabra,
  },
  rejilla: { flexDirection: 'row', flexWrap: 'wrap' },
  celda: {
    width: '50%',
    fontSize: fuente.palabra * 0.6,
    paddingVertical: espacio.xs,
  },
});

export function ListaPalabras({ palabras }: { palabras: string[] }) {
  return (
    <Tarjeta estilo={{ paddingVertical: espacio.xs }}>
      {palabras.map((p, i) => (
        <View key={`${p}-${i}`}>
          {i > 0 && <Separador />}
          <Fila titulo={p} detalle="Buscar en Google" icono="magnifying-glass" onPress={() => buscarEnGoogle(p)} />
        </View>
      ))}
    </Tarjeta>
  );
}
