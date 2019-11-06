using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesExcepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        public DniInvalidoException()
            : base("El DNI presenta un error de formato.")
        {
        }

        public DniInvalidoException(Exception e)
            : this(e.Message)
        {   
        }

        public DniInvalidoException(string message)
            : base(message)
        {
            this.mensajeBase = message;
        }

        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        {
            this.mensajeBase = message;
        }
    }
}
