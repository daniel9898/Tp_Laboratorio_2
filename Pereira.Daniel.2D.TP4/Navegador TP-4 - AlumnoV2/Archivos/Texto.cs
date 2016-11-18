using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{

    public class Texto : IArchivo<string>
    {
        private string _archivo;

        public Texto(string archivo)
        {
            this._archivo = archivo;
        }

        bool IArchivo<string>.guardar(string datos)
        {
            bool retorno = true;
            try
            {
                FileStream stream = new FileStream(_archivo, FileMode.Append, FileAccess.Write);
                StreamWriter escribir = new StreamWriter(stream);
                escribir.WriteLine(datos);
                escribir.Close();
            }
            catch (Exception)
            {
                retorno = false;
            }
            return retorno;
        }

        bool IArchivo<string>.leer(out List<string> datos)
        {
            bool retorno = true;
            datos = new List<string>();
            try
            {
                FileStream stream = new FileStream(_archivo, FileMode.Open, FileAccess.Read);
                TextReader lector = new StreamReader(stream);

                string totalTexto = lector.ReadToEnd();
                string[] partes = totalTexto.Split(new char[] { '\n' });
                foreach (string item in partes)
                {
                    datos.Add(item);
                }

                lector.Close();
            }
            catch (Exception)
            {
                retorno = false;
            }
            return retorno;
        }
    }
}
