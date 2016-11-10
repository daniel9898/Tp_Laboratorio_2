using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace Utest
{
    [TestClass]
    public class DniValido
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestDniValido()
        {
            // se verifica que lanze la excepcion cuando el DNI sea incorrecto dependiendo
            //de su nacionalidad
            int id = 45;
            string nombre ="Daniel";
            string apellido = "Pereira";
            string dni = "456888";
            Alumno.ENacionalidad nacionalidad = Alumno.ENacionalidad.Extranjero;
            Gimnasio.EClases claseQueToma = Gimnasio.EClases.Yoga;
      
            Alumno alu1 = new Alumno(id,nombre,apellido,dni,nacionalidad,claseQueToma);
            
        }
    }
}
