using System;
using System.Collections.Generic;
using System.Text;
using EntidadesExcepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        public Persona()
        {
            this.dni = 0;
            this.nombre = "";
            this.apellido = "";
            this.nacionalidad = ENacionalidad.Argentino;
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder datosPersona = new StringBuilder();

            datosPersona.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            datosPersona.AppendLine("NACIONALIDAD: " + this.Nacionalidad);

            return datosPersona.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return this.ValidarDni(nacionalidad, dato.ToString());
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dniValidado = 0;
            int datoEnEntero = 0;
            bool errorFormato = false;
            bool errorRango = false;

            if (dato.Length < 1 || dato.Length > 8)
            {
                errorFormato = true;
            }
            else
            {
                foreach (char caracter in dato)
                {
                    if (!char.IsDigit(caracter))
                    {
                        errorFormato = true;
                        break;
                    }
                }
            }

            if (!errorFormato)
            {
                datoEnEntero = int.Parse(dato);
                switch (nacionalidad)
                {
                    case ENacionalidad.Argentino:
                        if (datoEnEntero < 1 || datoEnEntero > 89999999)
                        {
                            errorRango = true;
                        }
                        break;
                    case ENacionalidad.Extranjero:
                        if (datoEnEntero < 90000000 || datoEnEntero > 99999999)
                        {
                            errorRango = true;
                        }
                        break;
                }
            }

            if (errorFormato)
            {
                throw new DniInvalidoException("El DNI presenta un error de formato.");
            }
            else if (errorRango)
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
            }
            else if (!errorFormato && !errorRango)
            {
                dniValidado = datoEnEntero;
            }

            return dniValidado;
        }

        private string ValidarNombreApellido(string dato)
        {
            bool esValido = true;
            string datoValidado = "";

            foreach (char caracter in dato)
            {
                if (!char.IsLetter(caracter) && caracter != ' ')
                {
                    esValido = false;
                    break;
                }
            }
            if (esValido)
            {
                datoValidado = dato;
            }

            return dato;
        }
    }
}
