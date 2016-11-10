using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string _mensajeBase = "Dni Incorrecto";

        public string Message
        {
            get { return this._mensajeBase; }
        }

        public DniInvalidoException()
            : base()
        { }
        public DniInvalidoException(Exception e)
            : this(e.Message, e)
        {
        }
        public DniInvalidoException(string message)
            : base(message)
        {
            this._mensajeBase = message;
        }
        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        {
            this._mensajeBase = e.Message;
        }

    }
}
