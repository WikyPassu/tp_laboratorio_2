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
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(string));
                using (TextWriter escritor = new StreamWriter(archivo))
                {
                    serializador.Serialize(escritor, datos);
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

        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            datos = null;

            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(string));
                using (TextReader lector = new StreamReader(archivo))
                {
                    datos = (string)serializador.Deserialize(lector);
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
