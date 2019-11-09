using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesExcepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor de la excepcion de archivos.
        /// </summary>
        /// <param name="innerException">Una excepcion.</param>
        public ArchivosException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }
    }
}
