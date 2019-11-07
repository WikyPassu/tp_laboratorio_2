using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// Constructor por defecto de la clase universitario. Instancia el legajo y los datos por defecto de un universitario.
        /// </summary>
        public Universitario()
        {
            this.legajo = 0;
        }

        /// <summary>
        /// Sobrecarga del constructor de la clase universitario. Instancia el legajo y los datos de un universitario.
        /// </summary>
        /// <param name="legajo">Legajo del universitario.</param>
        /// <param name="nombre">Nombre del universitario.</param>
        /// <param name="apellido">Apellido del universitario.</param>
        /// <param name="dni">DNI del universitario.</param>
        /// <param name="nacionalidad">Nacionalidad del universitario.</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Firma del metodo abstracto que muestra las clases que se toman/dan.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Sobrecarga del metodo Equals() que compara los tipos de dato de dos objetos.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Devuelve true si ambos objetos son del mismo tipo, false caso contrario.</returns>
        public override bool Equals(object obj)
        {
            return obj.GetType() == this.GetType();
        }

        /// <summary>
        /// Le da formato a los datos de un universitario.
        /// </summary>
        /// <returns>Devuelve los datos de un universitario con formato.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine(base.ToString());
            datos.AppendLine("LEGAJO NÚMERO: " + this.legajo);

            return datos.ToString();
        }

        /// <summary>
        /// Verifica si dos universitarios son iguales.
        /// </summary>
        /// <param name="pg1">Un universitario.</param>
        /// <param name="pg2">Otro universitario.</param>
        /// <returns>Devuelve true si son iguales, false caso contrario.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if (!Object.Equals(pg1, null) && !Object.Equals(pg2, null))
            {
                if (pg1.Equals(pg2))
                {
                    if (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
                    {
                        retorno = true;
                    }
                }
            }
            
            return retorno;
        }

        /// <summary>
        /// Verifica si dos universitarios son diferentes.
        /// </summary>
        /// <param name="pg1">Un universitario.</param>
        /// <param name="pg2">Otro universitario.</param>
        /// <returns>Devuelve true si son diferentes, false caso contrario.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
