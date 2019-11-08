using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesExcepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor por defecto de la excepcion nacionalidad invalida.
        /// </summary>
        public NacionalidadInvalidaException()
            : this("La nacionalidad no se condice con el número de DNI")
        {
        }

        /// <summary>
        /// Sobrecarga del constructor de la excepcion nacionalidad invalida.
        /// </summary>
        /// <param name="message">Un mensaje personalizado para la excepcion.</param>
        public NacionalidadInvalidaException(string message)
            : base(message)
        {
        }
    }
}
