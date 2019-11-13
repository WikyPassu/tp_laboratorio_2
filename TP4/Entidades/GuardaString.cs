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
