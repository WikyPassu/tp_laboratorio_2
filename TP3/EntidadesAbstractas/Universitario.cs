using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
        {
            this.legajo = 0;
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            return obj is Universitario && this is Universitario;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendFormat(base.ToString());
            datos.AppendFormat("\nLEGAJO NÚMERO: {0}\n", this.legajo);
            return datos.ToString();
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (pg1.Equals(pg2) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
