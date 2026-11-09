import { useEffect, type ReactNode } from 'react';
import {
  Image,
  Pressable,
  ScrollView,
  StyleSheet,
  Switch,
  Text,
  TextInput,
  View,
  type StyleProp,
  type TextInputProps,
  type TextProps,
  type ViewStyle,
} from 'react-native';
import { SafeAreaView, type Edge } from 'react-native-safe-area-context';
import Animated, { Easing, useAnimatedStyle, useReducedMotion, useSharedValue, withTiming } from 'react-native-reanimated';

import { Icono, type NombreIcono } from './Icono';
import { duracion, espacio, familia, fuente, opacidadDecoracion, paleta, radio } from './tema';

type Variante = 'titulo' | 'subtitulo' | 'cuerpo' | 'negrita' | 'ayuda' | 'boton' | 'display' | 'meta';

const variantes = StyleSheet.create({
  titulo: { fontFamily: familia.display, fontSize: fuente.display + 4, color: paleta.texto, letterSpacing: 0.5 },
  subtitulo: { fontFamily: familia.textoSemi, fontSize: fuente.cabecera, color: paleta.texto },
  cuerpo: { fontFamily: familia.texto, fontSize: fuente.cuerpo, color: paleta.texto, lineHeight: 23 },
  negrita: { fontFamily: familia.textoNegrita, fontSize: fuente.cuerpo, color: paleta.texto },
  ayuda: { fontFamily: familia.texto, fontSize: fuente.pequeña, color: paleta.textoSecundario, lineHeight: 19 },
  boton: { fontFamily: familia.textoNegrita, fontSize: fuente.titulo, color: paleta.texto },
  display: { fontFamily: familia.display, fontSize: fuente.palabra, color: paleta.texto, letterSpacing: 1 },
  meta: { fontFamily: familia.textoSemi, fontSize: fuente.meta, color: paleta.tenue, letterSpacing: 0.6 },
});

const multiplicador: Record<Variante, number> = {
  titulo: 1.3,
  subtitulo: 1.4,
  cuerpo: 1.6,
  negrita: 1.6,
  ayuda: 1.5,
  boton: 1.3,
  display: 1.2,
  meta: 1.5,
};

export function T({ v = 'cuerpo', style, ...resto }: TextProps & { v?: Variante }) {
  const esCabecera = v === 'titulo' || v === 'subtitulo';
  return (
    <Text
      maxFontSizeMultiplier={multiplicador[v]}
      accessibilityRole={esCabecera ? 'header' : undefined}
      style={[variantes[v], style]}
      {...resto}
    />
  );
}

export function Logo({ style }: { style?: TextProps['style'] }) {
  return (
    <T v="titulo" style={style} accessibilityLabel="HazteUnFree">
      Hazte<Text style={{ color: paleta.acento }}>Un</Text>Free
    </T>
  );
}

export function FondoRayas() {
  return (
    <Image
      source={require('../../assets/rayas.png')}
      resizeMode="cover"
      pointerEvents="none"
      accessibilityElementsHidden
      importantForAccessibility="no-hide-descendants"
      style={[StyleSheet.absoluteFill, { opacity: opacidadDecoracion, width: '100%', height: '100%' }]}
    />
  );
}

interface PantallaProps {
  children: ReactNode;
  scroll?: boolean;
  decoracion?: boolean;
  bordes?: Edge[];
  pie?: ReactNode;
}

export function Pantalla({ children, scroll = true, decoracion = false, bordes = ['top', 'bottom'], pie }: PantallaProps) {
  return (
    <SafeAreaView edges={bordes} style={estilos.pantalla}>
      {decoracion && <FondoRayas />}
      {scroll ? (
        <ScrollView contentContainerStyle={estilos.contenido} keyboardShouldPersistTaps="handled">
          {children}
        </ScrollView>
      ) : (
        <View style={[estilos.contenido, { flex: 1 }]}>{children}</View>
      )}
      {pie && <View style={estilos.pie}>{pie}</View>}
    </SafeAreaView>
  );
}

interface CabeceraProps {
  titulo: string;
  onAtras?: () => void;
  derecha?: ReactNode;
}

