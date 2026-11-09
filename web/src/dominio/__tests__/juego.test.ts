import { describe, expect, it } from 'vitest';

import { diccionarioGeneral, palabrasDe } from '../diccionarios';
import { intervaloEn, programa, proximaTanda, tandasVencidas } from '../juego/formatos';
import { crearBolsa, normalizar, sacar, semilla, sinRepetir } from '../juego/palabras';
import { arrancar, formatoReloj, pausar, relojNuevo, transcurrido } from '../juego/reloj';
import { clasificacion, crearPartida, ganadores, mcAlternando, siguienteMc, terminarTurno, turnoActual, votar, type Partida } from '../juego/turnos';

describe('formatos', () => {
  it('reparte las tandas de cada formato en un minuto', () => {
    expect(programa('easy', 60_000)).toEqual([0, 10_000, 20_000, 30_000, 40_000, 50_000]);
    expect(programa('hard', 60_000)).toHaveLength(12);
    expect(programa('extreme', 60_000)).toHaveLength(30);
    expect(programa('4x10', 60_000)).toHaveLength(6);
    expect(programa('libre', 60_000)).toEqual([]);
  });

  it('respeta la espera inicial', () => {
    expect(programa('easy', 60_000, 5_000)[0]).toBe(5_000);
  });

  it('el incremental acelera por tercios', () => {
    expect(intervaloEn('incremental', 0, 90_000)).toBe(10_000);
    expect(intervaloEn('incremental', 40_000, 90_000)).toBe(5_000);
    expect(intervaloEn('incremental', 70_000, 90_000)).toBe(2_000);
    const p = programa('incremental', 90_000);
    expect(p.slice(0, 3)).toEqual([0, 10_000, 20_000]);
    expect(p.at(-1)! - p.at(-2)!).toBe(2_000);
  });

  it('no saca una palabra en los últimos segundos', () => {
    expect(programa('easy', 61_000).at(-1)).toBe(50_000);
  });

  it('calcula la próxima tanda y las vencidas', () => {
    const p = [0, 10_000, 20_000];
    expect(proximaTanda(p, 4_000)).toEqual({ indice: 1, enMs: 6_000 });
    expect(proximaTanda(p, 25_000)).toBeNull();
    expect(tandasVencidas(p, 0)).toBe(1);
    expect(tandasVencidas(p, 15_000)).toBe(2);
  });
});

describe('reloj', () => {
  it('acumula tiempo con pausas', () => {
    let r = arrancar(relojNuevo(), 1_000);
    expect(transcurrido(r, 4_000)).toBe(3_000);
    r = pausar(r, 4_000);
    expect(transcurrido(r, 100_000)).toBe(3_000);
    r = arrancar(r, 100_000);
    expect(transcurrido(r, 101_000)).toBe(4_000);
  });

  it('formatea el tiempo restante', () => {
    expect(formatoReloj(59_100)).toBe('1:00');
    expect(formatoReloj(9_000)).toBe('09');
    expect(formatoReloj(80_000)).toBe('1:20');
    expect(formatoReloj(-5)).toBe('00');
  });
});

