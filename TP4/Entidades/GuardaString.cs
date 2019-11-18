using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda el texto pasado como parametro en un archivo .txt en el escritorio de la maquina.
        /// </summary>
        /// <param name="texto">Texto a guardar.</param>
        /// <param name="archivo">Nombre del archivo.</param>
        /// <returns>Retorna true si se pudo guardar, false caso contrario.</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter escritor = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo, true))
                {
                    escritor.WriteLine(texto);
                    retorno = true;
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Error al guardar archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retorno;
        }
    }
}