export function Cabecera({ titulo, onAtras, derecha }: CabeceraProps) {
  return (
    <View style={estilos.cabecera}>
      {onAtras && <BotonIcono icono="arrow-left" etiqueta="Atrás" onPress={onAtras} />}
      <T v="titulo" style={{ flex: 1 }} numberOfLines={1}>
        {titulo}
      </T>
      {derecha}
    </View>
  );
}

type Tipo = 'primario' | 'secundario' | 'peligro';

interface BotonProps {
  texto: string;
  onPress: () => void;
  tipo?: Tipo;
  icono?: NombreIcono;
  desactivado?: boolean;
  estilo?: StyleProp<ViewStyle>;
}

function coloresBoton(tipo: Tipo, desactivado: boolean) {
  if (desactivado) return { fondo: paleta.desactivado, texto: paleta.textoDesactivado, borde: paleta.desactivado };
  if (tipo === 'primario') return { fondo: paleta.acento, texto: paleta.textoSobreAcento, borde: paleta.acento };
  if (tipo === 'peligro') return { fondo: paleta.peligroSuave, texto: paleta.peligro, borde: paleta.peligro };
  return { fondo: paleta.superficie, texto: paleta.texto, borde: paleta.borde };
}

export function Boton({ texto, onPress, tipo = 'primario', icono, desactivado = false, estilo }: BotonProps) {
  const c = coloresBoton(tipo, desactivado);
  return (
    <Pressable
      onPress={onPress}
      disabled={desactivado}
      accessibilityRole="button"
      accessibilityState={{ disabled: desactivado }}
      style={({ pressed }) => [
        estilos.boton,
        { backgroundColor: c.fondo, borderColor: c.borde },
        pressed && estilos.pulsado,
        estilo,
      ]}
    >
      {icono && <Icono nombre={icono} tam={22} color={c.texto} />}
      <T v="boton" style={{ color: c.texto }} numberOfLines={1}>
        {texto}
      </T>
    </Pressable>
  );
}

interface BotonGiganteProps {
  titulo: string;
  subtitulo?: string;
  icono: NombreIcono;
  onPress: () => void;
  tipo?: 'primario' | 'secundario';
}

export function BotonGigante({ titulo, subtitulo, icono, onPress, tipo = 'primario' }: BotonGiganteProps) {
  const primario = tipo === 'primario';
  const colorTexto = primario ? paleta.textoSobreAcento : paleta.texto;
  return (
    <Pressable
      onPress={onPress}
      accessibilityRole="button"
      accessibilityLabel={subtitulo ? `${titulo}. ${subtitulo}` : titulo}
      style={({ pressed }) => [
        estilos.gigante,
        { backgroundColor: primario ? paleta.acento : paleta.superficie, borderColor: primario ? paleta.acento : paleta.borde },
        pressed && estilos.pulsado,
      ]}
    >
      <View style={[estilos.giganteIcono, { backgroundColor: primario ? paleta.banda : paleta.acentoSuave }]}>
        <Icono nombre={icono} tam={30} color={primario ? paleta.tinta : paleta.acentoFuerte} />
      </View>
      <View style={{ flex: 1 }}>
        <T v="titulo" style={{ color: colorTexto }} numberOfLines={1} adjustsFontSizeToFit>
          {titulo}
        </T>
        {subtitulo && (
          <T v="ayuda" style={{ color: primario ? paleta.textoSobreAcento : paleta.textoSecundario }}>
            {subtitulo}
          </T>
        )}
      </View>
      <Icono nombre="caret-right" tam={22} color={colorTexto} />
    </Pressable>
  );
}

export function BotonIcono({
  icono,
  etiqueta,
  onPress,
  color = paleta.texto,
}: {
  icono: NombreIcono;
  etiqueta: string;
  onPress: () => void;
  color?: string;
}) {
  return (
    <Pressable
      onPress={onPress}
      accessibilityRole="button"
      accessibilityLabel={etiqueta}
      hitSlop={espacio.s}
      style={({ pressed }) => [estilos.botonIcono, pressed && estilos.pulsado]}
    >
      <Icono nombre={icono} tam={24} color={color} />
    </Pressable>
  );
}

export function Tarjeta({ children, estilo }: { children: ReactNode; estilo?: StyleProp<ViewStyle> }) {
  return <View style={[estilos.tarjeta, estilo]}>{children}</View>;
}

