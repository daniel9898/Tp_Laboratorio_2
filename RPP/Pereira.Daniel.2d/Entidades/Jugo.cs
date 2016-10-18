using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
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
        public override float CalcularCostoDeProduccion
        {
            get { return base._precio * 0.40f; }
        }
  
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
        #endregion

        #region Metodos
        private string MostrarJugo()
        {
            return this + "SABOR : " + this._sabor.ToString();
        }
        public string ToString()
        {
            return MostrarJugo();
        }
        public override string Consumir()
        {
            return "Bebible";
        }
        #endregion

    }
}
