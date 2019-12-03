using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        List<Producto> productos;
        private int espacioDisponible;

        public enum ETipo
        {
            Dulce,
            Leche,
            Snacks,
            Todos
        }

        #region "Constructores"
        /// <summary>
        /// Constructor del Changuito que inicializa la lista de productos
        /// </summary>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }

        /// <summary>
        /// Constructor del Changuito que inicializa el espacio disponible
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Changuito(int espacioDisponible)
            : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns>Retorna todos los Productos en el Changuito</returns>
        public override string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Retorna todos los Productos en el Changuito en formato string</returns>
        public static string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles\n", c.productos.Count, c.espacioDisponible);
            sb.AppendLine("");
            foreach (Producto v in c.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if(v is Snacks)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Dulce:
                        if(v is Dulce)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Leche:
                        if(v is Leche)
                        {
                            sb.AppendLine(v.Mostrar());
                        }   
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns>Retorna el objeto Changuito</returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            bool existe = false;

            if (!Object.Equals(c, null) && !Object.Equals(p, null))
            {
                if (c.espacioDisponible > c.productos.Count)
                {
                    foreach (Producto v in c.productos)
                    {
                        if (v == p)
                        {
                            existe = true;
                            break;
                        }
                    }
                    if (!existe)
                    {
                        c.productos.Add(p);
                    }
                }
            }
            
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns>Retorna el objeto Changuito</returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            if (!Object.Equals(c, null) && !Object.Equals(p, null))
            {
                if (c.productos.Count > 0)
                {
                    foreach (Producto v in c.productos)
                    {
                        if (v == p)
                        {
                            c.productos.Remove(v);
                            break;
                        }
                    }
                }
            }
            
            return c;
        }
        #endregion
    }
}
