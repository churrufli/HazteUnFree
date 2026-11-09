import { router } from 'expo-router';
import { Fragment } from 'react';

import { diccionarioGeneral, diccionariosTematicos, type Diccionario } from '@/dominio/diccionarios';
import { useSesion } from '@/estado/Sesion';
import { Boton, BotonIcono, Cabecera, Fila, Pantalla, Seccion, Separador, T } from '@/ui/componentes';
import { Icono } from '@/ui/Icono';
import { paleta } from '@/ui/tema';

const cifra = (n: number) => n.toLocaleString('es-ES');

export default function Diccionarios() {
  const { config, cambiarConfig, propios } = useSesion();
  const elegidos = config.diccionarios;

  const alternar = (clave: string) =>
    cambiarConfig({ diccionarios: elegidos.includes(clave) ? elegidos.filter((c) => c !== clave) : [...elegidos, clave] });

  const filas = (ds: Diccionario[], editables = false) =>
    ds.map((d, i) => {
      const activo = elegidos.includes(d.clave);
      return (
        <Fragment key={d.clave}>
          {i > 0 && <Separador />}
          <Fila
            titulo={d.nombre}
            detalle={`${cifra(d.palabras.length)} palabras`}
            onPress={() => alternar(d.clave)}
            derecha={
              <>
                {editables && (
                  <BotonIcono
                    icono="gear"
                    etiqueta={`Editar ${d.nombre}`}
                    color={paleta.tenue}
                    onPress={() => router.push({ pathname: '/diccionario', params: { clave: d.clave } })}
                  />
                )}
                <Icono nombre="check" tam={22} color={activo ? paleta.exito : paleta.borde} etiqueta={activo ? 'Elegido' : 'Sin elegir'} />
              </>
            }
          />
        </Fragment>
      );
    });

  return (
    <Pantalla pie={<Boton texto="Crear diccionario" icono="plus" tipo="secundario" onPress={() => router.push('/diccionario')} />}>
      <Cabecera titulo="Diccionarios" onAtras={() => router.back()} />
      <T v="cuerpo" style={{ color: paleta.textoSecundario }}>
        Marca los que quieras usar en las rondas. Las palabras salen mezcladas y sin repetir. Si no marcas ninguno, se usa el General.
      </T>
      {propios.length > 0 && <Seccion titulo="Tuyos">{filas(propios, true)}</Seccion>}
      <Seccion titulo="General">{filas([diccionarioGeneral])}</Seccion>
      <Seccion titulo="Temáticos">{filas(diccionariosTematicos)}</Seccion>
    </Pantalla>
  );
}
