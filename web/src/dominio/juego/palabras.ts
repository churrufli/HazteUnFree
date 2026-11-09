export interface Bolsa {
  orden: string[];
  pos: number;
  vueltas: number;
}

export function normalizar(texto: string) {
  return texto
    .split(/[\n,;]+/)
    .map((p) => p.trim())
    .filter((p) => p.length > 0 && p.length <= 40);
}

export function sinRepetir(palabras: string[]) {
  const vistas = new Set<string>();
  return palabras.filter((p) => {
    const clave = p.toLocaleLowerCase('es');
    if (vistas.has(clave)) return false;
    vistas.add(clave);
    return true;
  });
}

export function barajar<T>(lista: T[], azar: () => number = Math.random) {
  const copia = [...lista];
  for (let i = copia.length - 1; i > 0; i--) {
    const j = Math.floor(azar() * (i + 1));
    [copia[i], copia[j]] = [copia[j]!, copia[i]!];
  }
  return copia;
}

export const crearBolsa = (palabras: string[], azar?: () => number): Bolsa => ({
  orden: barajar(sinRepetir(palabras), azar),
  pos: 0,
  vueltas: 0,
});

export function sacar(bolsa: Bolsa, n: number, azar?: () => number): [string[], Bolsa] {
  if (bolsa.orden.length === 0 || n <= 0) return [[], bolsa];
  const salen: string[] = [];
  let b = bolsa;
  while (salen.length < n) {
    if (b.pos >= b.orden.length) b = { orden: barajar(b.orden, azar), pos: 0, vueltas: b.vueltas + 1 };
    salen.push(b.orden[b.pos]!);
    b = { ...b, pos: b.pos + 1 };
    if (salen.length >= b.orden.length) break;
  }
  return [salen, b];
}

export function semilla(n: number) {
  let s = n >>> 0;
  return () => {
    s = (s + 0x6d2b79f5) >>> 0;
    let t = s;
    t = Math.imul(t ^ (t >>> 15), t | 1);
    t ^= t + Math.imul(t ^ (t >>> 7), t | 61);
    return ((t ^ (t >>> 14)) >>> 0) / 4294967296;
  };
}
