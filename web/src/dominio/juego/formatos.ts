export type Formato = 'easy' | 'hard' | 'extreme' | '4x10' | 'incremental' | 'libre';
export type Disparo = 'auto' | 'manual';

export interface InfoFormato {
  clave: Formato;
  nombre: string;
  descripcion: string;
  porTanda: number;
}

export const formatos: InfoFormato[] = [
  { clave: 'easy', nombre: 'Easy', descripcion: 'Una palabra cada 10 s', porTanda: 1 },
  { clave: 'hard', nombre: 'Hard', descripcion: 'Una palabra cada 5 s', porTanda: 1 },
  { clave: 'extreme', nombre: 'Extreme', descripcion: 'Una palabra cada 2 s', porTanda: 1 },
  { clave: '4x10', nombre: '4x10', descripcion: 'Cuatro palabras cada 10 s', porTanda: 4 },
  { clave: 'incremental', nombre: 'Incremental', descripcion: 'De 10 s a 5 s y a 2 s', porTanda: 1 },
  { clave: 'libre', nombre: 'Minuto libre', descripcion: 'Sin palabras, solo beat y reloj', porTanda: 0 },
];

export const infoFormato = (f: Formato) => formatos.find((x) => x.clave === f)!;

export const duraciones = [
  { ms: 60_000, texto: "1'" },
  { ms: 80_000, texto: "1'20''" },
  { ms: 120_000, texto: "2'" },
  { ms: 180_000, texto: "3'" },
];

export function intervaloEn(formato: Formato, transcurridoMs: number, duracionMs: number): number {
  switch (formato) {
    case 'easy':
    case '4x10':
      return 10_000;
    case 'hard':
      return 5_000;
    case 'extreme':
      return 2_000;
    case 'incremental': {
      const tercio = duracionMs / 3;
      if (transcurridoMs < tercio) return 10_000;
      if (transcurridoMs < tercio * 2) return 5_000;
      return 2_000;
    }
    case 'libre':
      return Infinity;
  }
}

export function programa(formato: Formato, duracionMs: number, desdeMs = 0): number[] {
  if (formato === 'libre') return [];
  const instantes: number[] = [];
  let t = desdeMs;
  while (t < duracionMs) {
    const intervalo = intervaloEn(formato, t, duracionMs);
    if (duracionMs - t < Math.min(intervalo, 2_000)) break;
    instantes.push(t);
    t += intervalo;
  }
  return instantes;
}

export function proximaTanda(instantes: number[], transcurridoMs: number) {
  const indice = instantes.findIndex((t) => t > transcurridoMs);
  return indice === -1 ? null : { indice, enMs: instantes[indice]! - transcurridoMs };
}

export function tandasVencidas(instantes: number[], transcurridoMs: number) {
  let n = 0;
  while (n < instantes.length && instantes[n]! <= transcurridoMs) n++;
  return n;
}
