import { Text, type StyleProp, type TextStyle } from 'react-native';

import glifos from './glifos.json';
import { familia, paleta } from './tema';

export type NombreIcono = keyof typeof glifos;

interface Props {
  nombre: NombreIcono;
  tam?: number;
  color?: string;
  etiqueta?: string;
  estilo?: StyleProp<TextStyle>;
}

export function Icono({ nombre, tam = 24, color = paleta.texto, etiqueta, estilo }: Props) {
  return (
    <Text
      allowFontScaling={false}
      accessible={!!etiqueta}
      accessibilityLabel={etiqueta}
      importantForAccessibility={etiqueta ? 'yes' : 'no-hide-descendants'}
      style={[{ fontFamily: familia.iconos, fontSize: tam, lineHeight: tam, color, includeFontPadding: false }, estilo]}
    >
      {String.fromCodePoint(glifos[nombre])}
    </Text>
  );
}
