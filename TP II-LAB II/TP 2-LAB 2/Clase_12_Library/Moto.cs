using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Clase_12_Library_2;

namespace Clase_12_Library
{
    public class Moto : Vehiculo
    {
        public Moto(EMarca marca, string patente, ConsoleColor color)
            : base(marca,patente,color)
        {
        }
        /// <summary>
        /// Las motos tienen 2 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 2;
            }
            set
            {

            }
        }
        /// <summary>
        /// Retorna un string con todos los atributos de la clase moto y su clase base
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS : "+this.CantidadRuedas.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
