using System;
using System.Collections.Generic;
using System.Text;
using EntidadesExcepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;
        
        /// <summary>
        /// Propiedad de lectura y escritura del DNI(entero) de la persona.
        /// </summary>
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

        /// <summary>
        /// Propiedad de lectura y escritura del nombre de la persona.
        /// </summary>
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

        /// <summary>
        /// Propiedad de lectura y escritura del apellido de la persona.
        /// </summary>
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

        /// <summary>
        /// Propiedad de lectura y escritura de la nacionalidad de la persona.
        /// </summary>
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

        /// <summary>
        /// Propiedad de lectura y escritura del DNI(string) de la persona.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Enumerado del tipo de nacionalidad de la persona.
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        /// <summary>
        /// Constructor por defecto de la clase persona. Instancia los datos por defecto de una persona.
        /// </summary>
        public Persona()
        {
            this.dni = 0;
            this.nombre = "";
            this.apellido = "";
            this.nacionalidad = ENacionalidad.Argentino;
        }

        /// <summary>
        /// Sobrecarga del constructor de la clase persona. Instancia los datos de una persona pasados como parametro.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Sobrecarga del constructor de la clase persona. Instancia los datos de una persona pasados como parametro.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="dni">DNI de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Sobrecarga del constructor de la clase persona. Instancia los datos de una persona pasados como parametro.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="dni">DNI de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Sobrecarga del metodo ToString()
        /// </summary>
        /// <returns>Devuelve los datos de una persona con formato especifico.</returns>
        public override string ToString()
        {
            StringBuilder datosPersona = new StringBuilder();

            datosPersona.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            datosPersona.AppendLine("NACIONALIDAD: " + this.Nacionalidad);

            return datosPersona.ToString();
        }

        /// <summary>
        /// Valida el DNI(entero) de acuerdo a la nacionalidad de la persona.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI de la persona.</param>
        /// <returns>Devuelve el DNI validado, 0 en caso de error.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return this.ValidarDni(nacionalidad, dato.ToString());
        }

        /// <summary>
        /// Sobrecarga del metodo ValidarDni. Valida el DNI(string) de acuerdo a la nacionalidad de la persona.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI de la persona.</param>
        /// <returns>Devuelve el DNI validado, 0 en caso de error.</returns>
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

        /// <summary>
        /// Valida si un nombre/apellido es valido como tal.
        /// </summary>
        /// <param name="dato">El nombre/apellido de la persona.</param>
        /// <returns>Devuelve el nombre/apellido validado.</returns>
        private string ValidarNombreApellido(string dato)
        {
            bool esValido = true;
            string datoValidado = "";

            foreach (char caracter in dato)
            {
                if (!char.IsLetter(caracter) || caracter != ' ')
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
