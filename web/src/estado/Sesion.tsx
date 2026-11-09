import { createContext, useCallback, useContext, useEffect, useMemo, useRef, useState, type ReactNode } from 'react';

import { guardarAjuste, leerAjustes } from '@/datos/repositorio';
import { diccionarios, palabrasDe, type Diccionario } from '@/dominio/diccionarios';
import { configPorDefecto, leerConfig, type ConfigRonda } from '@/dominio/juego/config';
import { crearBolsa, sacar, type Bolsa } from '@/dominio/juego/palabras';
import type { Partida } from '@/dominio/juego/turnos';

export interface RondaJugada {
  mcId: string | null;
  ronda: number;
  palabras: string[];
}

interface ContextoSesion {
  config: ConfigRonda;
  cambiarConfig: (c: Partial<ConfigRonda>) => void;
  sacarPalabras: (n: number) => string[];
  partida: Partida | null;
  setPartida: (p: Partida | null) => void;
  jugadas: RondaJugada[];
  apuntarJugada: (j: RondaJugada) => void;
  nuevaSesion: () => void;
  disponibles: Diccionario[];
  propios: Diccionario[];
  guardarPropio: (d: Diccionario) => void;
  borrarPropio: (clave: string) => void;
}

const Contexto = createContext<ContextoSesion | null>(null);


export function ProveedorSesion({ children }: { children: ReactNode }) {
  const [config, setConfig] = useState<ConfigRonda>(configPorDefecto);
  const [partida, setPartida] = useState<Partida | null>(null);
  const [jugadas, setJugadas] = useState<RondaJugada[]>([]);
  const [propios, setPropios] = useState<Diccionario[]>([]);
  const bolsa = useRef<{ claves: string; bolsa: Bolsa } | null>(null);

  useEffect(() => {
    leerAjustes().then((f) => {
      setConfig(leerConfig(f.ultimaConfig));
      try {
        setPropios(JSON.parse(f.diccionariosPropios ?? '[]') as Diccionario[]);
      } catch {}
    });
  }, []);

  const cambiarConfig = useCallback(
    (c: Partial<ConfigRonda>) =>
      setConfig((anterior) => {
        const nueva = { ...anterior, ...c };
        guardarAjuste('ultimaConfig', JSON.stringify(nueva));
        return nueva;
      }),
    [],
  );

  const disponibles = useMemo(() => [...propios, ...diccionarios], [propios]);
  useEffect(() => {
    bolsa.current = null;
  }, [disponibles]);

  const guardarPropios = useCallback(
    (cambiar: (ds: Diccionario[]) => Diccionario[]) =>
      setPropios((ds) => {
        const nuevos = cambiar(ds);
        guardarAjuste('diccionariosPropios', JSON.stringify(nuevos));
        return nuevos;
      }),
    [],
  );
  const guardarPropio = useCallback(
    (d: Diccionario) => guardarPropios((ds) => (ds.some((x) => x.clave === d.clave) ? ds.map((x) => (x.clave === d.clave ? d : x)) : [d, ...ds])),
    [guardarPropios],
  );
  const borrarPropio = useCallback((clave: string) => guardarPropios((ds) => ds.filter((x) => x.clave !== clave)), [guardarPropios]);

  const sacarPalabras = useCallback(
    (n: number) => {
      const claves = config.diccionarios.join('|');
      if (bolsa.current?.claves !== claves) bolsa.current = { claves, bolsa: crearBolsa(palabrasDe(disponibles, config.diccionarios)) };
      const [salen, resto] = sacar(bolsa.current.bolsa, n);
      bolsa.current.bolsa = resto;
      return salen;
    },
    [config.diccionarios, disponibles],
  );

  const apuntarJugada = useCallback((j: RondaJugada) => setJugadas((js) => [...js, j]), []);

  const nuevaSesion = useCallback(() => {
    setJugadas([]);
    setPartida(null);
  }, []);

  const valor = useMemo(
    () => ({
      config,
      cambiarConfig,
      sacarPalabras,
      partida,
      setPartida,
      jugadas,
      apuntarJugada,
      nuevaSesion,
      disponibles,
      propios,
      guardarPropio,
      borrarPropio,
    }),
    [
      config,
      cambiarConfig,
      sacarPalabras,
      partida,
      jugadas,
      apuntarJugada,
      nuevaSesion,
      disponibles,
      propios,
      guardarPropio,
      borrarPropio,
    ],
  );

  return <Contexto.Provider value={valor}>{children}</Contexto.Provider>;
}

export function useSesion() {
  const c = useContext(Contexto);
  if (!c) throw new Error('useSesion fuera de ProveedorSesion');
  return c;
}
