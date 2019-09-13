using System;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Propiedad setter de numero que valida previamente el value ingresado para luego setearlo al atributo numero.
        /// </summary>
        private string SetNumero
        {
            set
            {
                double numeroValidado = ValidarNumero(value);

                if (numeroValidado != 0)
                {
                    this.numero = numeroValidado;
                }

            }
        }

        /// <summary>
        /// Constructor del objeto Numero que inicializa al atributo numero en 0.
        /// </summary>
        public Numero() : this(0) { }
        
        /// <summary>
        /// Sobrecarga del constructor Numero que setea mediante un setter al atributo numero recibiendo previamente dicho numero como double.
        /// </summary>
        /// <param name="numero">El numero a ser seteado en el atributo numero.</param>
        public Numero(double numero)
        {
            this.SetNumero = Convert.ToString(numero);
        }

        /// <summary>
        /// Sobrecarga del constructor Numero que setea mediante un setter al atributo numero recibiendo previamente dicho numero como string.
        /// </summary>
        /// <param name="strNumero">El numero a ser seteado en el atributo numero.</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Metodo que valida si lo pasado como parametro es un numero.
        /// </summary>
        /// <param name="strNumero">El numero a ser validado.</param>
        /// <returns>Retorna el numero validado, 0 si ocurrio un error.</returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;

            double.TryParse(strNumero, out retorno);

            return retorno;
        }

        /// <summary>
        /// Metodo que convierte un binario pasado en formato string como parametro a numero decimal.
        /// </summary>
        /// <param name="binario">El numero binario a convertir.</param>
        /// <returns>Retorna el numero convertido a decimal, "Valor invalido" si ocurrio un error.</returns>
        public static string BinarioDecimal(string binario)
        {
            string retorno = "Valor inválido";
            bool esBinario = true;

            foreach(char c in binario)
            {
                if (c != '0' && c != '1')
                {
                    esBinario = false;
                    break;
                }
            }

            if (esBinario && binario != "")
            {
                retorno = Convert.ToString(Convert.ToInt32(binario, 2));
            }

            return retorno;
        }

        /// <summary>
        /// Convierte el numero pasado como parametro a decimal.
        /// </summary>
        /// <param name="numero">El numero decimal a ser convertido.</param>
        /// <returns>Retorna el numero convertido a binario.</returns>
        public static string DecimalBinario(double numero)
        {
            return Convert.ToString((int)Math.Abs(numero), 2);
        }

        /// <summary>
        /// Sobrecarga del metodo DecimalBinario que convierte un numero decimal pasado en formato string como parametro a binario.
        /// </summary>
        /// <param name="numero">El numero decimal a ser convertido.</param>
        /// <returns>Retorna el numero convertido a binario, "Valor invalido" si ocurrio un error.</returns>
        public static string DecimalBinario(string numero)
        {
            string retorno = "Valor inválido";

            if (double.TryParse(numero, out double numeroParseado))
            {
                retorno = DecimalBinario(numeroParseado);
            }

            return retorno;
        }

        /// <summary>
        /// Suma dos objetos de tipo Numero.
        /// </summary>
        /// <param name="n1">Primer objeto Numero.</param>
        /// <param name="n2">Segundo objeto Numero</param>
        /// <returns>Retorna la suma entre ambos numeros.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta dos objetos de tipo Numero.
        /// </summary>
        /// <param name="n1">Primer objeto Numero.</param>
        /// <param name="n2">Segundo objeto Numero.</param>
        /// <returns>Retorna la resta entre ambos numeros.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplica dos objetos de tipo Numero.
        /// </summary>
        /// <param name="n1">Primer objeto Numero.</param>
        /// <param name="n2">Segundo objeto Numero.</param>
        /// <returns>Retorna el producto entre ambos numeros.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Divide dos objetos de tipo Numero.
        /// </summary>
        /// <param name="n1">Primer objeto numero.</param>
        /// <param name="n2">Segundo objeto numero.</param>
        /// <returns>Retorna el cociente entre ambos numeros, double.MinValue en caso de que se quiera dividir entre 0 (si el segundo parametro es 0)</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado = double.MinValue;

            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }

            return resultado;
        }
    }
}
