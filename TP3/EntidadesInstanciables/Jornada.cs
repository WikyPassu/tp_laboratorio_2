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

        private Jornada()
        {
            this.alumnos = new List<Alumno>(); 
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        
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

        public static string Leer()
        {
            string jornadaCargada = null;
            Texto datosJornada = new Texto();

            datosJornada.Leer(AppDomain.CurrentDomain.BaseDirectory + @"Jornada.txt", out jornadaCargada);

            return jornadaCargada;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

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
