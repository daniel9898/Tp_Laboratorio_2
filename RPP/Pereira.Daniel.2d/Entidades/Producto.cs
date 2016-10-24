using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

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
        /// <summary>
        /// retorna el costo de produccion de un producto especifico
        /// </summary>
        public abstract float CalcularCostoDeProduccion{get;}
        /// <summary>
        /// retorna o inserta un tipo valor Emarca 
        /// </summary>
        public EMarcaProducto Marca
        {
            get { return this._marca; }
            set { this._marca = value; }
        }
        /// <summary>
        /// retorna o inserta un precio
        /// </summary>
        public float Precio
        {
            get { return this._precio; }
            set { this._precio = value; }
        }
        /// <summary>
        /// retorna o inserta un codigo de barra
        /// </summary>
        public int CodigoDeBarra
        {
            get { return this._codigoBarra; }
            set { this._codigoBarra = value; }
        }
        #endregion

        #region Constructor
        public Producto(int codigoDeBarra, EMarcaProducto marca, float precio)
        {
            this._codigoBarra = codigoDeBarra;
            this._marca = marca;
            this._precio = precio;          
        }
        public Producto()
        {

        }
        #endregion

        #region Metodos
        /// <summary>
        /// retorna la cadena de texto especificada
        /// </summary>
        /// <returns></returns>
        public virtual string Consumir()
        {
            return "Parte de una mezcla";
        }
        /// <summary>
        /// compara si 2 objetos son del mismo tipo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj.GetType() == this.GetType());           
        }
        /// <summary>
        /// retorna una cadena con todos los datos del producto
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Sobrecarga del operador explicito (int) que retorna el codigo de barra del producto
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static explicit operator int(Producto p)
        {
            return p._codigoBarra;
        }
        /// <summary>
        /// sobrecarga del operador string que muestra todos los datos de un producto
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static implicit operator string(Producto p)
        {
            return Producto.MostrarProducto(p);
        }
        /// <summary>
        /// Compara 2 productos y devuelve true si son del mismo tipo y compraten la misma marca y patente
        /// </summary>
        /// <param name="ProdUno"></param>
        /// <param name="ProdDos"></param>
        /// <returns></returns>
        public static bool operator ==(Producto ProdUno, Producto ProdDos)
        {
           bool retorno=false;
           if (!(ProdUno.Equals(ProdDos)) && ((int)ProdUno == (int)ProdDos && ProdUno._marca==ProdDos._marca))
            {
                retorno = true;
            }
           else if ((int)ProdUno == (int)ProdDos && ProdUno._marca == ProdDos._marca)
            {
               retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Compara 2 productos y devuelve False si NO son del mismo tipo,
        /// sin son del mismo tipo,retorna false sino coparten marca y patente
        /// </summary>
        /// <param name="ProdUno"></param>
        /// <param name="ProdDos"></param>
        /// <returns></returns>
        public static bool operator !=(Producto ProdUno, Producto ProdDos)
        {
            return !(ProdUno == ProdDos);
        }
        /// <summary>
        /// compara si el enumerado marca indicado coincide con el del algun 
        /// producto ya ingresado en ese caso retorna true.
        /// </summary>
        /// <param name="ProdUno"></param>
        /// <param name="marca"></param>
        /// <returns></returns>
        public static bool operator ==(Producto ProdUno, EMarcaProducto marca)
        {
            bool retorno = false;
            if (ProdUno._marca == marca)
                retorno = true;
            return retorno;
        }
        /// <summary>
        /// compara si el enumerado marca indicado coincide con el del algun 
        /// producto ya ingresado,sino coincide retorna False.
        /// </summary>
        /// <param name="ProdUno"></param>
        /// <param name="marca"></param>
        /// <returns></returns>
        public static bool operator !=(Producto ProdUno, EMarcaProducto marca)
        {
            return !(ProdUno == marca);
        }
        #endregion
    }
}
