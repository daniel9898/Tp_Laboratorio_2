using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estante
    {
        #region Atributos
        protected sbyte _capacidad;
        protected List<Producto> _productos;
        protected int contador;
    
        #endregion
        
        #region propiedades
        public float ValorEstanteTotal
        {
            get { return GetValorEstante(); }
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
        public List<Producto> GetProductos()
        {
            return this._productos;
        }
        private float GetValorEstante()
        {
            float valor=0;
            for (int i = 0; i < this._productos.Count; i++)
            {
                valor += _productos[i].Precio;
            }
            return valor;
        }
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
        public static bool operator !=(Estante e, Producto prod)
        {
            return !(e == prod);
        }
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
 
        public static Estante operator -(Estante e, Producto prod)
        {
            if (e == prod)
            {
                for (int i = 0; i < e._productos.Count; i++)
                {
                    if (prod is Galletita && e._productos[i] is Galletita)
                    {
                        e._productos.Remove(((Galletita)e._productos[i]));
                        i--;
                    }

                    if (prod is Gaseosa && e._productos[i] is Gaseosa)
                    {
                        e._productos.Remove(((Gaseosa)e._productos[i]));
                        i--;
                    }

                    if (prod is Jugo && e._productos[i] is Jugo)
                    {
                        e._productos.Remove(((Jugo)e._productos[i]));
                        i--;
                    }

                    if (prod is Harina && e._productos[i] is Harina)
                    {
                        e._productos.Remove(((Harina)e._productos[i]));
                        i--;
                    }
                }
            }
                
            return e;                
        }
        public static Estante operator -(Estante e, Producto.ETipoProducto tipo)
        {
            Estante aux = e;
                for (int i = 0; i < e._productos.Count; i++)
                {
                    switch (tipo)
                    {
                        case Producto.ETipoProducto.Jugo:
                            if (aux._productos[i] is Jugo)
                            {
                               aux -=aux._productos[i];
                               i--;
                            }
                               
                            break;
                        case Producto.ETipoProducto.Harina:
                            if (aux._productos[i] is Harina)
                            {
                                aux -=aux._productos[i];
                                i--;
                            }
                                 
                            break;
                        case Producto.ETipoProducto.Gaseosa:
                            if (aux._productos[i] is Gaseosa)
                            {
                                aux -=aux._productos[i];
                                i--;
                            }
                                 
                            break;
                        case Producto.ETipoProducto.Galletita:
                            if (aux._productos[i] is Galletita)
                            {
                                aux -=aux._productos[i];
                                i--;
                            }
                                
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
