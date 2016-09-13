using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp1_Lab_II
{
    class Numero
    {
 
        private double _numero;

        /// <summary>
        /// Inicializa el atributo _numero en cero
        /// </summary>
        public Numero()
        {
            this._numero = 0;
        }
        /// <summary>
        /// Valida e inicializa el atributo _numero con el valor que se le pase como
        /// parametro
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero): this()          
        {
            SetNumero(numero);
        }
        /// <summary>
        /// inicializa el atributo _numero con el valor que se le pasa
        /// como parametro
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this._numero = numero;
        }
        /// <summary>
        /// Valida un string,si lo puede convertir a numero
        /// lo retorna
        /// </summary>
        /// <param name="nro"></param>
        /// <returns>0 si no pudo convertir,un double si pudo</returns>                  
        private static double ValidarNumero(string nro)
        {
            double Num;
            double retorno = 0;
            bool retor;
            retor = double.TryParse(nro, out Num);
            if (retor)
                retorno = Num;

            return retorno;
        }
        /// <summary>
        /// Valida un string,si se pueda convertir a numero
        ///  lo asigna en el atributo _numero
        /// </summary>
        /// <param name="numero"></param>
        private void SetNumero(string numero)
        {
            double retorno;
            retorno = Numero.ValidarNumero(numero);
            if (retorno != 0)
                this._numero = retorno;
        }
        /// <summary>
        /// Retorna el valor que tiene en el momento la propiedad _numero 
        /// </summary>
        /// <returns></returns>
        public double GetNumero()
        {
            return this._numero;
        }
    }
}
