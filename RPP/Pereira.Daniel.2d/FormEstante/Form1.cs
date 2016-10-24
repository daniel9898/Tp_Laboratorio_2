using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.IO;
using System.Xml.Serialization;

namespace FormEstante
{    
    public partial class FormEstante : Form
    {   
        public FormEstante()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Compara 2 marcas de 2 productos diferentes y retorna un valor entero
        /// positivo,negativo o cero dependiendo de si uno es mayor,menor o son iguales
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int OrdenarProductos(Producto a, Producto b)
        {
            return string.Compare(a.Marca.ToString(), b.Marca.ToString());
        }

        public Estante est1;
        public Estante est2;

        /// <summary>
        /// Instancia y carga diferentes productos y estantes
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        private void CargarEstante(out Estante e1,out Estante e2)
        {
            //DEJE LA CARGA COMENTADA PARA PROBAR LA DESERIALIZACION


            //****************************************************
            //est1 = new Estante(4);
            //est2 = new Estante(3);
            //Harina h1 = new Harina(102, 37.5f, Producto.EMarcaProducto.Favorita, Harina.ETipoHarina.CuatroCeros);
            //Harina h2 = new Harina(103, 40.25f, Producto.EMarcaProducto.Favorita, Harina.ETipoHarina.Integral);
            //Galletita g1 = new Galletita(113, 33.65f, Producto.EMarcaProducto.Pitusas, 250f);
            //Galletita g2 = new Galletita(111, 56f, Producto.EMarcaProducto.Diversión, 500f);
            //Jugo j1 = new Jugo(112, 25f, Producto.EMarcaProducto.Naranjú, Jugo.ESaborJugo.Pasable);
            //Jugo j2 = new Jugo(333, 33f, Producto.EMarcaProducto.Swift, Jugo.ESaborJugo.Asqueroso);
            //Gaseosa g = new Gaseosa(j2, 2250f);
            //if (!(est1 + h1))
            //{
            //    Console.WriteLine("No se pudo agregar el producto al estante!!!");
            //}
            //if (!(est1 + g1))
            //{
            //    Console.WriteLine("No se pudo agregar el producto al estante!!!");
            //}
            //if (!(est1 + g2))
            //{
            //    Console.WriteLine("No se pudo agregar el producto al estante!!!");
            //}
            //if (!(est1 + g1))
            //{
            //    Console.WriteLine("No se pudo agregar el producto al estante!!!");
            //}
            //if (!(est1 + j1))
            //{
            //    Console.WriteLine("No se pudo agregar el producto al estante!!!");
            //}
            //if (!(est2 + h2))
            //{
            //    Console.WriteLine("No se pudo agregar el producto al estante!!!");
            //}
            //if (!(est2 + j2))
            //{
            //    Console.WriteLine("No se pudo agregar el producto al estante!!!");
            //}
            //if (!(est2 + g))
            //{
            //    Console.WriteLine("No se pudo agregar el producto al estante!!!");
            //}
            //if (!(est2 + g1))
            //{
            //    Console.WriteLine("No se pudo agregar el producto al estante!!!");
            //}

            //e1 = est1;
            //e2 = est2;

            e1 = Serializador.DeserializarEstante("estante1xml.xml");
            e2 = Serializador.DeserializarEstante("estante2xml.xml");
           
        }
        /// <summary>
        /// Evento que muestra los datos de los estantes y sus productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            rtxtSalida.Text = "";
            Estante est1;
            Estante est2;   
            this.CargarEstante(out est1, out est2);  
            rtxtSalida.Text += String.Format("Valor total Estante1: {0}", est1.ValorEstanteTotal);
            rtxtSalida.Text += String.Format("Valor Estante1 sólo de Galletitas: {0}", est1.GetValorEstante(Producto.ETipoProducto.Galletita));
            rtxtSalida.Text += String.Format("Contenido Estante1:\n{0}", Estante.MostrarEstante(est1));  
            rtxtSalida.Text += "Estante ordenado por Marca....\n";
            est1.GetProductos().Sort(FormEstante.OrdenarProductos);
            rtxtSalida.Text += Estante.MostrarEstante(est1);  
            est1 = est1 - Producto.ETipoProducto.Galletita;
            rtxtSalida.Text += String.Format("Estante1 sin Galletitas: {0}", Estante.MostrarEstante(est1));  
            rtxtSalida.Text += String.Format("Contenido Estante2:\n{0}", Estante.MostrarEstante(est2));
            est2 -= Producto.ETipoProducto.Todos;
            rtxtSalida.Text += String.Format("Contenido Estante2:\n{0}", Estante.MostrarEstante(est2));

        }
        /// <summary>
        /// guarda en un archivo de texto todos los datos de los estantes
        /// </summary>
        /// <param name="rtxt"></param>
        public static void GuardarEstante(string rtxt)
        {
            FileStream stream = new FileStream("EstantesTxt.txt",FileMode.OpenOrCreate,FileAccess.Write);
            StreamWriter escribir = new StreamWriter(stream);
            string miCadena = rtxt;
            string[] partes=miCadena.Split(new char[] {'\n'});
            foreach (string item in partes)
            {
                escribir.WriteLine(item);
            }           
            escribir.Close();
        }  
        /// <summary>
        /// Al cerrar el formulario se gurada en archivo de texto y se 
        /// serializa o se deserializa dependiendo el caso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormEstante_FormClosing(object sender, FormClosingEventArgs e)
        {
            //guardarmos en un archivo txt
            FormEstante.GuardarEstante(rtxtSalida.Text);

            //LO DE ABAJA QUEDO COMENTADO PARA PROBAR LA DESERIALIZACION

            //guardarmos en un archivo xml
            //Serializador.SerializarEstante(est1,"estante1xml.xml");
            //Serializador.SerializarEstante(est2,"estante2xml.xml");
    
        }




    
    }

}
