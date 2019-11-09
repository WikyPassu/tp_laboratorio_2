using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using EntidadesExcepciones;

namespace EntidadesArchivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa cualquier tipo de dato en un archivo .xml en la ruta pasada como parametro.
        /// </summary>
        /// <param name="archivo">Ruta al archivo.</param>
        /// <param name="datos">Lo que se quiere serializar.</param>
        /// <returns>Devuelve true si se pudo guardar, false caso contrario.</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(T));
                using (TextWriter escritor = new StreamWriter(archivo))
                {
                    serializador.Serialize(escritor, datos);
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
        /// Deserializa cualquier tipo de dato en un archivo .xml en la ruta pasada como parametro y los carga en una variable de cualquier tipo.
        /// </summary>
        /// <param name="archivo">Ruta al archivo.</param>
        /// <param name="datos">Lo que se quiere deserializar.</param>
        /// <returns>Devuelve true si se pudo leer, false caso contrario.</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            datos = default(T);

            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(T));
                using (TextReader lector = new StreamReader(archivo))
                {
                    datos = (T)serializador.Deserialize(lector);
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
