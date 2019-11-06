using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesExcepciones;
using EntidadesInstanciables;

namespace TestUnitario3
{
    [TestClass]
    public class TestUnitario3
    {
        [TestMethod]
        public void ValidaDNI()
        {
            Alumno alumno = new Alumno(1, "Juan", "Perez", "90123456", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            Assert.AreEqual(alumno.DNI, 90123456);
        }
    }
}
