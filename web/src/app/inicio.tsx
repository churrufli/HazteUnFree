import { router } from 'expo-router';
import { StyleSheet, View } from 'react-native';

import { diccionariosTematicos } from '@/dominio/diccionarios';
import { BotonGigante, BotonIcono, Fila, Logo, Pantalla, Separador, T, Tarjeta } from '@/ui/componentes';
import { Medallon } from '@/ui/Medallon';
import { espacio } from '@/ui/tema';

export default function Inicio() {
  return (
    <Pantalla decoracion>
      <View style={estilos.cabecera}>
        <View style={{ flex: 1 }}>
          <T v="meta">¿LISTO PARA SOLTARLO?</T>
          <Logo />
        </View>
        <BotonIcono icono="gear" etiqueta="Ajustes" onPress={() => router.push('/ajustes')} />
      </View>

      <View style={estilos.medallon}>
        <Medallon tam={180} />
      </View>

      <BotonGigante
        titulo="Individual"
        subtitulo="Tú, el beat y las palabras"
        icono="microphone-stage"
        onPress={() => router.push('/individual')}
      />
      <BotonGigante
        titulo="Por turnos"
        subtitulo="Pásale el móvil a tu gente"
        icono="users"
        tipo="secundario"
        onPress={() => router.push('/turnos')}
      />

      <Tarjeta estilo={{ paddingVertical: espacio.xs }}>
        <Fila
          titulo="Diccionarios"
          detalle={`General, ${diccionariosTematicos.length} temáticos y los tuyos`}
          icono="book-open"
          onPress={() => router.push('/diccionarios')}
        />
        <Separador />
        <Fila titulo="Acerca de" icono="info" onPress={() => router.push('/acerca')} />
      </Tarjeta>
    </Pantalla>
  );
}

const estilos = StyleSheet.create({
  cabecera: { flexDirection: 'row', alignItems: 'center' },
  medallon: { alignItems: 'center', paddingVertical: espacio.s },
});
