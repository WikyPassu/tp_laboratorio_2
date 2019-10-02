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
        public enum ETipo { Entera, Descremada }
        ETipo tipo;

        /// <summary>
        /// Instancia los datos de la Leche. Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
            tipo = ETipo.Entera;
        }

        /// <summary>
        /// Instancia los datos de la Leche.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
            : this(marca, codigo, color)
        {
        }
     
        /// <summary>
        /// Devuelve la cantidad de calorías de la Leche (20)
        /// </summary>
        protected override short CantidadCalorias { get { return 20; } }

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
