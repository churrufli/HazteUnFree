export interface Ajustes {
  bienvenidaVista: boolean;
  bocinaFinal: boolean;
  pantallaEncendida: boolean;
}

export const ajustesPorDefecto: Ajustes = {
  bienvenidaVista: false,
  bocinaFinal: true,
  pantallaEncendida: true,
};

export function deFilas(filas: Record<string, string>): Ajustes {
  const bool = (clave: keyof Ajustes) =>
    filas[clave] === undefined ? ajustesPorDefecto[clave] : filas[clave] === '1';
  return {
    bienvenidaVista: bool('bienvenidaVista'),
    bocinaFinal: bool('bocinaFinal'),
    pantallaEncendida: bool('pantallaEncendida'),
  };
}

export const aFila = (valor: boolean) => (valor ? '1' : '0');
