import { router } from 'expo-router';

import { infoFormato } from '@/dominio/juego/formatos';
import { useSesion } from '@/estado/Sesion';
import { Boton, Cabecera, EstadoVacio, Pantalla, T } from '@/ui/componentes';
import { ListaPalabras } from '@/ui/juego';
import { paleta } from '@/ui/tema';

export default function Resultado() {
  const { jugadas, config } = useSesion();
  const ultima = jugadas.at(-1);
  const palabras = ultima?.palabras ?? [];

  return (
    <Pantalla
      pie={
        <Boton texto="Cambiar el formato" tipo="secundario" icono="gear" onPress={() => router.back()} />
      }
    >
      <Cabecera titulo="Fin de la ronda" onAtras={() => router.back()} />
      <T v="cuerpo" style={{ color: paleta.textoSecundario }}>
        {palabras.length === 0
          ? `${infoFormato(config.formato).nombre}. Esta vez no han salido palabras.`
          : `Han salido ${palabras.length} ${palabras.length === 1 ? 'palabra' : 'palabras'}. Toca una para buscarla en Google y saber qué significa o quién es.`}
      </T>
      <Boton texto="Otra ronda" icono="arrows-clockwise" onPress={() => router.replace({ pathname: '/ronda', params: { modo: 'individual' } })} />
      {palabras.length > 0 ? <ListaPalabras palabras={palabras} /> : <EstadoVacio icono="microphone-stage" texto="Solo tú y el beat." />}
    </Pantalla>
  );
}
