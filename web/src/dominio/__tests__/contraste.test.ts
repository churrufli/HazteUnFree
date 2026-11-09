import { describe, expect, it } from 'vitest';

import { paleta } from '../../ui/tema';
import { contraste } from '../contraste';

const fondos = { fondo: paleta.fondo, superficie: paleta.superficie, superficieAlt: paleta.superficieAlt };

const textos = [
  paleta.texto,
  paleta.textoSecundario,
  paleta.tenue,
  paleta.placeholder,
  paleta.acentoFuerte,
  paleta.dorado,
  paleta.exito,
  paleta.aviso,
  paleta.peligro,
];

describe('contraste', () => {
  it('calcula el máximo entre blanco y negro', () => {
    expect(contraste('#FFFFFF', '#000000')).toBeCloseTo(21, 0);
  });

  it.each(Object.entries(fondos))('textos sobre %s ≥ 4.5', (_, fondo) => {
    for (const t of textos) expect(contraste(t, fondo), `${t} sobre ${fondo}`).toBeGreaterThanOrEqual(4.5);
  });

  it('pares sobre fondos de color ≥ 4.5', () => {
    const pares: [string, string][] = [
      [paleta.textoSobreAcento, paleta.acento],
      [paleta.tinta, paleta.banda],
      [paleta.peligro, paleta.peligroSuave],
      [paleta.acentoFuerte, paleta.acentoSuave],
      [paleta.dorado, paleta.doradoSuave],
      [paleta.exito, paleta.exitoSuave],
      [paleta.textoDesactivado, paleta.desactivado],
      [paleta.tinta, paleta.dorado],
    ];
    for (const [t, f] of pares) expect(contraste(t, f), `${t} sobre ${f}`).toBeGreaterThanOrEqual(4.5);
  });

  it('elementos activos ≥ 3', () => {
    for (const f of Object.values(fondos)) {
      expect(contraste(paleta.acento, f)).toBeGreaterThanOrEqual(3);
      expect(contraste(paleta.banda, f)).toBeGreaterThanOrEqual(3);
    }
  });
});
