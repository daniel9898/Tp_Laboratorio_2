using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
        #region Atributos
        protected int _codigoBarra;
        protected EMarcaProducto _marca;
        protected float _precio;
        
        #endregion

        #region Enumerados
        public enum EMarcaProducto
        {
            Favorita,
            Pitusas,
            Diversión,
            Naranjú,
            Swift
        }
        public enum ETipoProducto
        {
            Jugo,
            Harina,
            Gaseosa,
            Galletita,
            Todos
        }
        #endregion

        #region Propiedades
        public abstract float CalcularCostoDeProduccion{get;}

        public EMarcaProducto Marca
        {
            get { return this._marca; }
        }
        public float Precio
        {
            get { return this._precio; }
        }
      
        #endregion

        #region Constructor
        public Producto(int codigoDeBarra, EMarcaProducto marca, float precio)
        {
            this._codigoBarra = codigoDeBarra;
            this._marca = marca;
            this._precio = precio;          
        }
        #endregion

        #region Metodos
        public virtual string Consumir()
        {
            return "Parte de una mezcla";
        }

        public new bool Equals(object obj)
        {
            return obj is Producto;
        }

        private static string MostrarProducto(Producto p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nMARCA : "+ p._marca.ToString());
            sb.AppendLine("CODIGO DE BARRAS : "+ p._codigoBarra.ToString());
            sb.AppendLine("PRECIO : " +p._precio.ToString());
           
            return sb.ToString();
        }
        #endregion

        #region Sobrecargas
        public static explicit operator int(Producto p)
        {
            return p._codigoBarra;
        }

        public static implicit operator string(Producto p)
        {
            return Producto.MostrarProducto(p);
        }

        public static bool operator ==(Producto ProdUno, Producto ProdDos)
        {
           bool retorno=false;
           if (ProdUno.Equals(ProdDos) && (int)ProdUno == (int)ProdDos && ProdUno._marca==ProdDos._marca)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Producto ProdUno, Producto ProdDos)
        {
            return !(ProdUno == ProdDos);
        }

        public static bool operator ==(Producto ProdUno, EMarcaProducto marca)
        {
            bool retorno = false;
            if (ProdUno._marca == marca)
                retorno = true;
            return retorno;
        }
        public static bool operator !=(Producto ProdUno, EMarcaProducto marca)
        {
            return !(ProdUno == marca);
        }
        #endregion
    }
}
