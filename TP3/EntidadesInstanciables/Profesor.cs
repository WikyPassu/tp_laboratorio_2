using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// Constructor estatico de la clase profesor que instancia el atributo random.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor por defecto de la clase profesor..
        /// </summary>
        public Profesor()
            : this(1, "Sin nombre", "Sin apellido", "1", ENacionalidad.Argentino)
        {
        }

        /// <summary>
        /// Sobrecarga del constructor de la clase profesor. Instancia los datos pasados como parametro y las clases de manera random que da el profesor.
        /// </summary>
        /// <param name="id">ID del profesor.</param>
        /// <param name="nombre">Nombre del profesor.</param>
        /// <param name="apellido">Apellido del profesor.</param>
        /// <param name="dni">DNI del profesor.</param>
        /// <param name="nacionalidad">Nacionalidad del profesor.</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Genera dos clases de manera random para un profesor.
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            }
        }

        /// <summary>
        /// Le da formato a las clases que da en el dia un profesor.
        /// </summary>
        /// <returns>Devuelve las clases que da en el dia un profesor con formato.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder clases = new StringBuilder();

            clases.AppendLine("CLASES DEL DÍA:");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                clases.AppendLine(clase.ToString());
            }

            return clases.ToString();
        }

        /// <summary>
        /// Le da formato a los datos de un profesor.
        /// </summary>
        /// <returns>Devuelve los datos de un profesor con formato.</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }

        /// <summary>
        /// Devuelve los datos de un profesor.
        /// </summary>
        /// <returns>Devuelve los datos de un profesor con formato.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Verifica si un profesor da una clase.
        /// </summary>
        /// <param name="i">Un profesor.</param>
        /// <param name="clase">Una clase.</param>
        /// <returns>Devuelve true si el profesor da la clase, false caso contrario.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            if (!Object.Equals(i, null))
            {
                foreach (Universidad.EClases unaClase in i.clasesDelDia)
                {
                    if (unaClase == clase)
                    {
                        retorno = true;
                        break;
                    }
                }
            }

            return retorno;
        }

        /// <summary>
        /// Verifica si un profesor no da una clase.
        /// </summary>
        /// <param name="i">Un profesor.</param>
        /// <param name="clase">Una clase.</param>
        /// <returns>Devuelve true si el profesor no da la clase, false caso contrario.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
