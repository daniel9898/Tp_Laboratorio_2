using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gaseosa : Producto
    {
        #region Atributos
        protected float _litros;
        protected static bool DeConsumo;
        #endregion

        #region Propiedades
        public override float CalcularCostoDeProduccion
        {
            get { return base._precio * 0.42f; }
        }
    
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
        #endregion

        #region Metodos
        private string MostrarGaseosa()
        {
            return this + "LITROS : " + this._litros.ToString();
        }
        public string ToString()
        {
            return MostrarGaseosa();
        }
        public override string Consumir()
        {
            return "Bebible";
        }
        #endregion



    }
}
