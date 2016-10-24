using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Harina))]
    public class Harina : Producto
    {
        #region Atributos
        protected ETipoHarina _tipo;
        protected static bool DeConsumo;    
        #endregion

        public enum ETipoHarina
        {
            Integral,
            CuatroCeros
        }

        #region Propiedades
        /// <summary>
        /// al precio final le calcula su 60%
        /// </summary>
        public override float CalcularCostoDeProduccion
        {
            get { return base._precio * 0.60f; }
        }
        /// <summary>
        /// inserta o retorna un valor de tipo ETipoHarina
        /// </summary>
        public ETipoHarina Tipo
        { get; set; }
   
        #endregion

        #region Constructores
        public Harina()
        {
        }
        public Harina(int codigoDeBarra,float precio,EMarcaProducto marca,ETipoHarina tipo):base(codigoDeBarra,marca,precio)
        {
            this._tipo = tipo;    
        }
        static Harina()
        {
            Harina.DeConsumo = false;
        }       
        #endregion

        #region Metodos
        /// <summary>
        /// retorna una cadena de texto con toda la informacion de una Harina
        /// </summary>
        /// <returns></returns>
        private string MostrarHarina()
        {
            return this + "TIPO : " + this._tipo.ToString();
        }
        /// <summary>
        /// muestra todos los datos de una Harina
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return MostrarHarina();
        }
        #endregion
    }
}
