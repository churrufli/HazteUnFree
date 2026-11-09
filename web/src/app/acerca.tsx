import { router } from 'expo-router';
import { View } from 'react-native';

import { Cabecera, Logo, Pantalla, Seccion, T } from '@/ui/componentes';
import { Medallon } from '@/ui/Medallon';
import { espacio, paleta } from '@/ui/tema';

function Bloque({ children }: { children: string }) {
  return (
    <T v="cuerpo" style={{ color: paleta.textoSecundario, paddingVertical: espacio.s }}>
      {children}
    </T>
  );
}

export default function Acerca() {
  return (
    <Pantalla>
      <Cabecera titulo="Acerca de" onAtras={() => router.back()} />
      <View style={{ alignItems: 'center', gap: espacio.s }}>
        <Medallon tam={120} />
        <Logo />
        <T v="ayuda">Software libre para batallas de freestyle</T>
      </View>

      <Seccion titulo="Qué hace">
        <Bloque>
          Te ayuda a entrenar freestyle: pones una instrumental, corre el reloj y te voy soltando palabras al ritmo del formato que
          elijas. Puedes rapear tú solo o por turnos, pasándole el móvil a tu gente.
        </Bloque>
      </Seccion>

      <Seccion titulo="Cómo funciona por dentro">
        <Bloque>
          Las palabras salen de los diccionarios que elijas, los de la app o los tuyos, sin repetirse hasta que se acaban. La música la pones tú donde
          quieras: en otra pestaña del navegador, en Spotify, en un altavoz Bluetooth…
        </Bloque>
      </Seccion>

      <Seccion titulo="Privacidad">
        <Bloque>
          No hay cuentas, ni anuncios, ni analítica. Tus ajustes y tus diccionarios se quedan en tu navegador y no salen
          de él.
        </Bloque>
      </Seccion>

      <Seccion titulo="Licencias">
        <Bloque>
          Tipografías Anton e Inter (SIL Open Font License). Iconos Phosphor (MIT). Hecha con Expo y React Native (MIT). Basada en
          HazteUnFree para Windows, de churrufli.
        </Bloque>
      </Seccion>
    </Pantalla>
  );
}
