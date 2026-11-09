import { router } from 'expo-router';

import { Boton, Cabecera, Pantalla } from '@/ui/componentes';
import { FormularioRonda } from '@/ui/ConfigRonda';

export default function Individual() {
  return (
    <Pantalla pie={<Boton texto="Empezar" icono="microphone-stage" onPress={() => router.push({ pathname: '/ronda', params: { modo: 'individual' } })} />}>
      <Cabecera titulo="Individual" onAtras={() => router.back()} />
      <FormularioRonda />
    </Pantalla>
  );
}
