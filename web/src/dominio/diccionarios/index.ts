import general from './general.json';
import tematicos from './tematicos.json';

export interface Diccionario {
  clave: string;
  nombre: string;
  palabras: string[];
}

export const diccionarioGeneral: Diccionario = { clave: 'general', nombre: 'General', palabras: general };
export const diccionariosTematicos: Diccionario[] = tematicos;
export const diccionarios: Diccionario[] = [diccionarioGeneral, ...diccionariosTematicos];

/** Palabras de los diccionarios elegidos; si no queda ninguno, las del general. */
export function palabrasDe(disponibles: Diccionario[], claves: string[]) {
  const elegidos = disponibles.filter((d) => claves.includes(d.clave));
  return (elegidos.length ? elegidos : [diccionarioGeneral]).flatMap((d) => d.palabras);
}
