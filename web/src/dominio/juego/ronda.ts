import type { ConfigRonda } from './config';
import { programa, proximaTanda, tandasVencidas } from './formatos';
import { arrancar, pausar, relojNuevo, transcurrido, type Reloj } from './reloj';

export type FaseRonda = 'preparando' | 'jugando' | 'pausa' | 'fin';

export interface EstadoRonda {
  config: ConfigRonda;
  fase: FaseRonda;
  ahora: number;
  reloj: Reloj;
  plan: number[];
  mostradas: number;
  pendientes: number;
  tanda: string[];
  usadas: string[];
}

export type AccionRonda =
  | { tipo: 'empezar'; ahora: number }
  | { tipo: 'tic'; ahora: number }
  | { tipo: 'pausar'; ahora: number }
  | { tipo: 'reanudar'; ahora: number }
  | { tipo: 'terminar'; ahora: number }
  | { tipo: 'pedirTanda' }
  | { tipo: 'tanda'; palabras: string[] };

export function rondaInicial(config: ConfigRonda, ahora: number): EstadoRonda {
  return {
    config,
    fase: 'preparando',
    ahora,
    reloj: relojNuevo(),
    plan: config.disparo === 'auto' ? programa(config.formato, config.duracionMs) : [],
    mostradas: 0,
    pendientes: 0,
    tanda: [],
    usadas: [],
  };
}

export function ronda(e: EstadoRonda, a: AccionRonda): EstadoRonda {
  switch (a.tipo) {
    case 'empezar':
      return e.fase === 'preparando' ? { ...e, fase: 'jugando', ahora: a.ahora, reloj: arrancar(e.reloj, a.ahora) } : e;
    case 'tic': {
      if (e.fase !== 'jugando') return e;
      const t = transcurrido(e.reloj, a.ahora);
      if (t >= e.config.duracionMs) return { ...e, ahora: a.ahora, fase: 'fin', reloj: pausar(e.reloj, a.ahora) };
      const vencidas = tandasVencidas(e.plan, t);
      return vencidas > e.mostradas
        ? { ...e, ahora: a.ahora, mostradas: vencidas, pendientes: e.pendientes + 1 }
        : { ...e, ahora: a.ahora };
    }
    case 'pausar':
      return e.fase === 'jugando' ? { ...e, fase: 'pausa', ahora: a.ahora, reloj: pausar(e.reloj, a.ahora) } : e;
    case 'reanudar':
      return e.fase === 'pausa' ? { ...e, fase: 'jugando', ahora: a.ahora, reloj: arrancar(e.reloj, a.ahora) } : e;
    case 'terminar':
      return e.fase === 'fin' ? e : { ...e, fase: 'fin', ahora: a.ahora, reloj: pausar(e.reloj, a.ahora) };
    case 'pedirTanda':
      return e.fase === 'jugando' && e.config.disparo === 'manual' ? { ...e, pendientes: e.pendientes + 1 } : e;
    case 'tanda':
      return {
        ...e,
        pendientes: Math.max(0, e.pendientes - 1),
        tanda: a.palabras,
        usadas: [...e.usadas, ...a.palabras],
      };
  }
}

export function restante(e: EstadoRonda) {
  return Math.max(0, e.config.duracionMs - transcurrido(e.reloj, e.ahora));
}

export function progresoSiguiente(e: EstadoRonda) {
  if (e.fase !== 'jugando' && e.fase !== 'pausa') return null;
  const t = transcurrido(e.reloj, e.ahora);
  const s = proximaTanda(e.plan, t);
  if (!s) return null;
  const anterior = s.indice > 0 ? e.plan[s.indice - 1]! : Math.max(0, t - 1);
  const intervalo = e.plan[s.indice]! - anterior;
  return intervalo > 0 ? Math.min(1, Math.max(0, 1 - s.enMs / intervalo)) : null;
}

export function siguienteEnMs(e: EstadoRonda) {
  if (e.fase !== 'jugando' && e.fase !== 'pausa') return null;
  return proximaTanda(e.plan, transcurrido(e.reloj, e.ahora))?.enMs ?? null;
}
