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
                using (StreamWriter escritor = new StreamWriter(archivo))
                {
                    escritor.WriteLine(datos);
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
                using (StreamReader lector = new StreamReader(archivo))
                {
                    datos = lector.ReadToEnd();
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
