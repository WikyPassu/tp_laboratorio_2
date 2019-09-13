using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Metodo que valida que el operador pasado como parametro es (+ - * /).
        /// </summary>
        /// <param name="operador">El operador a validar.</param>
        /// <returns>Retorna el operador pasado como parametro si es valido, caso contrario retornara el operador +.</returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = operador;

            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                retorno = "+";
            }

            return retorno;
        }

        /// <summary>
        /// Metodo que realiza una operacion entre dos objetos de tipo Numero de acuerdo al operador pasado como parametro.
        /// </summary>
        /// <param name="num1">Primer objeto Numero.</param>
        /// <param name="num2">Segundo objeto Numero.</param>
        /// <param name="operador">Operador correspondiente a la operacion a realizar.</param>
        /// <returns>Retorna el resultado de la operacion.</returns>
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
