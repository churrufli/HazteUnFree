import { Redirect } from 'expo-router';

import { useAjustes } from '@/estado/Ajustes';

export default function Entrada() {
  const { ajustes } = useAjustes();
  return <Redirect href={ajustes.bienvenidaVista ? '/inicio' : '/bienvenida'} />;
}
