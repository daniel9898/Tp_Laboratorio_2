using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        private string _message = "A ocurrido un error con el archivo solicitado";
                                             
        public ArchivosException(Exception innerException):base(innerException.Message,innerException)
        {
        }
        public string Message
        {
            get { return this._message +"\n"+ InnerException.Message ; }
        }

    }
}
