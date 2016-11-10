using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    public sealed class Instructor : PersonaGimnasio
    {
        #region Atributos
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;
        #endregion

        #region Constructores
        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this.RandomClases();
            this.RandomClases();
        }
        public Instructor()
        {
        }
        static Instructor()
        {
            _random = new Random();
        }
        #endregion

        #region Propiedades
        [XmlIgnore]
        public  Queue<Gimnasio.EClases> ListaClases
        {
            get
            {              
               return this._clasesDelDia;                          
            }
        }
        #endregion

        #region Metodos
        ///<summary>
        ///Genera una clase aleatoreamente y se la asigna al objeto instructor actual 
        ///</summary>
        private void RandomClases()
        {
            this._clasesDelDia.Enqueue(((Gimnasio.EClases)_random.Next(0, 4)));
        }
        /// <summary>
        /// retorna una cadena con las clases del dia del objeto instructor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            string retorno = "\n\nCLASES DEL DIA :";
            foreach (Gimnasio.EClases alum in this._clasesDelDia)
            {
                retorno += "\n" + alum.ToString();
            }
            return retorno;
        }
        /// <summary>
        /// retorna una cadena de texto con todos los datos del objeto instructor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + ParticiparEnClase();
        }
        /// <summary>
        /// retorna una cadena de texto con todos los datos del objeto instructor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Verifica si un instructor da una determinada clase
        /// </summary>
        /// <param name="ins"></param>
        /// <param name="clases"></param>
        /// <returns></returns>
        public static bool operator ==(Instructor ins, Gimnasio.EClases clase)
        {
            bool retorno = false;
            foreach (Gimnasio.EClases a in ins._clasesDelDia)
            {
                if (a == clase)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Verifica si un instructor No da una determinada clase
        /// </summary>
        /// <param name="ins"></param>
        /// <param name="clases"></param>
        /// <returns></returns>
        public static bool operator !=(Instructor ins, Gimnasio.EClases clases)
        {
            return !(ins == clases);
        }
        #endregion
    }
}
