using System;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        private double SetNumero
        {
            set
            {
                if (ValidarNumero(value.ToString()) != 0)
                {
                    this.numero = value;
                }

            }
        }

        public Numero()
        {
            this.SetNumero = 0;
        }

        public Numero(double numero)
        {
            this.SetNumero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = double.Parse(strNumero);
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
                retorno = Convert.ToInt32(binario, 2).ToString();
            }

            return retorno;
        }

        public static string DecimalBinario(double numero)
        {
            string retorno = "Valor invalido";

            if (numero >= 0)
            {
                retorno = Convert.ToString((int)numero, 2);
            }

            return retorno;
        }

        public static string DecimalBinario(string numero)
        {
            string retorno = "Valor invalido";

            if (double.Parse(numero) >= 0)
            {
                retorno = Convert.ToString(int.Parse(numero), 2);
            }

            return retorno;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double resultado = n1.numero + n2.numero;

            return resultado;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double resultado = n1.numero - n2.numero;

            return resultado;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double resultado = n1.numero * n2.numero;

            return resultado;
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
