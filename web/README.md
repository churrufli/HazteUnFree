# HazteUnFree web

Versión web de HazteUnFree para entrenar freestyle desde el navegador, tú solo o por turnos.
Se publica en GitHub Pages: https://churrufli.github.io/HazteUnFree/

- Mismos formatos, diccionarios (General, temáticos y los tuyos) y modo por turnos que la app móvil.
- La música la pone cada uno: en otra pestaña, en Spotify, en un altavoz Bluetooth… La web no reproduce ni controla música.
- Todo se guarda en el navegador (localStorage): sin cuentas, sin anuncios, sin analítica.

## Desarrollo

```
npm ci
npx expo start --web   # en local
npm run check          # typecheck, lint y tests
```

Cada push a `master` que toque `web/` compila y publica la web con `.github/workflows/web.yml`.
