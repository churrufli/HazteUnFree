import { createContext, useCallback, useContext, useMemo, useState, type ReactNode } from 'react';
import { Modal, Pressable, StyleSheet, View } from 'react-native';

import { T } from './componentes';
import { Icono, type NombreIcono } from './Icono';
import { anchoMaxDialogo, espacio, paleta, radio } from './tema';

export interface AccionDialogo {
  label: string;
  style?: 'default' | 'destructive' | 'cancel';
  onPress?: () => void;
}

export interface OpcionesDialogo {
  title: string;
  message?: string;
  icon?: NombreIcono;
  tone?: 'default' | 'danger';
  actions?: AccionDialogo[];
}

interface ContextoDialogo {
  show: (o: OpcionesDialogo) => void;
  hide: () => void;
}

const Contexto = createContext<ContextoDialogo | null>(null);

export function DialogProvider({ children }: { children: ReactNode }) {
  const [actual, setActual] = useState<OpcionesDialogo | null>(null);

  const hide = useCallback(() => setActual(null), []);
  const show = useCallback((o: OpcionesDialogo) => setActual(o), []);
  const valor = useMemo(() => ({ show, hide }), [show, hide]);

  const cerrar = useCallback(() => {
    const cancelar = actual?.actions?.find((a) => a.style === 'cancel');
    setActual(null);
    cancelar?.onPress?.();
  }, [actual]);

  const peligro = actual?.tone === 'danger';
  const acciones = actual?.actions?.length ? actual.actions : [{ label: 'Vale' }];
  const ordenadas = [...acciones.filter((a) => a.style === 'cancel'), ...acciones.filter((a) => a.style !== 'cancel')];

  return (
    <Contexto.Provider value={valor}>
      {children}
      <Modal
        visible={!!actual}
        transparent
        animationType="fade"
        statusBarTranslucent
        navigationBarTranslucent
        onRequestClose={cerrar}
      >
        <View style={estilos.contenedor}>
          <Pressable style={StyleSheet.absoluteFill} onPress={cerrar} accessibilityLabel="Cerrar" accessibilityRole="button">
            <View style={[StyleSheet.absoluteFill, { backgroundColor: paleta.velo }]} />
          </Pressable>
          {actual && (
            <View style={estilos.tarjeta} accessibilityViewIsModal>
              {actual.icon && (
                <View style={[estilos.icono, { backgroundColor: peligro ? paleta.peligroSuave : paleta.acentoSuave }]}>
                  <Icono nombre={actual.icon} tam={28} color={peligro ? paleta.peligro : paleta.acentoFuerte} />
                </View>
              )}
              <T v="subtitulo">{actual.title}</T>
              {actual.message && <T v="cuerpo" style={{ color: paleta.textoSecundario }}>{actual.message}</T>}
              <View style={estilos.acciones}>
                {ordenadas.map((a) => {
                  const destructiva = a.style === 'destructive';
                  const cancelar = a.style === 'cancel';
                  const color = destructiva ? paleta.peligro : cancelar ? paleta.textoSecundario : paleta.acentoFuerte;
                  return (
                    <Pressable
                      key={a.label}
                      accessibilityRole="button"
                      onPress={() => {
                        hide();
                        a.onPress?.();
                      }}
                      style={({ pressed }) => [
                        estilos.accion,
                        destructiva && { backgroundColor: paleta.peligroSuave },
                        pressed && { opacity: 0.85 },
                      ]}
                    >
                      {destructiva && <Icono nombre="trash" tam={18} color={color} />}
                      <T v="negrita" style={{ color }}>
                        {a.label}
                      </T>
                    </Pressable>
                  );
                })}
              </View>
            </View>
          )}
        </View>
      </Modal>
    </Contexto.Provider>
  );
}

export function useDialog() {
  const c = useContext(Contexto);
  if (!c) throw new Error('useDialog fuera de DialogProvider');
  return c;
}

export function useConfirm() {
  const { show } = useDialog();
  return useCallback(
    (o: { title: string; message?: string; confirmar: string; peligro?: boolean; icon?: NombreIcono }) =>
      new Promise<boolean>((resolver) => {
        show({
          title: o.title,
          message: o.message,
          icon: o.icon ?? (o.peligro ? 'warning' : 'question'),
          tone: o.peligro ? 'danger' : 'default',
          actions: [
            { label: 'Cancelar', style: 'cancel', onPress: () => resolver(false) },
            { label: o.confirmar, style: o.peligro ? 'destructive' : 'default', onPress: () => resolver(true) },
          ],
        });
      }),
    [show],
  );
}

const estilos = StyleSheet.create({
  contenedor: { flex: 1, alignItems: 'center', justifyContent: 'center', padding: espacio.xl },
  tarjeta: {
    width: '100%',
    maxWidth: anchoMaxDialogo,
    backgroundColor: paleta.superficie,
    borderRadius: radio.xl + 2,
    borderWidth: 1,
    borderColor: paleta.borde,
    padding: espacio.xl,
    gap: espacio.m,
  },
  icono: { width: 52, height: 52, borderRadius: radio.pildora, alignItems: 'center', justifyContent: 'center' },
  acciones: { flexDirection: 'row', justifyContent: 'flex-end', flexWrap: 'wrap', gap: espacio.s, marginTop: espacio.s },
  accion: {
    minHeight: 48,
    paddingHorizontal: espacio.l,
    borderRadius: radio.m,
    flexDirection: 'row',
    alignItems: 'center',
    gap: espacio.xs,
  },
});
