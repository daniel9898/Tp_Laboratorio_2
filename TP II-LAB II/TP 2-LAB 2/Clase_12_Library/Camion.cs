using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_12_Library_2;

namespace Clase_12_Library
{
    public class Camion : Vehiculo
    {
        public Camion(EMarca marca, string patente, ConsoleColor color)
            : base(marca,patente,color)
        {
        }
        /// <summary>
        /// Los camiones tienen 8 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 8;
            }
            set
            {

            }
        }
        /// <summary>
        /// Retorna un string con todos los atributos de la clase Camion y su clase base
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMION");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS : "+this.CantidadRuedas.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
