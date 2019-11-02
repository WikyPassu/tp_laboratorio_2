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
            StringBuilder clase = new StringBuilder();

            clase.AppendLine("TOMA CLASES DE " + this.claseQueToma);

            return clase.ToString();
        }

        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine(base.MostrarDatos());
            if (this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                datos.AppendLine("ESTADO DE CUENTA: Cuota al día");
            }
            else
            {
                datos.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta);
            }
            datos.Append(this.ParticiparEnClase());

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
