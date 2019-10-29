using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
            datos.AppendFormat("JORNADA:\nCLASE DE {0} ", this.Clase);
            datos.AppendFormat("POR {0}ALUMNOS:\n", this.Instructor.ToString());
            foreach (Alumno alumno in this.Alumnos)
            {
                datos.AppendFormat("{0}\n", alumno.ToString());
            }
            datos.AppendLine("<------------------------------------------------->\n");
            return datos.ToString();
        }

        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            try
            {
                string ruta = AppDomain.CurrentDomain.BaseDirectory + @"\Jornada.txt";
                using (StreamWriter escritor = new StreamWriter(ruta))
                {
                    escritor.WriteLine(jornada.ToString());
                    retorno = true;
                }
            }
            catch (DirectoryNotFoundException error)
            {
                Console.WriteLine(error.Message);
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            return retorno;
        }

        public static string Leer()
        {
            StringBuilder datosJornada = new StringBuilder();
            string ruta = AppDomain.CurrentDomain.BaseDirectory + @"\Jornada.txt";
            
            try
            {
                using (StreamReader lector = new StreamReader(ruta))
                {
                    string linea = lector.ReadLine();

                    while (linea != null)
                    {
                        datosJornada.AppendLine(linea);
                    }
                }
            }
            catch (DirectoryNotFoundException error)
            {
                Console.WriteLine(error.ToString());
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.ToString());
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }

            return datosJornada.ToString();
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
