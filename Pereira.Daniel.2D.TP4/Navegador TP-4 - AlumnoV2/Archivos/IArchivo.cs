using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// guarda los datos en un archivo con un formato especifico
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool guardar(T datos);
        /// <summary>
        /// lee los datos desde un archivo con formato especifico y los retorna en una
        /// lista del tipo especificado
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool leer(out List<T> datos);
    }
}
