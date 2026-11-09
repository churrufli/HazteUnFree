import { router } from 'expo-router';

import { useAjustes } from '@/estado/Ajustes';
import { useSesion } from '@/estado/Sesion';
import { Cabecera, Fila, Interruptor, Pantalla, Seccion, Separador } from '@/ui/componentes';
import { useConfirm } from '@/ui/Dialogo';

export default function Ajustes() {
  const { ajustes, cambiar, reiniciar } = useAjustes();
  const { cambiarConfig, nuevaSesion } = useSesion();
  const confirmar = useConfirm();

  const borrar = async () => {
    const ok = await confirmar({
      title: '¿Borrar todos los datos?',
      message: 'Se pierden tus ajustes y tus diccionarios, y vuelves a ver la bienvenida. No se puede deshacer.',
      confirmar: 'Borrar',
      peligro: true,
    });
    if (!ok) return;
    await reiniciar();
    cambiarConfig({ musica: 'externa' });
    nuevaSesion();
    router.replace('/bienvenida');
  };

  return (
    <Pantalla>
      <Cabecera titulo="Ajustes" onAtras={() => router.back()} />

      <Seccion titulo="Partida">
        <Interruptor
          titulo="Bocina al acabar"
          detalle="Suena cuando termina la ronda"
          valor={ajustes.bocinaFinal}
          onCambio={(v) => cambiar('bocinaFinal', v)}
        />
        <Separador />
        <Interruptor
          titulo="Pantalla siempre encendida"
          detalle="Mientras dura la ronda"
          valor={ajustes.pantallaEncendida}
          onCambio={(v) => cambiar('pantallaEncendida', v)}
        />
      </Seccion>

      <Seccion titulo="Datos">
        <Fila titulo="Borrar todos los datos" detalle="Ajustes y diccionarios propios" icono="trash" onPress={borrar} />
      </Seccion>

      <Seccion titulo="Información">
        <Fila titulo="Acerca de HazteUnFree" icono="question" onPress={() => router.push('/acerca')} />
        <Separador />
        <Fila titulo="Ver la bienvenida otra vez" icono="hand-pointing" onPress={() => router.push('/bienvenida')} />
      </Seccion>
    </Pantalla>
  );
}
