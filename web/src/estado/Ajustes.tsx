import { createContext, useCallback, useContext, useEffect, useMemo, useState, type ReactNode } from 'react';

import { borrarTodo, guardarAjuste, leerAjustes } from '@/datos/repositorio';
import { aFila, ajustesPorDefecto, deFilas, type Ajustes } from '@/dominio/ajustes';

interface ContextoAjustes {
  ajustes: Ajustes;
  cargado: boolean;
  cambiar: <K extends keyof Ajustes>(clave: K, valor: Ajustes[K]) => Promise<void>;
  reiniciar: () => Promise<void>;
}

const Contexto = createContext<ContextoAjustes | null>(null);

export function ProveedorAjustes({ children }: { children: ReactNode }) {
  const [ajustes, setAjustes] = useState<Ajustes>(ajustesPorDefecto);
  const [cargado, setCargado] = useState(false);

  useEffect(() => {
    leerAjustes()
      .then((filas) => setAjustes(deFilas(filas)))
      .finally(() => setCargado(true));
  }, []);

  const cambiar = useCallback(
    async <K extends keyof Ajustes>(clave: K, valor: Ajustes[K]) => {
      setAjustes((a) => ({ ...a, [clave]: valor }));
      await guardarAjuste(clave, aFila(valor));
    },
    [],
  );

  const reiniciar = useCallback(async () => {
    await borrarTodo();
    setAjustes(ajustesPorDefecto);
  }, []);

  const valor = useMemo(() => ({ ajustes, cargado, cambiar, reiniciar }), [ajustes, cargado, cambiar, reiniciar]);
  return <Contexto.Provider value={valor}>{children}</Contexto.Provider>;
}

export function useAjustes() {
  const c = useContext(Contexto);
  if (!c) throw new Error('useAjustes fuera de ProveedorAjustes');
  return c;
}
