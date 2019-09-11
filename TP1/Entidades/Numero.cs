using System;

namespace Entidades
{
    public class Numero
    {
        private double numero;

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

        public Numero() : this(0) { }

        public Numero(double numero)
        {
            this.SetNumero = Convert.ToString(numero);
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;

            double.TryParse(strNumero, out retorno);

            return retorno;
        }

        public static string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";
            char[] arrayBinario = binario.ToCharArray();
            bool esBinario = true;

            for (int i=0; i<arrayBinario.Length; i++)
            {
                if (arrayBinario[i] != '0' && arrayBinario[i] != '1')
                {
                    esBinario = false;
                    break;
                }
            }

            if (esBinario)
            {
                retorno = Convert.ToString(Convert.ToInt32(binario, 2));
            }

            return retorno;
        }

        public static string DecimalBinario(double numero)
        {
            return Convert.ToString((int)Math.Abs(numero), 2);
        }

        public static string DecimalBinario(string numero)
        {
            string retorno = "Valor invalido";

            if (double.TryParse(numero, out double numeroParseado))
            {
                retorno = DecimalBinario(numeroParseado);
            }

            return retorno;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

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
