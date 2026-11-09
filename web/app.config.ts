import type { ExpoConfig } from 'expo/config';

const FONDO = '#00151E';

const config: ExpoConfig = {
  name: 'HazteUnFree',
  slug: 'hazteunfree',
  scheme: 'hazteunfree',
  version: '0.1.0',
  orientation: 'portrait',
  icon: './assets/icon.png',
  userInterfaceStyle: 'dark',
  backgroundColor: FONDO,
  web: { favicon: './assets/favicon.png', output: 'single', name: 'HazteUnFree', backgroundColor: FONDO, themeColor: FONDO },
  plugins: ['expo-router', 'expo-font', 'expo-splash-screen', 'expo-status-bar'],
  experiments: { typedRoutes: true, baseUrl: process.env.BASE_URL ?? '' },
};

export default config;
