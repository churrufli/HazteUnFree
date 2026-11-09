function canal(v: number) {
  const c = v / 255;
  return c <= 0.03928 ? c / 12.92 : ((c + 0.055) / 1.055) ** 2.4;
}

export function luminancia(hex: string) {
  const limpio = hex.replace('#', '');
  if (!/^[0-9a-fA-F]{6}$/.test(limpio)) throw new Error(`Color no válido: ${hex}`);
  const [r, g, b] = [0, 2, 4].map((i) => canal(parseInt(limpio.slice(i, i + 2), 16)));
  return 0.2126 * r! + 0.7152 * g! + 0.0722 * b!;
}

export function contraste(a: string, b: string) {
  const [claro, oscuro] = [luminancia(a), luminancia(b)].sort((x, y) => y - x);
  return (claro! + 0.05) / (oscuro! + 0.05);
}
