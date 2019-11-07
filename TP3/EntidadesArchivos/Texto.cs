using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using EntidadesExcepciones;

namespace EntidadesArchivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda cualquier tipo de dato en un archivo de texto en la ruta pasada como parametro.
        /// </summary>
        /// <param name="archivo">Ruta al archivo.</param>
        /// <param name="datos">Lo que se quiere guardar como texto.</param>
        /// <returns>Devuelve true si se pudo guardar, false caso contrario.</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter escritor = new StreamWriter(archivo))
                {
                    escritor.WriteLine(datos);
                    retorno = true;
                }
            }
            catch (Exception error)
            {
                throw new ArchivosException(error);
            }

            return retorno;
        }

        /// <summary>
        /// Lee los datos de un archivo de texto en la ruta pasada como parametro y los carga en una variable string.
        /// </summary>
        /// <param name="archivo">Ruta al archivo.</param>
        /// <param name="datos">Lo que se quiere leer.</param>
        /// <returns>Devuelve true si se pudo leer, false caso contrario.</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            datos = null;

            try
            {
                using (StreamReader lector = new StreamReader(archivo))
                {
                    datos = lector.ReadToEnd();
                    retorno = true;
                }
            }
            catch (Exception error)
            {
                throw new ArchivosException(error);
            }

            return retorno;
        }
    }
}
