using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesExcepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }
    }
}
