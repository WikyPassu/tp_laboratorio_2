using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesExcepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeBase = "El DNI presenta un error de formato. ";

        /// <summary>
        /// Constructor por defecto de la excepcion dni invalido.
        /// </summary>
        public DniInvalidoException()
            : base(DniInvalidoException.mensajeBase)
        {
        }

        /// <summary>
        /// Sobrecarga del constructor de la excepcion dni invalido.
        /// </summary>
        /// <param name="e">Una excepcion.</param>
        public DniInvalidoException(Exception e)
            : this(DniInvalidoException.mensajeBase + e.Message)
        {
        }

        /// <summary>
        /// Sobrecarga del constructor de la excepcion dni invalido.
        /// </summary>
        /// <param name="message">Un mensaje personalizado para la excepcion.</param>
        public DniInvalidoException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Sobrecarga del constructor de la excepcion dni invalido.
        /// </summary>
        /// <param name="message">Un mensaje personalizado para la excepcion.</param>
        /// <param name="e">Una excepcion.</param>
        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        {
        }
    }
}
