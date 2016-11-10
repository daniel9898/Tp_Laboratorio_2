using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda los datos de tipo string en un archivo con formato texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool IArchivo<string>.Guardar(string archivo,string datos)
        {
            bool retorno = true;
            try
            {
                FileStream stream = new FileStream(archivo, FileMode.Append, FileAccess.Write);
                StreamWriter escribir = new StreamWriter(stream);
                string miCadena = datos;
                string[] partes = miCadena.Split(new char[] { '\n' });
                foreach (string item in partes)
                {
                    escribir.WriteLine(item);
                }
                escribir.Close();
            }
            catch (Exception e)
            {
                retorno = false;//si entro aca significa que hubo un problema
                throw new ArchivosException(e);
            }
            return retorno;   
        }
        /// <summary>
        /// Lee los datos desde un archivo con formato txt
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool IArchivo<string>.Leer(string archivo,out string datos)
        {
            bool retorno = true;
            try
            {
                FileStream stream = new FileStream(archivo, FileMode.Open, FileAccess.Read);
                TextReader lector = new StreamReader(stream);
                datos = lector.ReadToEnd();
                lector.Close();
            }
            catch (Exception e)
            {
                retorno = false;//si entro aca significa que hubo un problema
                throw new ArchivosException(e);
            }
            return retorno; 
        }
    }
}
