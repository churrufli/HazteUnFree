import { useCallback, useEffect, useReducer, useRef } from 'react';

import type { ConfigRonda } from '@/dominio/juego/config';
import { infoFormato } from '@/dominio/juego/formatos';
import { progresoSiguiente, siguienteEnMs, restante, ronda, rondaInicial } from '@/dominio/juego/ronda';

interface Opciones {
  config: ConfigRonda;
  sacarPalabras: (n: number) => string[];
  onFin: (usadas: string[]) => void;
}

const PASO_MS = 100;

export function useRonda({ config, sacarPalabras, onFin }: Opciones) {
  const [e, dispatch] = useReducer(ronda, config, (c) => rondaInicial(c, Date.now()));
  const porTanda = infoFormato(config.formato).porTanda;
  const fin = useRef(onFin);
  useEffect(() => {
    fin.current = onFin;
  });

  useEffect(() => {
    if (e.fase !== 'jugando') return;
    const id = setInterval(() => dispatch({ tipo: 'tic', ahora: Date.now() }), PASO_MS);
    return () => clearInterval(id);
  }, [e.fase]);

  useEffect(() => {
    if (e.pendientes > 0) dispatch({ tipo: 'tanda', palabras: porTanda > 0 ? sacarPalabras(porTanda) : [] });
  }, [e.pendientes, porTanda, sacarPalabras]);

  const terminado = e.fase === 'fin';
  const usadas = e.usadas;
  useEffect(() => {
    if (terminado) fin.current(usadas);
  }, [terminado, usadas]);

  return {
    fase: e.fase,
    restanteMs: restante(e),
    tanda: e.tanda,
    progresoSiguiente: progresoSiguiente(e),
    siguienteEnMs: siguienteEnMs(e),
    empezar: useCallback(() => dispatch({ tipo: 'empezar', ahora: Date.now() }), []),
    pausar: useCallback(() => dispatch({ tipo: 'pausar', ahora: Date.now() }), []),
    reanudar: useCallback(() => dispatch({ tipo: 'reanudar', ahora: Date.now() }), []),
    terminar: useCallback(() => dispatch({ tipo: 'terminar', ahora: Date.now() }), []),
    palabraManual: useCallback(() => dispatch({ tipo: 'pedirTanda' }), []),
  };
}
