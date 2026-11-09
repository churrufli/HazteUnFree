import { router } from 'expo-router';
import { View } from 'react-native';

import { palabrasDe } from '@/dominio/diccionarios';
import type { FuenteMusica } from '@/dominio/juego/config';
import { duraciones, formatos, infoFormato, type Disparo } from '@/dominio/juego/formatos';
import { useSesion } from '@/estado/Sesion';
import { Chips, Fila, T, Tarjeta } from './componentes';
import { espacio } from './tema';

const disparos: { valor: Disparo; texto: string }[] = [
  { valor: 'auto', texto: 'Al pulsar' },
  { valor: 'manual', texto: 'Manual' },
];

const ayudaDisparo: Record<Disparo, string> = {
  auto: 'Al pulsar «Empezar la batalla» arrancan el reloj y las palabras, al ritmo del formato.',
  manual: 'Sale una palabra cada vez que tocas la pantalla.',
};

const opcionesMusica: { valor: FuenteMusica; texto: string }[] = [
  { valor: 'externa', texto: 'La pongo yo' },
  { valor: 'acapella', texto: 'A capella' },
];

const ayudaMusica: Record<FuenteMusica, string> = {
  externa: 'Pon el beat en otra pestaña, en Spotify, en un altavoz Bluetooth… donde quieras. Pausa solo para el reloj.',
  acapella: 'Sin música. Pausa solo para el reloj.',
};

function Grupo({ titulo, ayuda, children }: { titulo: string; ayuda?: string; children: React.ReactNode }) {
  return (
    <View style={{ gap: espacio.s }}>
      <T v="meta">{titulo.toUpperCase()}</T>
      {children}
      {ayuda && <T v="ayuda">{ayuda}</T>}
    </View>
  );
}

export function FormularioRonda({ duracionTitulo = 'Duración' }: { duracionTitulo?: string }) {
  const { config, cambiarConfig, disponibles } = useSesion();
  const elegidos = disponibles.filter((d) => config.diccionarios.includes(d.clave));
  const libre = config.formato === 'libre';

  return (
    <View style={{ gap: espacio.xl }}>
      <Grupo titulo="Formato" ayuda={infoFormato(config.formato).descripcion}>
        <Chips
          opciones={formatos.map((f) => ({ valor: f.clave, texto: f.nombre }))}
          valor={config.formato}
          onCambio={(formato) => cambiarConfig({ formato })}
        />
      </Grupo>

      {!libre && (
        <Grupo titulo="Diccionarios">
          <Tarjeta estilo={{ paddingVertical: espacio.xs }}>
            <Fila
              titulo={elegidos.length ? elegidos.map((d) => d.nombre).join(' + ') : 'General'}
              detalle={`${palabrasDe(disponibles, config.diccionarios).length.toLocaleString('es-ES')} palabras · toca para cambiar`}
              icono="book-open"
              onPress={() => router.push('/diccionarios')}
            />
          </Tarjeta>
        </Grupo>
      )}

      <Grupo titulo={duracionTitulo}>
        <Chips
          opciones={duraciones.map((d) => ({ valor: d.ms, texto: d.texto }))}
          valor={config.duracionMs}
          onCambio={(duracionMs) => cambiarConfig({ duracionMs })}
        />
      </Grupo>

      {!libre && (
        <Grupo titulo="Cómo salen las palabras" ayuda={ayudaDisparo[config.disparo]}>
          <Chips opciones={disparos} valor={config.disparo} onCambio={(disparo) => cambiarConfig({ disparo })} />
        </Grupo>
      )}

      <Grupo titulo="Música" ayuda={ayudaMusica[config.musica]}>
        <Chips opciones={opcionesMusica} valor={config.musica} onCambio={(musica) => cambiarConfig({ musica })} />
      </Grupo>
    </View>
  );
}
