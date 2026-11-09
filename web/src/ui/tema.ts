export interface Paleta {
  fondo: string;
  superficie: string;
  superficieAlt: string;
  borde: string;
  texto: string;
  textoSecundario: string;
  tenue: string;
  placeholder: string;
  acento: string;
  acentoFuerte: string;
  textoSobreAcento: string;
  acentoSuave: string;
  dorado: string;
  doradoSuave: string;
  exito: string;
  exitoSuave: string;
  aviso: string;
  avisoSuave: string;
  peligro: string;
  peligroSuave: string;
  desactivado: string;
  textoDesactivado: string;
  banda: string;
  tinta: string;
  velo: string;
}

export const paleta: Paleta = {
  fondo: '#00151E',
  superficie: '#002738',
  superficieAlt: '#0A3346',
  borde: '#1E4A5E',
  texto: '#F8F8F8',
  textoSecundario: '#B8C7CF',
  tenue: '#8FA3AD',
  placeholder: '#8FA3AD',
  acento: '#E04F00',
  acentoFuerte: '#FF7A33',
  textoSobreAcento: '#110E15',
  acentoSuave: '#3A1A08',
  dorado: '#FFB202',
  doradoSuave: '#3A2C05',
  exito: '#3DDC84',
  exitoSuave: '#0F3A2A',
  aviso: '#FFB202',
  avisoSuave: '#3A2C05',
  peligro: '#FF7A7A',
  peligroSuave: '#3D1418',
  desactivado: '#1E3A48',
  textoDesactivado: '#8FA3AD',
  banda: '#F8F8F8',
  tinta: '#110E15',
  velo: 'rgba(0, 8, 12, 0.72)',
};

export const espacio = { xs: 4, s: 8, m: 12, l: 16, xl: 24, xxl: 32, margen: 20, toque: 56 };
export const radio = { s: 8, m: 12, l: 18, xl: 24, pildora: 999 };
export const fuente = { meta: 12, pequeña: 13, etiqueta: 14, cuerpo: 16, titulo: 17, cabecera: 20, display: 26, palabra: 56, reloj: 72 };

export const familia = {
  texto: 'Inter_400Regular',
  textoSemi: 'Inter_600SemiBold',
  textoNegrita: 'Inter_700Bold',
  display: 'Anton',
  iconos: 'Phosphor-Fill',
};

export const duracion = { corta: 150, media: 220, larga: 300 };
export const opacidadDecoracion = 0.12;
export const anchoMaxDialogo = 480;
