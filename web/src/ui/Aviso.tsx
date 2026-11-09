import { Pressable, StyleSheet, View } from 'react-native';

import { BotonIcono, T } from './componentes';
import { Icono } from './Icono';
import { espacio, fuente, paleta, radio } from './tema';

interface Props {
  texto: string;
  tipo?: 'info' | 'aviso';
  acciones?: { texto: string; onPress: () => void }[];
  onCerrar?: () => void;
}

export function Aviso({ texto, tipo = 'info', acciones, onCerrar }: Props) {
  return (
    <View style={estilos.aviso} accessibilityLiveRegion="polite">
      <Icono nombre={tipo === 'aviso' ? 'warning' : 'info'} tam={20} color={tipo === 'aviso' ? paleta.aviso : paleta.acentoFuerte} />
      <View style={{ flex: 1, gap: espacio.xs }}>
        <T v="ayuda">{texto}</T>
        {acciones && (
          <View style={estilos.acciones}>
            {acciones.map((a) => (
              <Pressable key={a.texto} onPress={a.onPress} accessibilityRole="button" hitSlop={espacio.s} style={estilos.accion}>
                <T v="negrita" style={{ color: paleta.acentoFuerte, fontSize: fuente.etiqueta }}>
                  {a.texto}
                </T>
              </Pressable>
            ))}
          </View>
        )}
      </View>
      {onCerrar && <BotonIcono icono="x" etiqueta="Cerrar aviso" onPress={onCerrar} color={paleta.tenue} />}
    </View>
  );
}

const estilos = StyleSheet.create({
  aviso: {
    flexDirection: 'row',
    alignItems: 'flex-start',
    gap: espacio.m,
    backgroundColor: paleta.superficieAlt,
    borderRadius: radio.m,
    paddingLeft: espacio.l,
    paddingVertical: espacio.m,
    paddingRight: espacio.xs,
  },
  acciones: { flexDirection: 'row', gap: espacio.l },
  accion: { minHeight: 32, justifyContent: 'center' },
});
