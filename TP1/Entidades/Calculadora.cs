using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            string retorno = operador;

            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                retorno = "+";
            }

            return retorno;
        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;

            switch (ValidarOperador(operador))
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }

            return resultado;
        }
    }
}
