import { Redirect, router } from 'expo-router';
import { useState } from 'react';

import { mcPorId, votar } from '@/dominio/juego/turnos';
import { useSesion } from '@/estado/Sesion';
import { Boton, Cabecera, Fila, Pantalla, Separador, T, Tarjeta } from '@/ui/componentes';
import { Icono } from '@/ui/Icono';
import { espacio, paleta } from '@/ui/tema';

export default function Votacion() {
  const { partida, setPartida } = useSesion();
  const [elegidos, setElegidos] = useState<string[]>([]);
  if (!partida) return <Redirect href="/inicio" />;
  if (partida.fase !== 'votacion') return <Redirect href={partida.fase === 'final' ? '/marcador' : '/pase'} />;

  const alternar = (id: string) => setElegidos((e) => (e.includes(id) ? e.filter((x) => x !== id) : [...e, id]));

  const texto =
    elegidos.length === 0
      ? 'Nadie gana esta ronda'
      : elegidos.length === 1
        ? `Gana ${mcPorId(partida, elegidos[0]!).nombre}`
        : partida.replica
          ? 'Empate otra vez: nadie puntúa'
          : 'Empate: a la réplica';

  const confirmar = () => {
    const siguiente = votar(partida, elegidos);
    setPartida(siguiente);
    router.replace(siguiente.fase === 'final' ? '/marcador' : '/pase');
  };

  return (
    <Pantalla pie={<Boton texto={texto} icono={elegidos.length === 1 ? 'crown' : 'check'} onPress={confirmar} />}>
      <Cabecera titulo={partida.replica ? 'Votación de la réplica' : partida.desempate ? 'Votación del desempate' : `Votación ronda ${partida.ronda}`} />
      <T v="cuerpo" style={{ color: paleta.textoSecundario }}>
        ¿Quién ha ganado? Si no os ponéis de acuerdo, marca a varios y se van a la réplica.
      </T>
      <Tarjeta estilo={{ paddingVertical: espacio.xs }}>
        {partida.cola.map((id, i) => {
          const activo = elegidos.includes(id);
          return (
            <Fila
              key={id}
              titulo={mcPorId(partida, id).nombre}
              detalle={`${partida.puntos[id]} ${partida.puntos[id] === 1 ? 'punto' : 'puntos'}`}
              icono={i === 0 ? 'microphone-stage' : 'user'}
              onPress={() => alternar(id)}
              derecha={<Icono nombre={activo ? 'check' : 'crown'} tam={22} color={activo ? paleta.exito : paleta.borde} />}
            />
          );
        }).flatMap((f, i) => (i === 0 ? [f] : [<Separador key={`s${i}`} />, f]))}
      </Tarjeta>
    </Pantalla>
  );
}
