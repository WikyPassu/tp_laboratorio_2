using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EntidadesArchivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        /// <summary>
        /// Propiedad de lectura y escritura de la lista de alumnos de una jornada.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = new List<Alumno>(value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la clase de una jornada.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del profesor de una jornada.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        /// <summary>
        /// Constructor por defecto de una jornada. Instancia la lista de alumnos de una jornada.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>(); 
        }

        /// <summary>
        /// Sobrecarga del constructor de una jornada. Instancia los datos de una jornada pasados como parametro.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        
        /// <summary>
        /// Le da formato a los datos de una jornada.
        /// </summary>
        /// <returns>Devuelve los datos de un jornada con formato.</returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.Append("CLASE DE " + this.Clase + " ");
            datos.AppendLine("POR " + this.Instructor.ToString());
            datos.AppendLine("ALUMNOS:");
            foreach (Alumno alumno in this.Alumnos)
            {
                datos.Append(alumno.ToString());
            }
            datos.AppendLine("<------------------------------------------------>");

            return datos.ToString();
        }

        /// <summary>
        /// Guarda los datos de una jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada">Una jornada.</param>
        /// <returns>Devuelve true si se pudo guardar, false caso contrario.</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            Texto datosJornada = new Texto();

            if (datosJornada.Guardar(AppDomain.CurrentDomain.BaseDirectory + @"\Jornada.txt", jornada.ToString()))
            {
                retorno = true;
            }
            
            return retorno;
        }

        /// <summary>
        /// Lee los datos de una jornada de un archivo de texto.
        /// </summary>
        /// <returns>Devuelve los datos de la jornada.</returns>
        public static string Leer()
        {
            string jornadaCargada = "";
            Texto datosJornada = new Texto();

            datosJornada.Leer(AppDomain.CurrentDomain.BaseDirectory + @"Jornada.txt", out jornadaCargada);

            return jornadaCargada;
        }

        /// <summary>
        /// Verifica si un alumno participa en la clase de una jornada.
        /// </summary>
        /// <param name="j">Una jornada.</param>
        /// <param name="a">Un alumno.</param>
        /// <returns>Devuelve true si el alumno participa en dicha clase de la jornada, false caso contrario.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            if (!Object.Equals(j, null) && !Object.Equals(a, null))
            {
                foreach (Alumno alumno in j.Alumnos)
                {
                    if (alumno == a)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            
            return retorno;
        }

        /// <summary>
        /// Verifica si un alumno no participa en la clase de una jornada.
        /// </summary>
        /// <param name="j">Una jornada.</param>
        /// <param name="a">Un alumno.</param>
        /// <returns>Devuelve true si el alumno no participa en dicha clase de la jornada, false caso contrario.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
    }
}
