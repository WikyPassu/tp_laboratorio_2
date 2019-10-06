using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        /// <summary>
        /// TIPO de Leche
        /// </summary>
        public enum ETipo
        {
            Entera,
            Descremada
        }

        ETipo tipo;

        /// <summary>
        /// Instancia los datos de la Leche. Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Marca de la Leche</param>
        /// <param name="codigo">Codigo de barras de la Leche</param>
        /// <param name="color">Color del empaque de la Leche</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
            this.tipo = ETipo.Entera;
        }

        /// <summary>
        /// Instancia los datos de la Leche.
        /// </summary>
        /// <param name="marca">Marca de la Leche</param>
        /// <param name="codigo">Codigo de barras de la Leche</param>
        /// <param name="color">Color del empaque de la Leche</param>
        /// <param name="tipo">Tipo de Leche</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
            : this(marca, codigo, color)
        {
        }
     
        /// <summary>
        /// Devuelve la cantidad de calorías de la Leche (20)
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Muestra todos los datos de la Leche
        /// </summary>
        /// <returns>Retorna todos los datos de la Leche en formato string</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
