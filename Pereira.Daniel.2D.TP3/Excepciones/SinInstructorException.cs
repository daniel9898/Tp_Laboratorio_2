using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinInstructorException : Exception
    {
        private string _message = "No hay Instructor para la clase";
        public SinInstructorException()
            : base()
        { }
        public string Message
        {
            get { return this._message; }
        }
    }
}
