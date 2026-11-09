import type { Disparo, Formato } from './formatos';

export type FuenteMusica = 'externa' | 'acapella';

export interface ConfigRonda {
  formato: Formato;
  duracionMs: number;
  disparo: Disparo;
  musica: FuenteMusica;
  diccionarios: string[];
}

export const configPorDefecto: ConfigRonda = {
  formato: 'easy',
  duracionMs: 60_000,
  disparo: 'auto',
  musica: 'externa',
  diccionarios: ['general'],
};

export function leerConfig(json: string | undefined): ConfigRonda {
  if (!json) return configPorDefecto;
  try {
    const leida = JSON.parse(json) as Partial<ConfigRonda>;
    const musica = leida.musica === 'acapella' ? 'acapella' : 'externa';
    const disparo = leida.disparo === 'manual' ? 'manual' : 'auto';
    return { ...configPorDefecto, ...leida, musica, disparo };
  } catch {
    return configPorDefecto;
  }
}
