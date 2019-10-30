using System;
using System.Collections.Generic;
using System.Text;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        static Profesor()
        {
            random = new Random();
        }

        public Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        private void _randomClases()
        {
            for (int i=0; i<2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            }
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder clases = new StringBuilder();

            clases.AppendLine("CLASES DEL DÍA:");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                clases.AppendFormat("{0}\n", clase);
            }

            return clases.ToString();
        }

        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach (Universidad.EClases unaClase in i.clasesDelDia)
            {
                if (unaClase == clase)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
