export const buscarEnGoogle = (termino: string) =>
  window.open(`https://www.google.com/search?q=${encodeURIComponent(`${termino} definición`)}`, '_blank', 'noopener');
