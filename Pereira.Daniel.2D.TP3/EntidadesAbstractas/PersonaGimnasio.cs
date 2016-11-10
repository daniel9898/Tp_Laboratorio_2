using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio : Persona
    {
        #region Atributos
        private int _identificador;
        #endregion

        #region Constructores
        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            if ( id >= 1 && id <= 2000 )//ponemos un limite maximo al id
            {
                this._identificador = id;
            }
            else
                throw new FormatException();           
        }
        public PersonaGimnasio()
        {
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Determina si dos objetos son del mismo tipo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType();
        }

        protected virtual string MostrarDatos()
        {
            string retorno = "";
            try
            {
                retorno = base.ToString() + "\n\nCARNET NÚMERO :" + this._identificador;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            return retorno;
        }
        /// <summary>
        /// Retorna una cadena de texto especifica
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion

        #region Sobrecargas
        /// <summary>
        /// determina si dos objetos son iguales comparando sus tipos y sus DNI
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            bool retorno = false;
            if (pg1.Equals(pg2) && pg1.DNI == pg2.DNI)
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// determina si dos objetos son diferentes comparando sus tipos y sus DNI
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion

    }
}
