using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Harina))]
    [XmlInclude(typeof(Jugo))]
    [XmlInclude(typeof(Galletita))]
    [XmlInclude(typeof(Gaseosa))]

    public class Estante
    {
        #region Atributos
        protected sbyte _capacidad;
        protected List<Producto> _productos;
        protected int contador;    
        #endregion
        
        #region propiedades
        /// <summary>
        /// retorna la suma de los precios de todos los productos del estante especifico
        /// </summary>
        public float ValorEstanteTotal
        {
            get { return GetValorEstante(); }
        }
        /// <summary>
        /// Retorna o inserta un una capacidad al o del estante
        /// </summary>
        public sbyte Capacidad
        {
            get { return this._capacidad; }
            set { this._capacidad = value; }
        }
        /// <summary>
        /// retorna la lista con todos los productos
        /// </summary>
        public List<Producto> Productos
        { 
            get { return this._productos; }
            set { }
        }
        #endregion

        #region Constructores
        private Estante()
        {
            this._productos = new List<Producto>();
        }
        public Estante(sbyte capacidad):this()
        {
            this._capacidad = capacidad;
            this.contador = capacidad;
        }
        #endregion

        #region Metodos   
        /// <summary>
        /// retorna la lista con todos los productos
        /// </summary>
        /// <returns></returns>
        public List<Producto> GetProductos()
        {
            return this._productos;
        }
        /// <summary>
        /// retorna la suma de todos los precios de un estante
        /// </summary>
        /// <returns></returns>
        private float GetValorEstante()
        {
            float valor=0;
            for (int i = 0; i < this._productos.Count; i++)
            {
                valor += _productos[i].Precio;
            }
            return valor;
        }
        /// <summary>
        /// retorna la suma de todos los precios de un producto especifico
        /// de un estante
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public float GetValorEstante(Producto.ETipoProducto tipo)
        {
            float valor = 0;
            for (int i = 0; i < this._productos.Count; i++)
            {
                switch (tipo)
                {
                    case Producto.ETipoProducto.Jugo:
                        if (this._productos[i] is Jugo)
                            valor += this._productos[i].Precio; 
                        break;
                    case Producto.ETipoProducto.Harina:
                        if (this._productos[i] is Harina)
                            valor += this._productos[i].Precio; 
                        break;
                    case Producto.ETipoProducto.Gaseosa:
                        if (this._productos[i] is Gaseosa)
                            valor += this._productos[i].Precio; 
                        break;
                    case Producto.ETipoProducto.Galletita:
                        if (this._productos[i] is Galletita)
                            valor += this._productos[i].Precio; 
                        break;
                    default:
                        GetValorEstante();
                        break;
                }
            }
            return valor;

        }
        /// <summary>
        /// muestra todos los datos del estante incluidos los de todos 
        /// sus productos
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string MostrarEstante(Estante e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CAPACIDAD : {0}",e._capacidad.ToString());
            for (int i = 0; i < e._productos.Count; i++)
            {
                if(e._productos[i] is Jugo)
                    sb.AppendLine(((Jugo)e._productos[i]).ToString());
                if(e._productos[i] is Harina)
                    sb.AppendLine(((Harina)e._productos[i]).ToString());
                if(e._productos[i] is Gaseosa)
                    sb.AppendLine(((Gaseosa)e._productos[i]).ToString());
                if(e._productos[i] is Galletita)
                    sb.AppendLine(((Galletita)e._productos[i]).ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region sobrecargas
        /// <summary>
        /// compara si un producto ya se encuentra en la lista,en ese caso retorna true.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="prod"></param>
        /// <returns></returns>
        public static bool operator ==(Estante e, Producto prod)
        {
            bool retorno=false;
            for (int i = 0; i < e._productos.Count; i++)
            {
                if (e._productos[i] == prod)
                    retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// compara si un producto no se encuentra en la lista,en ese caso retorna false.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="prod"></param>
        /// <returns></returns>
        public static bool operator !=(Estante e, Producto prod)
        {
            return !(e == prod);
        }
        /// <summary>
        /// inserta un producto ala lista siempre y cuando la capacidad lo permita
        /// y el producto no se encuentre ya ingresado en la lista
        /// </summary>
        /// <param name="e"></param>
        /// <param name="prod"></param>
        /// <returns></returns>
        public static bool operator +(Estante e, Producto prod)
        {
            bool retorno = false;
            if (e.contador >= 1 && e != prod)
            {              
                    e._productos.Add(prod);
                    e.contador--;
                    retorno = true;                             
            }
                                 
            return retorno;
        }
        /// <summary>
        /// Elimina un producto especifico de la lista
        /// </summary>
        /// <param name="e"></param>
        /// <param name="prod"></param>
        /// <returns></returns>
        public static Estante operator -(Estante e, Producto prod)
        {
                for (int i = 0; i < e._productos.Count; i++)
                {
                    if (prod is Galletita && e._productos[i] is Galletita)
                    {
                        e._productos.Remove(e._productos[i]);
                        i--;
                    }

                    else if (prod is Gaseosa && e._productos[i] is Gaseosa)
                    {
                        e._productos.Remove(e._productos[i]);
                        i--;
                    }

                    else if (prod is Jugo && e._productos[i] is Jugo)
                    {
                        e._productos.Remove(e._productos[i]);
                        i--;
                    }

                    else if (prod is Harina && e._productos[i] is Harina)
                    {
                        e._productos.Remove(e._productos[i]);
                        i--;
                    }
                }
                     
            return e;                
        }
        /// <summary>
        /// elimina todos los preoductos de la lista que coincidan con el 
        /// enumerado
        /// </summary>
        /// <param name="e"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public static Estante operator -(Estante e, Producto.ETipoProducto tipo)
        {
            Estante aux = e;
                for (int i = 0; i < e._productos.Count; i++)
                {
                    switch (tipo)
                    {
                        case Producto.ETipoProducto.Jugo:
                            if (aux._productos[i] is Jugo)
                               aux -=aux._productos[i];                              
                            break;
                        case Producto.ETipoProducto.Harina:
                            if (aux._productos[i] is Harina)
                                aux -=aux._productos[i];                       
                            break;
                        case Producto.ETipoProducto.Gaseosa:
                            if (aux._productos[i] is Gaseosa)        
                                aux -=aux._productos[i];                                 
                            break;
                        case Producto.ETipoProducto.Galletita:
                            if (aux._productos[i] is Galletita)
                                aux -=aux._productos[i];                    
                            break;
                        default:
                            aux -= Producto.ETipoProducto.Galletita;
                            aux -= Producto.ETipoProducto.Gaseosa;
                            aux -= Producto.ETipoProducto.Harina;
                            aux -= Producto.ETipoProducto.Jugo;
                            break;
                    }
              
            }
            return aux;
        }
        #endregion

    }
}
