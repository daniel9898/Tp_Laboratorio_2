using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Galletita : Producto
    {
        #region Atributos
        protected float _peso;
        protected static bool DeConsumo;
       
        #endregion

        #region Propiedades
        public override float CalcularCostoDeProduccion
        {
            get { return base._precio * 0.33f; }
        }
  
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
        #endregion

        #region Metodos
        private string MostrarGalletita(Galletita g)
        {
            return this+"PESO :" + g._peso.ToString();
        }
        public string ToString()
        {
            return MostrarGalletita(this);
        }
        public override string Consumir()
        {
            return "Comestible";
        }
        #endregion







    }
}
