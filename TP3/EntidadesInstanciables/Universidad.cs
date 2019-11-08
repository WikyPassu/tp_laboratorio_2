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
        
        /// <summary>
        /// Propiedad de lectura y escritura de la lista de alumnos de una universidad.
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
        /// Propiedad de lectura y escritura de la lista de profesores de una universidad.
        /// </summary>
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

        /// <summary>
        /// Propiedad de lectura y escritura de la lista de jornadas de una universidad.
        /// </summary>
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

        /// <summary>
        /// Indexador de lectura y escritura de la lista de jornadas de una universidad.
        /// </summary>
        /// <param name="i">Indice de la lista de jornadas de la universidad.</param>
        /// <returns>Devuelve la jornada en dicho indice.</returns>
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

        /// <summary>
        /// Enumerado de las clases que se dictan en una universidad.
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        /// <summary>
        /// Constructor por defecto de la clase universidad. Instancia las listas de alumnos, jornadas y profesores.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        /// <summary>
        /// Le da formato a los datos de una universidad.
        /// </summary>
        /// <param name="uni">Una universidad.</param>
        /// <returns>Devuelve los datos de una universidad con formato.</returns>
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

        /// <summary>
        /// Devuelve los datos de una universidad.
        /// </summary>
        /// <returns>Devuelve los datos de una universidad con formato.</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Serializa los datos de una universidad en un archivo .xml
        /// </summary>
        /// <param name="uni">Una universidad.</param>
        /// <returns>Devuelve true si se pudo serializar, false caso contrario.</returns>
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

        /// <summary>
        /// Deserializa los datos de una universidad de un archivo .xml
        /// </summary>
        /// <returns>Devuelve una universidad con dichos datos.</returns>
        public static Universidad Leer()
        {
            Universidad universidadCargada = null;
            Xml<Universidad> archivoCargado = new Xml<Universidad>();

            archivoCargado.Leer(AppDomain.CurrentDomain.BaseDirectory + @"\Universidad.xml", out universidadCargada);

            return universidadCargada;
        }

        /// <summary>
        /// Verifica si un alumno esta inscripto en una universidad.
        /// </summary>
        /// <param name="g">Una universidad.</param>
        /// <param name="a">Un alumno.</param>
        /// <returns>Devuelve true si el alumno esta inscripto en la universidad, false caso contrario.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            if (!Object.Equals(g, null) && !Object.Equals(a, null))
            {
                foreach (Alumno alumno in g.Alumnos)
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
        /// Verifica si un alumno no esta inscripto en una universidad.
        /// </summary>
        /// <param name="g">Una universidad.</param>
        /// <param name="a">Un alumno.</param>
        /// <returns>Devuelve true si el alumno no esta inscripto en la universidad, false caso contrario.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Verifica si un profesor esta dando clases en una universidad.
        /// </summary>
        /// <param name="g">Una universidad.</param>
        /// <param name="i">Un profesor.</param>
        /// <returns>Devuelve true si el profesor da clases en la universidad, false caso contrario</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            if (!Object.Equals(g, null) && !Object.Equals(i, null))
            {
                foreach (Profesor profesor in g.Instructores)
                {
                    if (profesor == i)
                    {
                        retorno = true;
                        break;
                    }
                }
            }

            return retorno;
        }

        /// <summary>
        /// Verifica si un profesor no esta dando clases en una universidad.
        /// </summary>
        /// <param name="g">Una universidad.</param>
        /// <param name="i">Un profesor.</param>
        /// <returns>Devuelve true si el profesor no da clases en la universidad, false caso contrario</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Busca al primer profesor de la universidad capaz de dar la clase pasada como parametro.
        /// </summary>
        /// <param name="u">Una universidad.</param>
        /// <param name="clase">Una clase.</param>
        /// <returns>Devuelve al primer profesor capaz de dar dicha clase.</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor instructor = null;

            if (!Object.Equals(u, null))
            {
                foreach (Profesor profesor in u.Instructores)
                {
                    if (profesor == clase)
                    {
                        instructor = profesor;
                        break;
                    }
                }
            }
            
            if (Object.Equals(instructor, null))
            {
                throw new SinProfesorException();
            }

            return instructor;
        }

        /// <summary>
        /// Busca al primer profesor de la universidad que no pueda dar la clase pasada como parametro.
        /// </summary>
        /// <param name="u">Una universidad.</param>
        /// <param name="clase">Una clase.</param>
        /// <returns>Devuelve al primer profesor que no puede dar dicha clase.</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor instructor = null;

            if (!Object.Equals(u, null))
            {
                foreach (Profesor profesor in u.Instructores)
                {
                    if (profesor != clase)
                    {
                        instructor = profesor;
                        break;
                    }
                }
            }
            
            return instructor;
        }

        /// <summary>
        /// Agrega a la universidad una nueva jornada con la clase pasada como parametro, un profesor que pueda dar dicha clase y la lista de alumnos que la toman.
        /// </summary>
        /// <param name="g">Una universidad.</param>
        /// <param name="clase">Una clase.</param>
        /// <returns>Devuelve la universidad pasada como parametro.</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            if (!Object.Equals(g, null))
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
            }
            
            return g;
        }

        /// <summary>
        /// Agrega un alumno a la universidad.
        /// </summary>
        /// <param name="u">Una universidad.</param>
        /// <param name="a">Un alumno.</param>
        /// <returns>Devuelve la universidad pasada como parametro.</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (!Object.Equals(u, null) && !Object.Equals(a, null))
            {
                if (u != a)
                {
                    u.Alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }
            
            return u;
        }

        /// <summary>
        /// Agrega un profesor a la universidad.
        /// </summary>
        /// <param name="u">Una universidad.</param>
        /// <param name="a">Un alumno.</param>
        /// <returns>Devuelve la universidad pasada como parametro.</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (!Object.Equals(u, null) && !Object.Equals(i, null))
            {
                if (u != i)
                {
                    u.Instructores.Add(i);
                }
            }
            
            return u;
        }
    }
}
