using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesExcepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException()
            : base()
        {
        }

        public NacionalidadInvalidaException(string message)
            : base(message)
        {
        }
    }
}
