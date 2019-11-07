using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesArchivos
{
    interface IArchivo<T>
    {
        /// <summary>
        /// Firma del metodo Guardar.
        /// </summary>
        /// <param name="archivo">Ruta al archivo.</param>
        /// <param name="datos">Lo que se quiere guardar.</param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Firma del metodo Leer.
        /// </summary>
        /// <param name="archivo">Ruta al archivo.</param>
        /// <param name="datos">Lo que se quiere leer.</param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);
    }
}
