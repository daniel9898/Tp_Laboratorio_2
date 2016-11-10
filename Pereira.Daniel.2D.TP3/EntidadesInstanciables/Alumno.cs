using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : PersonaGimnasio
    {
        #region Atributos
        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;
        #endregion

        #region Enumerados
        public enum EEstadoCuenta
        {
            Ninguno,
            AlDia,
            MesPrueba,
            Deudor
        }
        #endregion

        #region Constructores
        public Alumno(int id,string nombre, string apellido, string dni, ENacionalidad nacionalidad,Gimnasio.EClases claseQueToma)
            : base(id,nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id,string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id,nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        public Alumno()
        { }
        #endregion

        #region Propiedades
        public Gimnasio.EClases ClaseQueToma
        {
            get { return this._claseQueToma; }
        }
        public EEstadoCuenta EstadoDeCuenta
        {
            get { return this._estadoCuenta; }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Verifica que el estado de un alumno no sea deudor y que tome una clase especifica
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            bool retorno = false;
            if (a._estadoCuenta != EEstadoCuenta.Deudor && a._claseQueToma == clase)
                retorno = true;

            return retorno;
        }
        /// <summary>
        /// comprueba si un alumno no toma una clase especifica
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            bool retorno = false;
            if (a._claseQueToma != clase)
                retorno = true;
            return retorno;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// retorna un string especificando la clase que toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            string retorno = "";
            try
            {
                retorno = "\nTOMA CLASES DE " + this._claseQueToma.ToString()+"\n";
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            return retorno;
        }
        /// <summary>
        /// retorna un string con todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            string retorno = "";
            try
            {
                retorno = "\n" + base.MostrarDatos() + "\n\nESTADO DE CUENTA :" + this._estadoCuenta.ToString() + ParticiparEnClase();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            return retorno;
        }
        /// <summary>
        /// Retorna una cadena de texto con todos los datos del alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
        #endregion
    }
}
