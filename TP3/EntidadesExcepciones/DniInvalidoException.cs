using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesExcepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        public DniInvalidoException()
        {
            this.mensajeBase = "El DNI presenta un error de formato";
        }

        public DniInvalidoException(Exception e)
            : base(e.Message)
        {
        }

        public DniInvalidoException(string message)
            : base(message)
        {
        }

        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        {
        }
    }
}
