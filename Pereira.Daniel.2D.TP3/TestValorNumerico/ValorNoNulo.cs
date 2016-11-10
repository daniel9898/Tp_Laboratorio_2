using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace Utest
{
    [TestClass]
    public class ValorNoNulo
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestNull()
        {
            // se verifica que lanze la excepcion cuando el apellido sea incorrecto 
            int id = 45;
            string nombre = "Daniel";
            string apellido = "Pereira9999";
            string dni = "456888";
            Alumno.ENacionalidad nacionalidad = Alumno.ENacionalidad.Argentino;
            Gimnasio.EClases claseQueToma = Gimnasio.EClases.Yoga;

            Alumno alu1 = new Alumno(id, nombre, apellido, dni, nacionalidad, claseQueToma);
        }
    }
}