describe('palabras', () => {
  it('junta los diccionarios elegidos y si no hay ninguno usa el general', () => {
    const propio = { clave: 'propio-1', nombre: 'Mío', palabras: ['barrio', 'plaza'] };
    const disponibles = [propio, diccionarioGeneral];
    expect(palabrasDe(disponibles, ['propio-1'])).toEqual(['barrio', 'plaza']);
    expect(palabrasDe(disponibles, ['propio-1', 'general']).length).toBe(diccionarioGeneral.palabras.length + 2);
    expect(palabrasDe(disponibles, ['borrado'])).toEqual(diccionarioGeneral.palabras);
  });

  it('normaliza diccionarios por líneas o comas', () => {
    expect(normalizar('perro\r\ngato, sol;\n\n luna ')).toEqual(['perro', 'gato', 'sol', 'luna']);
    expect(sinRepetir(['Sol', 'sol', 'Luna'])).toEqual(['Sol', 'Luna']);
  });

  it('no repite hasta agotar la bolsa', () => {
    const azar = semilla(7);
    let bolsa = crearBolsa(['a', 'b', 'c', 'd'], azar);
    const vistas: string[] = [];
    for (let i = 0; i < 4; i++) {
      const [p, b] = sacar(bolsa, 1, azar);
      vistas.push(...p);
      bolsa = b;
    }
    expect(new Set(vistas).size).toBe(4);
    const [otra, b2] = sacar(bolsa, 1, azar);
    expect(otra).toHaveLength(1);
    expect(b2.vueltas).toBe(1);
  });

  it('saca tandas de cuatro', () => {
    const [p] = sacar(crearBolsa(['a', 'b', 'c', 'd', 'e'], semilla(1)), 4);
    expect(new Set(p).size).toBe(4);
  });

  it('no se cuelga con pocas palabras', () => {
    const [p] = sacar(crearBolsa(['a', 'b'], semilla(1)), 4);
    expect(p).toHaveLength(2);
    expect(sacar(crearBolsa([]), 1)[0]).toEqual([]);
  });
});

describe('turnos', () => {
  const mcs = [
    { id: 'a', nombre: 'Ana' },
    { id: 'b', nombre: 'Bea' },
    { id: 'c', nombre: 'Carla' },
  ];

  const jugarRonda = (p: Partida) => {
    while (p.fase === 'turno') p = terminarTurno(p);
    return p;
  };

  it('rota quién empieza cada ronda', () => {
    let p = crearPartida(mcs, 2);
    expect(turnoActual(p)?.nombre).toBe('Ana');
    expect(siguienteMc(p)?.nombre).toBe('Bea');
    p = votar(jugarRonda(p), ['a']);
    expect(p.ronda).toBe(2);
    expect(turnoActual(p)?.nombre).toBe('Bea');
  });

  it('un empate lleva a réplica solo de los empatados', () => {
    let p = votar(jugarRonda(crearPartida(mcs, 1)), ['a', 'c']);
    expect(p.replica).toBe(true);
    expect(p.cola).toEqual(['a', 'c']);
    p = votar(jugarRonda(p), ['c']);
    expect(p.fase).toBe('final');
    expect(ganadores(p)).toEqual(['c']);
    expect(p.historial).toEqual([{ ronda: 1, ganador: 'c', replica: true }]);
  });

  it('si la réplica vuelve a empatar, nadie puntúa', () => {
    let p = votar(jugarRonda(crearPartida(mcs, 2)), ['a', 'b']);
    p = votar(jugarRonda(p), ['a', 'b']);
    expect(p.ronda).toBe(2);
    expect(Object.values(p.puntos)).toEqual([0, 0, 0]);
  });

  it('empate final en puntos lleva a desempate', () => {
    let p = crearPartida(mcs.slice(0, 2), 2);
    p = votar(jugarRonda(p), ['a']);
    p = votar(jugarRonda(p), ['b']);
    expect(p.desempate).toBe(true);
    expect(p.fase).toBe('turno');
    p = votar(jugarRonda(p), ['b']);
    expect(p.fase).toBe('final');
    expect(ganadores(p)).toEqual(['b']);
    expect(clasificacion(p)[0]!.id).toBe('b');
  });

  it('alternando cambia de MC por tiempo y vota al acabar', () => {
    const p = crearPartida(mcs, 1, 20_000);
    expect(mcAlternando(p, 19_999).nombre).toBe('Ana');
    expect(mcAlternando(p, 20_000).nombre).toBe('Bea');
    expect(mcAlternando(p, 65_000).nombre).toBe('Ana');
    expect(terminarTurno(p).fase).toBe('votacion');
  });

  it('pide entre 2 y 8 MCs', () => {
    expect(() => crearPartida(mcs.slice(0, 1), 1)).toThrow();
  });
});
