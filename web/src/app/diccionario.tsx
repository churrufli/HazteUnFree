import { router, useLocalSearchParams } from 'expo-router';
import { useState } from 'react';

import { normalizar, sinRepetir } from '@/dominio/juego/palabras';
import { useSesion } from '@/estado/Sesion';
import { leerTxt } from '@/lib/archivos';
import { Boton, Cabecera, Campo, Pantalla, T } from '@/ui/componentes';
import { useConfirm } from '@/ui/Dialogo';
import { paleta } from '@/ui/tema';

export default function EditarDiccionario() {
  const { clave } = useLocalSearchParams<{ clave?: string }>();
  const { propios, guardarPropio, borrarPropio, config, cambiarConfig } = useSesion();
  const confirmar = useConfirm();
  const actual = propios.find((d) => d.clave === clave);
  const [nombre, setNombre] = useState(actual?.nombre ?? '');
  const [texto, setTexto] = useState(actual?.palabras.join('\n') ?? '');
  const palabras = sinRepetir(normalizar(texto).map((p) => p.toLocaleLowerCase('es')));

  const importar = async () => {
    const leido = await leerTxt();
    if (leido) setTexto((t) => (t.trim() ? `${t}\n${leido}` : leido));
  };

  const guardar = () => {
    const nueva = actual?.clave ?? `propio-${Date.now()}`;
    guardarPropio({ clave: nueva, nombre: nombre.trim() || 'Mi diccionario', palabras });
    if (!actual) cambiarConfig({ diccionarios: [...config.diccionarios, nueva] });
    router.back();
  };

  const borrar = async () => {
    if (!actual) return;
    const ok = await confirmar({ title: `¿Borrar «${actual.nombre}»?`, message: 'Se pierden sus palabras.', confirmar: 'Borrar', peligro: true });
    if (!ok) return;
    borrarPropio(actual.clave);
    cambiarConfig({ diccionarios: config.diccionarios.filter((c) => c !== actual.clave) });
    router.back();
  };

  return (
    <Pantalla
      pie={
        <>
          <Boton texto="Guardar" icono="check" onPress={guardar} desactivado={palabras.length === 0} />
          {actual && <Boton texto="Borrar diccionario" icono="trash" tipo="peligro" onPress={borrar} />}
        </>
      }
    >
      <Cabecera titulo={actual ? 'Editar diccionario' : 'Crear diccionario'} onAtras={() => router.back()} />
      <Campo etiqueta="Nombre" value={nombre} onChangeText={setNombre} placeholder="Mi diccionario" maxLength={30} />
      <Campo
        etiqueta="Palabras"
        ayuda="Una por línea o separadas por comas. Las repetidas se quitan solas."
        value={texto}
        onChangeText={setTexto}
        placeholder={'barrio\nmicrófono\nplaza'}
        multiline
        textAlignVertical="top"
        style={{ minHeight: 220, paddingVertical: 12 }}
        autoCapitalize="none"
      />
      <T v="ayuda" style={{ color: paleta.textoSecundario }}>
        {palabras.length.toLocaleString('es-ES')} palabras
      </T>
      <Boton texto="Importar un TXT" icono="folder-open" tipo="secundario" onPress={importar} />
    </Pantalla>
  );
}
