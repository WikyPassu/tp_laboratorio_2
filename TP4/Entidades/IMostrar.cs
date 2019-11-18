using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar<T>
    {
        /// <summary>
        /// Firma del metodo MostrarDatos. En su implementacion mostrara los datos de un objeto.
        /// </summary>
        /// <param name="elemento">Un objeto.</param>
        /// <returns>Retorna datos de un objeto.</returns>
        string MostrarDatos(IMostrar<T> elemento);
    }
}
