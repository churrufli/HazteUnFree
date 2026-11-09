import { Redirect, router } from 'expo-router';
import { useState } from 'react';
import { StyleSheet, View } from 'react-native';

import { clasificacion, crearPartida, ganadores, mcPorId } from '@/dominio/juego/turnos';
import { useSesion } from '@/estado/Sesion';
import { Boton, Cabecera, Fila, Pantalla, Seccion, Separador, T, Tarjeta } from '@/ui/componentes';
import { Icono } from '@/ui/Icono';
import { ListaPalabras } from '@/ui/juego';
import { espacio, paleta } from '@/ui/tema';

export default function Marcador() {
  const { partida, jugadas, nuevaSesion, setPartida } = useSesion();
  const [abierto, setAbierto] = useState<string | null>(null);
  if (!partida) return <Redirect href="/inicio" />;

  const [ganador] = ganadores(partida);
  const tabla = clasificacion(partida);

  const revancha = () => {
    const { mcs, rondasTotales } = partida;
    nuevaSesion();
    setPartida(crearPartida(mcs, rondasTotales));
    router.replace('/pase');
  };

  return (
    <Pantalla
      decoracion
      pie={
        <>
          <Boton texto="Revancha" icono="arrows-clockwise" onPress={revancha} />
          <Boton texto="Terminar" tipo="secundario" onPress={() => router.back()} />
        </>
      }
    >
      <Cabecera titulo="Marcador" />
      <View style={estilos.ganador}>
        <Icono nombre={ganador ? 'trophy' : 'users'} tam={64} color={paleta.dorado} />
        <T v="meta">{ganador ? 'GANA LA BATALLA' : 'RESULTADO'}</T>
        <T v="display" style={{ textAlign: 'center' }} numberOfLines={2} adjustsFontSizeToFit>
          {ganador ? mcPorId(partida, ganador).nombre.toLocaleUpperCase('es') : 'EMPATE'}
        </T>
      </View>

      <Seccion titulo="Clasificación">
        {tabla.map((m, i) => (
          <View key={m.id}>
            {i > 0 && <Separador />}
            <Fila
              titulo={`${i + 1}. ${m.nombre}`}
              icono={m.id === ganador ? 'crown' : 'user'}
              derecha={<T v="negrita" style={{ color: paleta.dorado }}>{partida.puntos[m.id]}</T>}
            />
          </View>
        ))}
      </Seccion>

      <Seccion titulo="Rondas">
        {partida.historial.map((h, i) => (
          <View key={i}>
            {i > 0 && <Separador />}
            <Fila
              titulo={h.ganador ? `Ronda ${h.ronda}: ${mcPorId(partida, h.ganador).nombre}` : `Ronda ${h.ronda}: nadie puntúa`}
              detalle={h.replica ? 'Decidida en la réplica' : undefined}
              icono={h.ganador ? 'medal' : 'x'}
            />
          </View>
        ))}
      </Seccion>

      <View style={{ gap: espacio.s }}>
        <T v="meta">PALABRAS DE CADA MC</T>
        {partida.mcs.map((m) => {
          const palabras = jugadas.filter((j) => j.mcId === m.id).flatMap((j) => j.palabras);
          const visible = abierto === m.id;
          return (
            <View key={m.id} style={{ gap: espacio.s }}>
              <Tarjeta estilo={{ paddingVertical: espacio.xs }}>
                <Fila
                  titulo={m.nombre}
                  detalle={palabras.length ? `${palabras.length} palabras · toca para ${visible ? 'ocultarlas' : 'verlas'}` : 'Sin palabras'}
                  icono="list-bullets"
                  onPress={palabras.length ? () => setAbierto(visible ? null : m.id) : undefined}
                />
              </Tarjeta>
              {visible && <ListaPalabras palabras={palabras} />}
            </View>
          );
        })}
      </View>
    </Pantalla>
  );
}

const estilos = StyleSheet.create({
  ganador: { alignItems: 'center', gap: espacio.s, paddingVertical: espacio.l },
});
