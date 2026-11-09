import { describe, expect, it } from 'vitest';

import { configPorDefecto, leerConfig } from '../juego/config';
import { siguienteEnMs, restante, ronda, rondaInicial, type AccionRonda, type EstadoRonda } from '../juego/ronda';

const pasar = (e: EstadoRonda, ...acciones: AccionRonda[]) => acciones.reduce(ronda, e);

describe('ronda', () => {
  it('empieza al pulsar, juega y termina', () => {
    let e = rondaInicial(configPorDefecto, 0);
    e = pasar(e, { tipo: 'tic', ahora: 1_000 });
    expect(e.fase).toBe('preparando');
    e = pasar(e, { tipo: 'empezar', ahora: 3_000 });
    expect(e.fase).toBe('jugando');
    e = pasar(e, { tipo: 'tic', ahora: 3_100 });
    expect(e.pendientes).toBe(1);
    e = pasar(e, { tipo: 'tanda', palabras: ['SOL'] });
    expect(e.tanda).toEqual(['SOL']);
    expect(siguienteEnMs(e)).toBe(9_900);
    e = pasar(e, { tipo: 'tic', ahora: 13_100 });
    expect(e.pendientes).toBe(1);
    expect(restante(e)).toBe(49_900);
    e = pasar(e, { tipo: 'tic', ahora: 63_000 });
    expect(e.fase).toBe('fin');
  });

  it('la pausa congela el reloj', () => {
    let e = pasar(rondaInicial(configPorDefecto, 0), { tipo: 'empezar', ahora: 3_000 });
    e = pasar(e, { tipo: 'pausar', ahora: 13_000 }, { tipo: 'tic', ahora: 50_000 });
    expect(restante({ ...e, ahora: 50_000 })).toBe(50_000);
    e = pasar(e, { tipo: 'reanudar', ahora: 50_000 }, { tipo: 'tic', ahora: 60_000 });
    expect(restante(e)).toBe(40_000);
  });

  it('el manual saca palabra al tocar', () => {
    const config = { ...configPorDefecto, disparo: 'manual' as const };
    let e = pasar(rondaInicial(config, 0), { tipo: 'empezar', ahora: 3_000 }, { tipo: 'tic', ahora: 20_000 });
    expect(e.pendientes).toBe(0);
    e = pasar(e, { tipo: 'pedirTanda' });
    expect(e.pendientes).toBe(1);
  });

  it('lee la última configuración guardada', () => {
    expect(leerConfig(undefined)).toEqual(configPorDefecto);
    expect(leerConfig('{"formato":"hard"}').formato).toBe('hard');
    expect(leerConfig('roto')).toEqual(configPorDefecto);
    expect(leerConfig('{"musica":"instrumental"}').musica).toBe('externa');
    expect(leerConfig('{"musica":"acapella"}').musica).toBe('acapella');
  });
});
