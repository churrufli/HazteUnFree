/// <reference types="node" />
import { readdirSync, readFileSync, statSync } from 'node:fs';
import { join, relative } from 'node:path';
import { describe, expect, it } from 'vitest';

const raiz = join(__dirname, '..', '..');

function archivos(dir: string): string[] {
  return readdirSync(dir).flatMap((n) => {
    const ruta = join(dir, n);
    if (statSync(ruta).isDirectory()) return n === '__tests__' ? [] : archivos(ruta);
    return /\.tsx?$/.test(n) ? [ruta] : [];
  });
}

const fuentes = archivos(raiz).map((ruta) => ({ ruta: relative(raiz, ruta), codigo: readFileSync(ruta, 'utf8') }));

describe('reglas del proyecto', () => {
  it('no usa Alert.alert', () => {
    const malos = fuentes.filter((f) => /Alert\.alert/.test(f.codigo)).map((f) => f.ruta);
    expect(malos).toEqual([]);
  });

  it('solo tema.ts define colores', () => {
    const malos = fuentes
      .filter((f) => f.ruta !== join('ui', 'tema.ts') && /['"`](#[0-9a-fA-F]{3,8}|rgba?\()/.test(f.codigo))
      .map((f) => f.ruta);
    expect(malos).toEqual([]);
  });

  it('el scroll horizontal pasa por HScroll', () => {
    const malos = fuentes
      .filter((f) => f.ruta !== join('ui', 'componentes.tsx') && /\bhorizontal\b/.test(f.codigo))
      .map((f) => f.ruta);
    expect(malos).toEqual([]);
  });

  it('las pantallas no escriben tamaños de fuente a mano', () => {
    const malos = fuentes
      .filter((f) => f.ruta.startsWith('app') && /fontSize:\s*\d/.test(f.codigo))
      .map((f) => f.ruta);
    expect(malos).toEqual([]);
  });
});
