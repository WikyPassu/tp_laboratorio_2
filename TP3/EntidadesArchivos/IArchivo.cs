using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesArchivos
{
    interface IArchivo<T>
    {
        bool Guardar(string archivo, T datos);

        bool Leer(string archivo, out T datos);
    }
}
