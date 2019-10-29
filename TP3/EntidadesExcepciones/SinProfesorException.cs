using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesExcepciones
{
    public class SinProfesorException : Exception
    {
        public SinProfesorException()
            : base("No hay profesor para la clase.")
        {
        }
    }
}
