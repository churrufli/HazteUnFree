export interface Mc {
  id: string;
  nombre: string;
}

export interface ResultadoRonda {
  ronda: number;
  ganador: string | null;
  replica: boolean;
}

export interface Partida {
  mcs: Mc[];
  rondasTotales: number;
  /** null: uno a uno. Con valor: alternando, el MC cambia cada intervaloMs en una sola ronda. */
  intervaloMs: number | null;
  ronda: number;
  cola: string[];
  indice: number;
  fase: 'turno' | 'votacion' | 'final';
  replica: boolean;
  desempate: boolean;
  puntos: Record<string, number>;
  historial: ResultadoRonda[];
}

export const MIN_MCS = 2;
export const MAX_MCS = 8;

function ordenDeRonda(mcs: Mc[], ronda: number) {
  const ids = mcs.map((m) => m.id);
  const desfase = (ronda - 1) % ids.length;
  return [...ids.slice(desfase), ...ids.slice(0, desfase)];
}

export function crearPartida(mcs: Mc[], rondasTotales: number, intervaloMs: number | null = null): Partida {
  if (mcs.length < MIN_MCS || mcs.length > MAX_MCS) throw new Error(`Hacen falta entre ${MIN_MCS} y ${MAX_MCS} MCs`);
  return {
    mcs,
    rondasTotales: Math.max(1, rondasTotales),
    intervaloMs,
    ronda: 1,
    cola: ordenDeRonda(mcs, 1),
    indice: 0,
    fase: 'turno',
    replica: false,
    desempate: false,
    puntos: Object.fromEntries(mcs.map((m) => [m.id, 0])),
    historial: [],
  };
}

export const mcPorId = (p: Partida, id: string) => p.mcs.find((m) => m.id === id)!;

export function turnoActual(p: Partida) {
  return p.fase === 'turno' ? mcPorId(p, p.cola[p.indice]!) : null;
}

export function mcAlternando(p: Partida, transcurridoMs: number) {
  const vuelta = Math.floor(transcurridoMs / (p.intervaloMs ?? Infinity));
  return mcPorId(p, p.cola[vuelta % p.cola.length]!);
}

export function siguienteMc(p: Partida) {
  const id = p.cola[p.indice + 1];
  return id ? mcPorId(p, id) : null;
}

export function terminarTurno(p: Partida): Partida {
  if (p.fase !== 'turno') return p;
  const indice = p.intervaloMs ? p.cola.length : p.indice + 1;
  return indice >= p.cola.length ? { ...p, indice, fase: 'votacion' } : { ...p, indice };
}

export function lideres(p: Partida) {
  const max = Math.max(...Object.values(p.puntos));
  return p.mcs.filter((m) => p.puntos[m.id] === max).map((m) => m.id);
}

function nuevaRonda(p: Partida, ronda: number, cola: string[], extra: Partial<Partida>): Partida {
  return { ...p, ronda, cola, indice: 0, fase: 'turno', replica: false, desempate: false, ...extra };
}

function cerrarRonda(p: Partida, ganador: string | null): Partida {
  const puntos = ganador ? { ...p.puntos, [ganador]: p.puntos[ganador]! + 1 } : p.puntos;
  const conResultado = { ...p, puntos, historial: [...p.historial, { ronda: p.ronda, ganador, replica: p.replica }] };
  if (p.desempate) return { ...conResultado, fase: 'final' };
  if (p.ronda < p.rondasTotales) return nuevaRonda(conResultado, p.ronda + 1, ordenDeRonda(p.mcs, p.ronda + 1), {});
  const empatados = lideres(conResultado);
  if (empatados.length > 1) return nuevaRonda(conResultado, p.ronda + 1, empatados, { desempate: true });
  return { ...conResultado, fase: 'final' };
}

export function votar(p: Partida, elegidos: string[]): Partida {
  if (p.fase !== 'votacion') return p;
  const validos = [...new Set(elegidos)].filter((id) => p.cola.includes(id));
  if (validos.length === 1) return cerrarRonda(p, validos[0]!);
  if (validos.length > 1 && !p.replica) return { ...p, cola: validos, indice: 0, fase: 'turno', replica: true };
  return cerrarRonda(p, null);
}

export function ganadores(p: Partida) {
  if (p.fase !== 'final') return [];
  const ids = lideres(p);
  return ids.length === 1 ? ids : [];
}

export function clasificacion(p: Partida) {
  return [...p.mcs].sort((a, b) => p.puntos[b.id]! - p.puntos[a.id]!);
}