interface FilaProps {
  titulo: string;
  detalle?: string;
  icono?: NombreIcono;
  onPress?: () => void;
  derecha?: ReactNode;
}

export function Fila({ titulo, detalle, icono, onPress, derecha }: FilaProps) {
  const contenido = (
    <>
      {icono && (
        <View style={estilos.filaIcono}>
          <Icono nombre={icono} tam={20} color={paleta.acentoFuerte} />
        </View>
      )}
      <View style={{ flex: 1 }}>
        <T v="negrita">{titulo}</T>
        {detalle && <T v="ayuda">{detalle}</T>}
      </View>
      {derecha ?? (onPress && <Icono nombre="caret-right" tam={18} color={paleta.tenue} />)}
    </>
  );
  if (!onPress) return <View style={estilos.fila}>{contenido}</View>;
  return (
    <Pressable
      onPress={onPress}
      accessibilityRole="button"
      style={({ pressed }) => [estilos.fila, pressed && { opacity: 0.85 }]}
    >
      {contenido}
    </Pressable>
  );
}

export function Separador() {
  return <View style={estilos.separador} />;
}

export function Seccion({ titulo, children }: { titulo: string; children: ReactNode }) {
  return (
    <View style={{ gap: espacio.s }}>
      <T v="meta" accessibilityRole="header">
        {titulo.toUpperCase()}
      </T>
      <Tarjeta estilo={{ paddingVertical: espacio.xs }}>{children}</Tarjeta>
    </View>
  );
}

export function Chip({ texto, activo, onPress }: { texto: string; activo: boolean; onPress: () => void }) {
  return (
    <Pressable
      onPress={onPress}
      accessibilityRole="button"
      accessibilityState={{ selected: activo }}
      style={({ pressed }) => [
        estilos.chip,
        activo
          ? { backgroundColor: paleta.acento, borderColor: paleta.acento }
          : { backgroundColor: paleta.superficie, borderColor: paleta.borde },
        pressed && estilos.pulsado,
      ]}
    >
      <T v="negrita" style={{ color: activo ? paleta.textoSobreAcento : paleta.texto, fontSize: fuente.etiqueta }}>
        {texto}
      </T>
    </Pressable>
  );
}

export function Chips<V extends string | number>({
  opciones,
  valor,
  onCambio,
}: {
  opciones: { valor: V; texto: string }[];
  valor: V;
  onCambio: (v: V) => void;
}) {
  return (
    <View style={estilos.chips}>
      {opciones.map((o) => (
        <Chip key={String(o.valor)} texto={o.texto} activo={o.valor === valor} onPress={() => onCambio(o.valor)} />
      ))}
    </View>
  );
}

export function Barra({ progreso, color = paleta.dorado }: { progreso: number; color?: string }) {
  const reducir = useReducedMotion();
  const valor = useSharedValue(progreso);
  useEffect(() => {
    valor.value = reducir
      ? progreso
      : withTiming(progreso, { duration: duracion.media, easing: Easing.out(Easing.cubic) });
  }, [progreso, reducir, valor]);
  const relleno = useAnimatedStyle(() => ({ width: `${valor.value * 100}%` }));
  return (
    <View
      style={estilos.barra}
      accessibilityRole="progressbar"
      accessibilityValue={{ min: 0, max: 100, now: Math.round(progreso * 100) }}
    >
      <Animated.View style={[{ height: '100%', backgroundColor: color, borderRadius: radio.pildora }, relleno]} />
    </View>
  );
}

interface CampoProps extends TextInputProps {
  etiqueta: string;
  ayuda?: string;
  error?: string;
}

export function Campo({ etiqueta, ayuda, error, style, ...resto }: CampoProps) {
  return (
    <View style={{ gap: espacio.xs }}>
      <T v="negrita">{etiqueta}</T>
      <TextInput
        accessibilityLabel={etiqueta}
        placeholderTextColor={paleta.placeholder}
        maxFontSizeMultiplier={1.5}
        style={[estilos.campo, error ? { borderColor: paleta.peligro } : null, style]}
        {...resto}
      />
      {error ? (
        <T v="ayuda" style={{ color: paleta.peligro }} accessibilityLiveRegion="polite">
          {error}
        </T>
      ) : (
        ayuda && <T v="ayuda">{ayuda}</T>
      )}
    </View>
  );
}

