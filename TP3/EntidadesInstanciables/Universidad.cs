using System;
using System.Collections.Generic;
using System.Text;
using EntidadesExcepciones;
using EntidadesArchivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornada;
        
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
        
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = new List<Profesor>(value);
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = new List<Jornada>(value);
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine("JORNADA:");
            foreach (Jornada jornada in uni.Jornadas)
            {
                datos.AppendLine(jornada.ToString());
            }
            return datos.ToString();
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            Xml<Universidad> archivoGuardado = new Xml<Universidad>();

            if (archivoGuardado.Guardar(AppDomain.CurrentDomain.BaseDirectory + @"\Universidad.xml", uni))
            {
                retorno = true;
            }

            return retorno;
        }

        public static Universidad Leer()
        {
            Universidad universidadCargada = null;
            Xml<Universidad> archivoCargado = new Xml<Universidad>();

            archivoCargado.Leer(AppDomain.CurrentDomain.BaseDirectory + @"\Universidad.xml", out universidadCargada);

            return universidadCargada;
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
       }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == i)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor instructor = null;

            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == clase)
                {
                    instructor = profesor;
                    break;
                }
            }

            if (Object.Equals(instructor, null))
            {
                throw new SinProfesorException();
            }

            return instructor;
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor instructor = null;

            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                {
                    instructor = profesor;
                    break;
                }
            }
            
            return instructor;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada nuevaJornada = new Jornada(clase, g == clase);

            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                {
                    nuevaJornada.Alumnos.Add(alumno);
                }
            }
            if (nuevaJornada.Alumnos.Count > 0)
            {
                g.Jornadas.Add(nuevaJornada);
            }

            return g;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }
    }
}
