using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesExcepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor de la excepcion alumno repetido.
        /// </summary>
        public AlumnoRepetidoException()
            : base("Alumno repetido.")
        {
        }
    }
}
