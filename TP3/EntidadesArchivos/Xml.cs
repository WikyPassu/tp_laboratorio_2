using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using EntidadesExcepciones;

namespace EntidadesArchivos
{
    public class Xml<T> : IArchivo<T>
    {
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
            catch(ArchivosException error)
            {
                Console.WriteLine(error.Message);
                retorno = false;
            }

            return retorno;
        }

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
            catch (ArchivosException error)
            {
                Console.WriteLine(error.Message);
                retorno = false;
            }

            return retorno;
        }
    }
}
