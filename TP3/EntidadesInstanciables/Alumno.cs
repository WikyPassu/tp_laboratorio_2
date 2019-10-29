using System;
using System.Collections.Generic;
using System.Text;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        public Alumno()
            : base()
        {
            this.claseQueToma = Universidad.EClases.Laboratorio;
            this.estadoCuenta = EEstadoCuenta.AlDia;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = EEstadoCuenta.AlDia;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASES DE {0}", this.claseQueToma);
        }

        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine(base.MostrarDatos());
            if (this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                datos.AppendFormat("ESTADO DE CUENTA: Cuota al día\n");
            }
            else
            {
                datos.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta);
            }
            datos.AppendLine(this.ParticiparEnClase());

            return datos.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor; 
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }
    }
}
