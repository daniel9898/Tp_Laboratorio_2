using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Jornada))]
    public class Gimnasio
    {
        #region Atributos
        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;
        #endregion

        #region Enumerados
        public enum EClases
        {
            Natacion,
            Pilates,
            CrossFit,
            Yoga
        }
        #endregion

        #region Constructores
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }
        public List<Instructor> Instructores
        {
            get { return this._instructores; }
            set { this._instructores = value; }
        }
        public List<Jornada> Jornada
        {
            get { return this._jornada; }
            set { this._jornada = value; }
        }
        /// <summary>
        /// indexa la lista de jornada
        /// </summary>
        /// <param name="indice"></param>
        /// <returns></returns>
        public Jornada this[int indice]
        {
            get
            {
                try
                {
                    return this._jornada[indice];
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Retorna una cadena con  todos los datos del gimnasio
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        private static string MostrarDatos(Gimnasio gim)
        {
            string retorno = "JORNADA :\n";

            for (int i = 0; i < gim._jornada.Count; i++)
            {
                retorno += gim._jornada[i].ToString();
            }
            return retorno;
        }
        /// <summary>
        /// Retorna una cadena con  todos los datos del gimnasio
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }
        /// <summary>
        /// Guarda los datos del gimnasio en un archivo con formato xml
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Guardar(Gimnasio gim)
        {
            Xml<Gimnasio> xml = new Xml<Gimnasio>();
            return ((IArchivo<Gimnasio>)xml).Guardar("GIMNASIO.xml", gim);
        }
        /// <summary>
        /// Lee los datos del gimnasio desde un archivo con formato xml
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Leer(Gimnasio gim)
        {
            Xml<Gimnasio> xml = new Xml<Gimnasio>();
            bool retorno = ((IArchivo<Gimnasio>)xml).Leer("GIMNASIO.xml", out gim);
            Console.WriteLine(gim.ToString());
            return retorno;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Verifica si un alumno esta anotado en un gimnasio
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            bool retorno = false;
            int i;
            for (i = 0; i < g._alumnos.Count; i++)
            {
                if (a == g._alumnos[i])
                    retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Verifica si un alumno No esta anotado en un gimnasio
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Verifica si un instructor esta anotado en un gimnasio
        /// </summary>
        /// <param name="g"></param>
        /// <param name="ins"></param>
        /// <returns></returns>
        public static bool operator ==(Gimnasio g, Instructor ins)
        {
            bool retorno = false;
            for (int i = 0; i < g._instructores.Count; i++)
            {
                if (ins == g._instructores[i])
                    retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Verifica si un instructor No esta anotado en un gimnasio
        /// </summary>
        /// <param name="g"></param>
        /// <param name="ins"></param>
        /// <returns></returns>
        public static bool operator !=(Gimnasio g, Instructor ins)
        {
            return !(g == ins);
        }
        /// <summary>
        /// Retorna el primer instructor que pueda dar la clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Instructor operator ==(Gimnasio g, Gimnasio.EClases clase)
        {
            for (int i = 0; i < g._instructores.Count; i++)
            {
                foreach (Gimnasio.EClases cla in g._instructores[i].ListaClases)
                {
                    if (cla == clase)
                        return g._instructores[i];
                }
            }
            return null;
        }
        /// <summary>
        /// Retorna el primer instructor que No pueda dar la clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Instructor operator !=(Gimnasio g, Gimnasio.EClases clase)
        {
            for (int i = 0; i < g._instructores.Count; i++)
            {
                foreach (Gimnasio.EClases cla in g._instructores[i].ListaClases)
                {
                    if (cla != clase)
                        return g._instructores[i];
                }
            }
            return null;
        }
        /// <summary>
        /// Agrega un alumno al gimnasio validando que ya no este ingresado
        /// </summary>
        /// <param name="gim"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio gim, Alumno a)
        {
            if (gim != a)
                gim._alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();
            return gim;
        }
        /// <summary>
        /// Agrega un instructor al gimnasio validando que ya no este ingresado
        /// </summary>
        /// <param name="gim"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio gim, Instructor i)
        {
            if (gim != i)
                gim._instructores.Add(i);
            return gim;
        }
        /// <summary>
        /// Agrega una nueva clase al gimnasio junto con un instructor que pueda darla
        /// y los alumnos que esten anotados para esa clase
        /// </summary>
        /// <param name="gim"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio gim, Gimnasio.EClases clase)
        {
            Instructor inst = gim == clase;
            try
            {
                Jornada jor = new Jornada(clase, inst);
                gim._jornada.Add(jor);
                for (int i = 0; i < gim._alumnos.Count; i++)
                {
                    if (gim._alumnos[i] == clase)
                        jor += gim._alumnos[i];
                }
            }
            catch (NullReferenceException)//si inst queda en null significa que no hay instructor
            {                             //para la clase
                throw new SinInstructorException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return gim;
        }
        #endregion

    }
}
