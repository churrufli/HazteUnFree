import { useFonts } from 'expo-font';
import { Stack } from 'expo-router';
import * as SplashScreen from 'expo-splash-screen';
import { StatusBar } from 'expo-status-bar';
import { useEffect } from 'react';
import { KeyboardProvider } from 'react-native-keyboard-controller';
import { SafeAreaProvider } from 'react-native-safe-area-context';

import { ProveedorAjustes, useAjustes } from '@/estado/Ajustes';
import { ProveedorSesion } from '@/estado/Sesion';
import { DialogProvider } from '@/ui/Dialogo';
import { paleta } from '@/ui/tema';

SplashScreen.preventAutoHideAsync();
if (typeof document !== 'undefined') document.body.style.backgroundColor = paleta.fondo;

function Navegacion() {
  const { cargado } = useAjustes();

  useEffect(() => {
    if (cargado) SplashScreen.hideAsync();
  }, [cargado]);

  if (!cargado) return null;

  return (
    <Stack
      screenOptions={{
        headerShown: false,
        animation: 'slide_from_right',
        contentStyle: { backgroundColor: paleta.fondo, width: '100%', maxWidth: 560, alignSelf: 'center' },
      }}
    >
      <Stack.Screen name="bienvenida" options={{ animation: 'fade' }} />
      <Stack.Screen name="ronda" options={{ animation: 'fade', gestureEnabled: false }} />
      <Stack.Screen name="pase" options={{ animation: 'fade', gestureEnabled: false }} />
      <Stack.Screen name="votacion" options={{ animation: 'fade', gestureEnabled: false }} />
      <Stack.Screen name="marcador" options={{ animation: 'fade' }} />
      <Stack.Screen name="resultado" options={{ animation: 'fade' }} />
    </Stack>
  );
}

export default function Raiz() {
  const [fuentes, error] = useFonts({
    Anton: require('../../assets/fonts/Anton.ttf'),
    Inter_400Regular: require('../../assets/fonts/Inter_400Regular.ttf'),
    Inter_600SemiBold: require('../../assets/fonts/Inter_600SemiBold.ttf'),
    Inter_700Bold: require('../../assets/fonts/Inter_700Bold.ttf'),
    'Phosphor-Fill': require('../../assets/fonts/Phosphor-Fill.ttf'),
  });

  useEffect(() => {
    if (error) SplashScreen.hideAsync();
  }, [error]);

  if (!fuentes && !error) return null;

  return (
    <SafeAreaProvider>
      <KeyboardProvider>
          <ProveedorAjustes>
            <ProveedorSesion>
              <DialogProvider>
                <StatusBar style="light" />
                <Navegacion />
              </DialogProvider>
            </ProveedorSesion>
          </ProveedorAjustes>
      </KeyboardProvider>
    </SafeAreaProvider>
  );
}
