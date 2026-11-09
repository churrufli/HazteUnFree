// En la web todo se guarda en el localStorage del navegador.
const PREFIJO = 'hazteunfree:';

export async function leerAjustes(): Promise<Record<string, string>> {
  const filas: Record<string, string> = {};
  try {
    for (let i = 0; i < localStorage.length; i++) {
      const k = localStorage.key(i);
      if (k?.startsWith(PREFIJO)) filas[k.slice(PREFIJO.length)] = localStorage.getItem(k) ?? '';
    }
  } catch {}
  return filas;
}

export async function guardarAjuste(clave: string, valor: string) {
  try {
    localStorage.setItem(PREFIJO + clave, valor);
  } catch {}
}

export async function borrarTodo() {
  for (const k of Object.keys(await leerAjustes())) {
    try {
      localStorage.removeItem(PREFIJO + k);
    } catch {}
  }
}
