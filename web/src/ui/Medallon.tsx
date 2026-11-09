import { Image } from 'react-native';

export function Medallon({ tam }: { tam: number }) {
  return (
    <Image
      source={require('../../assets/splash-icon.png')}
      style={{ width: tam, height: tam }}
      accessibilityIgnoresInvertColors
      accessible={false}
      importantForAccessibility="no"
    />
  );
}
