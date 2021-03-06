﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        /// <summary>
        /// Tipo de marca del Producto
        /// </summary>
        public enum EMarca
        {
            Serenisima,
            Campagnola,
            Arcor,
            Ilolay,
            Sancor,
            Pepsico
        }

        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;

        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto
        /// </summary>
        protected abstract short CantidadCalorias { get; }

        /// <summary>
        /// Instancia todos los datos del Producto.
        /// </summary>
        /// <param name="codigo">Codigo de barras del Producto</param>
        /// <param name="marca">Marca del Producto</param>
        /// <param name="color">Color del empaque del Producto</param>
        public Producto(string codigo, EMarca marca, ConsoleColor color) 
        {
            this.codigoDeBarras = codigo;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// Muestra los datos del Producto
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Convierte explicitamente a string los datos del producto
        /// </summary>
        /// <param name="p">Producto a convertir sus datos</param>
        /// <returns>Retorna los datos del Producto en formato string</returns>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: " + p.codigoDeBarras);
            sb.AppendLine("MARCA           : " + p.marca.ToString());
            sb.AppendLine("COLOR EMPAQUE   : " + p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1">Un Producto</param>
        /// <param name="v2">Otro Producto</param>
        /// <returns>Retorna true si son iguales, false caso contrario</returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            bool retorno = false;

            if (!Object.Equals(v1, null) && !Object.Equals(v2, null))
            {
                if (v1.codigoDeBarras == v2.codigoDeBarras)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1">Un Producto</param>
        /// <param name="v2">Otro producto</param>
        /// <returns>Retorna true si son diferentes, false caso contrario</returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);
        }
    }
}
