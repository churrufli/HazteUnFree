import { ToastAndroid } from 'react-native';

export const confirmarBreve = (texto: string) => ToastAndroid.show(texto, ToastAndroid.SHORT);
