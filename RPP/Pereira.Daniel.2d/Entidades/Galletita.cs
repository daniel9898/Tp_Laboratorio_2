using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Galletita))]

    public class Galletita : Producto
    {
        #region Atributos
        protected float _peso;
        protected static bool DeConsumo;      
        #endregion

        #region Propiedades
        /// <summary>
        /// al precio final le calcula su 33%
        /// </summary>
        public override float CalcularCostoDeProduccion
        {
            get { return base._precio * 0.33f; }
        }
        /// <summary>
        /// inserta o retorna el peso galletita
        /// </summary>
        public float Peso
        { get; set; }
   
        #endregion

        #region Constructores
        public Galletita(int codigoDeBarra,float precio,EMarcaProducto marca,float peso):base(codigoDeBarra,marca,precio)
        {
            this._peso = peso; 
        }
        static Galletita()
        {
            Galletita.DeConsumo = true;
        }
        public Galletita()
        {
        }
        #endregion

        #region Metodos
        /// <summary>
        /// retorna una cadena de texto con todos los datos de una galletita
        /// especifica
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        private string MostrarGalletita(Galletita g)
        {
            return this + "PESO :" + g._peso.ToString();
        }
        /// <summary>
        /// muestra todos los datos de la de la galletita en la instancia
        /// actual
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return MostrarGalletita(this);
        }
        /// <summary>
        /// retorna una cadena de texto especifica
        /// </summary>
        /// <returns></returns>
        public override string Consumir()
        {
            return "Comestible";
        }
        #endregion







    }
}