export function Interruptor({
  titulo,
  detalle,
  valor,
  onCambio,
}: {
  titulo: string;
  detalle?: string;
  valor: boolean;
  onCambio: (v: boolean) => void;
}) {
  return (
    <Fila
      titulo={titulo}
      detalle={detalle}
      derecha={
        <Switch
          value={valor}
          onValueChange={onCambio}
          accessibilityLabel={titulo}
          trackColor={{ false: paleta.desactivado, true: paleta.acento }}
          thumbColor={valor ? paleta.banda : paleta.tenue}
        />
      }
    />
  );
}

export function HScroll({ children, alto }: { children: ReactNode; alto: number }) {
  return (
    <View style={{ height: alto }}>
      <ScrollView horizontal showsHorizontalScrollIndicator={false} contentContainerStyle={{ gap: espacio.s }}>
        {children}
      </ScrollView>
    </View>
  );
}

export function EstadoVacio({
  icono,
  texto,
  accion,
}: {
  icono: NombreIcono;
  texto: string;
  accion?: { texto: string; onPress: () => void };
}) {
  return (
    <View style={estilos.vacio}>
      <Icono nombre={icono} tam={64} color={paleta.borde} />
      <T v="cuerpo" style={{ textAlign: 'center', color: paleta.textoSecundario }}>
        {texto}
      </T>
      {accion && <Boton texto={accion.texto} onPress={accion.onPress} tipo="secundario" />}
    </View>
  );
}

const estilos = StyleSheet.create({
  pantalla: { flex: 1, backgroundColor: paleta.fondo },
  contenido: { paddingHorizontal: espacio.margen, paddingVertical: espacio.l, gap: espacio.l },
  pie: { paddingHorizontal: espacio.margen, paddingBottom: espacio.l, gap: espacio.s },
  cabecera: { flexDirection: 'row', alignItems: 'center', gap: espacio.s, minHeight: espacio.toque },
  boton: {
    minHeight: espacio.toque,
    borderRadius: radio.l,
    borderWidth: 1.5,
    paddingHorizontal: espacio.xl,
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'center',
    gap: espacio.s,
  },
  pulsado: { transform: [{ scale: 0.97 }], opacity: 0.9 },
  gigante: {
    minHeight: 96,
    borderRadius: radio.xl,
    borderWidth: 1.5,
    padding: espacio.l,
    flexDirection: 'row',
    alignItems: 'center',
    gap: espacio.l,
  },
  giganteIcono: { width: 56, height: 56, borderRadius: radio.pildora, alignItems: 'center', justifyContent: 'center' },
  botonIcono: { width: 48, height: 48, alignItems: 'center', justifyContent: 'center', borderRadius: radio.pildora },
  tarjeta: {
    backgroundColor: paleta.superficie,
    borderRadius: radio.l,
    borderWidth: 1,
    borderColor: paleta.borde,
    padding: espacio.l,
  },
  fila: { flexDirection: 'row', alignItems: 'center', gap: espacio.m, minHeight: espacio.toque, paddingVertical: espacio.s },
  filaIcono: {
    width: 36,
    height: 36,
    borderRadius: radio.m,
    backgroundColor: paleta.acentoSuave,
    alignItems: 'center',
    justifyContent: 'center',
  },
  separador: { height: StyleSheet.hairlineWidth, backgroundColor: paleta.borde },
  chips: { flexDirection: 'row', flexWrap: 'wrap', gap: espacio.s },
  chip: {
    minHeight: 48,
    paddingHorizontal: espacio.l,
    borderRadius: radio.pildora,
    borderWidth: 1.5,
    justifyContent: 'center',
  },
  barra: { height: 10, borderRadius: radio.pildora, backgroundColor: paleta.superficieAlt, overflow: 'hidden' },
  campo: {
    minHeight: espacio.toque,
    borderRadius: radio.m,
    borderWidth: 1.5,
    borderColor: paleta.borde,
    backgroundColor: paleta.superficieAlt,
    paddingHorizontal: espacio.l,
    color: paleta.texto,
    fontFamily: familia.texto,
    fontSize: fuente.cuerpo,
  },
  vacio: { alignItems: 'center', gap: espacio.l, paddingVertical: espacio.xxl },
});
