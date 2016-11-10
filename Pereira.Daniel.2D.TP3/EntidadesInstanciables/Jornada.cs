using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clases;
        private Instructor Instructor;
        #endregion

        #region Constructores
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clases = clase;
            this.VerificarInstructor(instructor);
        }
        #endregion

        #region Propiedades
        public List<Alumno> ListaAlumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public Gimnasio.EClases Clase
        {
            get { return this._clases; }
            set { this._clases = value; }
        }

        public Instructor InstructorClase
        {
            get { return this.Instructor; }
            set { this.Instructor = value; }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Verifica que un Instructor pueda ejercer la clase de una Jornada especifica
        /// </summary>
        /// <param name="inst"></param>
        /// <returns></returns>
        private void VerificarInstructor(Instructor inst)
        {
            foreach (Gimnasio.EClases clas in inst.ListaClases)
            {
                if (this._clases == clas)           
                    this.Instructor = inst;            
            }   
        }
        /// <summary>
        /// Retorna una cadena de texto con toda la informacion de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string retorno = "";
            retorno += "CLASE DE " + this._clases.ToString() + " POR " + this.Instructor.ToString() + "\n\nALUMNOS :\n";
            foreach (Alumno a in this._alumnos)
                retorno += a.ToString();
            return retorno += "\n<----------------------------------------------------------->\n\n";
        }
        /// <summary>
        /// Guarda los datos en un archivo con formato txt
        /// </summary>
        /// <param name="jor"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jor)
        {
            Texto archivo = new Texto();
            return ((IArchivo<string>)archivo).Guardar("JORNADA.txt", jor.ToString());
        }
        /// <summary>
        /// Lee los datos desde un archivo con formato txt
        /// </summary>
        /// <returns></returns>
        public static bool leer()
        {
            Texto archivo = new Texto();
            string dato = "";
            bool retorno = ((IArchivo<string>)archivo).Leer("JORNADA.txt", out dato);
            Console.WriteLine(dato);
            return retorno;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Verifica si un alumno esta en una jornada
        /// </summary>
        /// <param name="jor"></param>
        /// <param name="alum"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada jor, Alumno alum)
        {
            bool retorno = false;
            for (int i = 0; i < jor._alumnos.Count; i++)
            {
                if (alum == jor._alumnos[i])
                    retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Verifica si un alumno No esta en una jornada
        /// </summary>
        /// <param name="jor"></param>
        /// <param name="alum"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada jor, Alumno alum)
        {
            return !(jor == alum);
        }
        /// <summary>
        /// Agrega un alumno a la jornada verificando antes que ya no se encuentre en ella,
        /// que se halla anotado en la misma clase que realiza la jornada y que su estado sea distinto 
        /// de deudor
        /// </summary>
        /// <param name="jor"></param>
        /// <param name="alum"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada jor, Alumno alum)
        {
            if (jor != alum && alum.ClaseQueToma == jor._clases && alum.EstadoDeCuenta != Alumno.EEstadoCuenta.Deudor)
                jor._alumnos.Add(alum);
            return jor;
        }
        #endregion

    }
}
