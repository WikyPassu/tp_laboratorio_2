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

        /// <summary>
        /// Enumerado del tipo de estado de cuenta del alumno.
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        /// <summary>
        /// Constructor por defecto de la clase alumno. Instancia los datos por defecto de un alumno.
        /// </summary>
        public Alumno()
        {
            this.claseQueToma = Universidad.EClases.Laboratorio;
            this.estadoCuenta = EEstadoCuenta.AlDia;
        }

        /// <summary>
        /// Sobrecarga del constructor de la clase alumno. Instancia los datos de un alumno pasados como parametro.
        /// </summary>
        /// <param name="id">ID del alumno.</param>
        /// <param name="nombre">Nombre del alumno.</param>
        /// <param name="apellido">Apellido del alumno.</param>
        /// <param name="dni">DNI del alumno.</param>
        /// <param name="nacionalidad">Nacionalidad del alumno.</param>
        /// <param name="claseQueToma">Clase que toma el alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = EEstadoCuenta.AlDia;
        }

        /// <summary>
        /// Sobrecarga del constructor de la clase alumno. Instancia los datos de un alumno pasados como parametro.
        /// </summary>
        /// <param name="id">ID del alumno.</param>
        /// <param name="nombre">Nombre del alumno.</param>
        /// <param name="apellido">Apellido del alumno.</param>
        /// <param name="dni">DNI del alumno.</param>
        /// <param name="nacionalidad">Nacionalidad del alumno.</param>
        /// <param name="claseQueToma">Clase que toma el alumno.</param>
        /// <param name="estadoCuenta">Estado de la cuenta del alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Le da formato a la clase que toma el alumno.
        /// </summary>
        /// <returns>Devuelve la clase que toma el alumno con formato.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder clase = new StringBuilder();

            clase.AppendLine("TOMA CLASES DE " + this.claseQueToma);

            return clase.ToString();
        }

        /// <summary>
        /// Le da formato a los datos de un alumno.
        /// </summary>
        /// <returns>Devuelve los datos de un alumno con formato.</returns>
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

        /// <summary>
        /// Devuelve los datos de un alumno.
        /// </summary>
        /// <returns>Devuelve los datos de un alumno con formato.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Verifica si un alumno toma una clase.
        /// </summary>
        /// <param name="a">Un alumno.</param>
        /// <param name="clase">Una clase.</param>
        /// <returns>Devuelve true si el alumno toma la clase y no es deudor, false caso contrario.</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor; 
        }

        /// <summary>
        /// Verifica si un alumno no toma una clase.
        /// </summary>
        /// <param name="a">Un alumno.</param>
        /// <param name="clase">Una clase.</param>
        /// <returns>Devuelve true si el alumno no toma la clase, false caso contrario.</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }
    }
}
