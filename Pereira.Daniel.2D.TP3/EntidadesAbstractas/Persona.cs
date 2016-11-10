using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public class Persona
    {
        #region Atributos
        private string _apellido;
        private string _nombre;
        private int _dni;
        private ENacionalidad _nacionalidad;
        #endregion

        #region Enumerados
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Valida que el DNI sea correcto y lo setea
        /// </summary>
        public int DNI
        {
            get { return this._dni; }
            set
            {
                try
                {
                    int retorno = ValidarDni(this._nacionalidad, value);
                    if (retorno != -1)// si retorno vale -1 significa que es un dni invalido
                        this._dni = value;
                    else
                    {
                        throw new DniInvalidoException();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            }
        }
        /// <summary>
        /// Valida que el nombre sea correcto y lo setea
        /// </summary>
        public string Nombre
        {
            get { return this._nombre; }
            set
            {
                try
                {
                    string retorno = ValidarNombreApellido(value);
                    if (retorno != null)
                        this._nombre = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
        /// <summary>
        /// Valida que el Apellido sea correcto y lo setea
        /// </summary>
        public string Apellido
        {
            get { return this._apellido; }
            set
            {
                string retorno = ValidarNombreApellido(value);
                if (retorno != null)
                    this._apellido = value;
                else
                    throw new NullReferenceException();
            }
        }
        /// <summary>
        /// Valida que la nacionalidad sea la correcto y la setea
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set
            {
                try
                {
                    if (value == ENacionalidad.Argentino || value == ENacionalidad.Extranjero)
                        this._nacionalidad = value;
                    else
                    {
                        throw new NacionalidadInvalidaException("Nacionalidad Invalida");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
        /// <summary>
        /// Valida que el dni sea correcto y lo setea
        /// </summary>
        public string StringToDNI
        {
            set
            {
                int retorno = ValidarDni(this._nacionalidad, value);
                if (retorno != -1)
                    this._dni = retorno;
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad nose condice con el número de DNI");
                }
            }
        }
        #endregion

        #region Constructores
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public Persona()
        {
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra todos los datos de un objeto persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string retorno = "";
            try
            {
                retorno = "NOMBRE COMPLETO : " + this._apellido.ToString() + "," + this._nombre.ToString() + "\nNACIONALIDAD :" + this._nacionalidad.ToString();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            return retorno;
        }
        /// <summary>
        /// Valida que la nacionalidad cumpla con los parametros del numero de Dni
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = -1;
            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato < 89999999)
            {
                retorno = dato;
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato > 89999999 && dato < 500000000)
            {
                retorno = dato;
            }

            return retorno;
        }
        /// <summary>
        /// Valida que la nacionalidad cumpla con los parametros del numero de Dni
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = -1;
            int dni;

            if (int.TryParse(dato, out dni))
            {
                retorno = ValidarDni(nacionalidad, dni);
                if (retorno != -1)
                    retorno = dni;
            }
            return retorno;
        }
        /// <summary>
        /// Valida que sea un nombre o apellido valido,solo letras
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            Regex rgx = new Regex("^[A-Za-z ]+$");
            if (rgx.IsMatch(dato))
                return dato;
            else
                return null;
        }
        #endregion
    }
}
