import { Asset } from 'expo-asset';
import { useCallback, useRef } from 'react';

export function useBocina() {
  const audio = useRef<HTMLAudioElement | null>(null);
  return useCallback(() => {
    audio.current ??= Object.assign(new Audio(Asset.fromModule(require('../../assets/sonidos/bocina.mp3')).uri), { volume: 0.7 });
    audio.current.currentTime = 0;
    audio.current.play().catch(() => {});
  }, []);
}
