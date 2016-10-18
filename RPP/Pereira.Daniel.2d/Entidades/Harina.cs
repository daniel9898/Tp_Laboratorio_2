using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
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
        public override float CalcularCostoDeProduccion
        {
            get { return base._precio * 0.60f; }
        }
   
        #endregion

        #region Constructores
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
        private string MostrarHarina()
        {
            return this + "TIPO : " + this._tipo.ToString();
        }
        public string ToString()
        {
            return MostrarHarina();
        }
        #endregion
    }
}
