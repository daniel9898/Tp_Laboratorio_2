using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace Utest
{
    [TestClass]
    public class IdValido
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestID()
        {
            // se verifica que lanze la excepcion cuando el ID no este entre los 
            //limites minimo y maximo
            int id = 4565; // maximo 2000
            string nombre = "Jorge";
            string apellido = "Pe";
            string dni = "456655";
            Alumno.ENacionalidad nacionalidad = Alumno.ENacionalidad.Argentino;
            Gimnasio.EClases claseQueToma = Gimnasio.EClases.Yoga;

            Alumno alu1 = new Alumno(id, nombre, apellido, dni, nacionalidad, claseQueToma);
         
        }
    }
}
