using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Constructor de la excepcion TrackingIdRepetidoException.
        /// </summary>
        /// <param name="mensaje">Mensaje personalizado para la excepcion.</param>
        public TrackingIdRepetidoException(string mensaje)
            : base(mensaje)
        {
        }

        /// <summary>
        /// Sobrecarga del constructor de la excepcion TrackingIdRepetidoException.
        /// </summary>
        /// <param name="mensaje">Mensaje personalizado para la excepcion.</param>
        /// <param name="inner">Una excepcion.</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner)
            : this(mensaje + " " + inner.Message)
        {
        }
    }
}
