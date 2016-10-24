using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Gaseosa))]
  
    public class Gaseosa : Producto
    {
        #region Atributos
        protected float _litros;
        protected static bool DeConsumo;
        #endregion

        #region Propiedades
        /// <summary>
        /// al precio final le calcula su 42%
        /// </summary>
        public override float CalcularCostoDeProduccion
        {
            get { return base._precio * 0.42f; }
        }
        /// <summary>
        /// inserta  o retorna el valor litros de un de una Galletita 
        /// </summary>
        public float litros
        { get; set; }

        #endregion

        #region Constructores
        public Gaseosa(int codigoDeBarra,float precio,EMarcaProducto marca,float litros):base(codigoDeBarra,marca,precio)
        {
            this._litros = litros; 
        }
        static Gaseosa()
        {
            Gaseosa.DeConsumo = true;
        }
        public Gaseosa(Producto p, float litros):base((int)p,p.Marca,p.Precio)
        {
            this._litros = litros; 
        }
        public Gaseosa()
        {
        }
        #endregion

        #region Metodos
        /// <summary>
        /// retorna una cadena de texto con toda la informacion de una Gaseosa
        /// </summary>
        /// <returns></returns>
        private string MostrarGaseosa()
        {
            return this + "LITROS : " + this._litros.ToString();
        }
        /// <summary>
        /// muestra todos los datos de una gaseosa
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return MostrarGaseosa();
        }
        /// <summary>
        /// retorna una cadena especifica
        /// </summary>
        /// <returns></returns>
        public override string Consumir()
        {
            return "Bebible";
        }
        #endregion



    }
}
