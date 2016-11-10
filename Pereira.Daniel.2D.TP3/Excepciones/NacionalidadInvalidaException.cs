using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        private string _mensajeBase = "La nacionalidad no se condice con el DNI";

        public string Message
        {
            get { return this._mensajeBase; }
        }

        public NacionalidadInvalidaException()
            : base()
        { }
        public NacionalidadInvalidaException(string message)
            : base(message)
        {
            this._mensajeBase = message;
        }
    }
}
