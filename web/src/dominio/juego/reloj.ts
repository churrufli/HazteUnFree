export interface Reloj {
  inicio: number | null;
  acumulado: number;
}

export const relojNuevo = (): Reloj => ({ inicio: null, acumulado: 0 });

export const enMarcha = (r: Reloj) => r.inicio !== null;

export const arrancar = (r: Reloj, ahora: number): Reloj => (r.inicio === null ? { ...r, inicio: ahora } : r);

export const pausar = (r: Reloj, ahora: number): Reloj =>
  r.inicio === null ? r : { inicio: null, acumulado: r.acumulado + (ahora - r.inicio) };

export const transcurrido = (r: Reloj, ahora: number) => r.acumulado + (r.inicio === null ? 0 : ahora - r.inicio);

export function formatoReloj(restanteMs: number) {
  const s = Math.max(0, Math.ceil(restanteMs / 1000));
  if (s < 60) return String(s).padStart(2, '0');
  return `${Math.floor(s / 60)}:${String(s % 60).padStart(2, '0')}`;
}
