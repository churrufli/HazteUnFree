import { describe, expect, it } from 'vitest';

import { aFila, ajustesPorDefecto, deFilas } from '../ajustes';

describe('ajustes', () => {
  it('sin filas usa los valores por defecto', () => {
    expect(deFilas({})).toEqual(ajustesPorDefecto);
  });

  it('lee booleanos', () => {
    expect(deFilas({ bienvenidaVista: '1', bocinaFinal: '0' })).toMatchObject({
      bienvenidaVista: true,
      bocinaFinal: false,
      pantallaEncendida: true,
    });
  });

  it('serializa valores', () => {
    expect(aFila(true)).toBe('1');
    expect(aFila(false)).toBe('0');
  });
});
