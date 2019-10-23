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
            this.apellido = "";
            this.dni = 0;
            this.nacionalidad = ENacionalidad.Argentino;
            this.nombre = "";
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
            datosPersona.AppendFormat("NOMBRE COMPLETO: {0}, {1}\nNACIONALIDAD: {2}", this.Apellido, this.Nombre, this.Nacionalidad);
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
            bool soloNumeros = true;
            bool respetaCantidad = true;
            bool respetaRango = true;

            foreach (char caracter in dato)
            {
                if (!char.IsDigit(caracter))
                {
                    soloNumeros = false;
                    break;
                }
            }

            if (soloNumeros)
            {
                datoEnEntero = int.Parse(dato);
                switch (nacionalidad)
                {
                    case ENacionalidad.Argentino:
                        if (dato.Length < 1 && dato.Length > 8)
                        {
                            respetaCantidad = false;
                        }
                        else if (datoEnEntero > 0 && datoEnEntero <= 89999999)
                        {
                            respetaRango = false;
                        }
                        break;
                    case ENacionalidad.Extranjero:
                        if (dato.Length != 8)
                        {
                            respetaCantidad = false;
                        }
                        else if (datoEnEntero > 89999999 && datoEnEntero <= 99999999)
                        {
                            respetaRango = false;
                        }
                        break;
                }
            }

            if (soloNumeros && respetaCantidad && respetaRango)
            {
                dniValidado = datoEnEntero;
            }
            else if (!soloNumeros || !respetaCantidad)
            {
                throw new DniInvalidoException("Formato de DNI inválido");
            }
            else if (!respetaRango)
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
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
