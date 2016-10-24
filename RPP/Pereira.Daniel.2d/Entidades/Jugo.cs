using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Jugo))]

    public class Jugo : Producto
    {
        #region Atributos
        protected ESaborJugo _sabor;
        protected static bool DeConsumo;
     
        #endregion

        public enum ESaborJugo
        {
            Pasable,
            Asqueroso
        }
        
        #region Propiedades
        /// <summary>
        /// al precio final le calcula su 40%
        /// </summary>
        public override float CalcularCostoDeProduccion
        {
            get { return base._precio * 0.40f; }
        }
        /// <summary>
        /// inserta o retorna un valor de tipo EsaborJugo
        /// </summary>
        public ESaborJugo Sabor
        { get; set; }
  
        #endregion

        #region Constructores
        public Jugo(int codigoDeBarra,float precio,EMarcaProducto marca,ESaborJugo sabor):base(codigoDeBarra,marca,precio)
        {
            this._sabor = sabor; 
        }
        static Jugo()
        {
            Jugo.DeConsumo = true;
        }
        public Jugo()
        {
        }
        #endregion

        #region Metodos
        /// <summary>
        /// retorna una cadena de texto con toda la informacion de un Jugo
        /// </summary>
        /// <returns></returns>
        private string MostrarJugo()
        {
            return this + "SABOR : " + this._sabor.ToString();
        }
        /// <summary>
        /// muestra todos los datos de un jugo
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return MostrarJugo();
        }
        /// <summary>
        /// retorna una cadena de texto especifica
        /// </summary>
        /// <returns></returns>
        public override string Consumir()
        {
            return "Bebible";
        }
        #endregion

    }
}
