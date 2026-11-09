export function leerTxt() {
  return new Promise<string | null>((resolver) => {
    const input = document.createElement('input');
    input.type = 'file';
    input.accept = '.txt,text/plain';
    input.onchange = () => {
      const f = input.files?.[0];
      if (f) f.text().then(resolver, () => resolver(null));
      else resolver(null);
    };
    input.click();
  });
}
