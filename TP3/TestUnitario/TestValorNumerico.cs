using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using EntidadesExcepciones;

namespace TestUnitario
{
    [TestClass]
    public class TestValorNumerico
    {
        [TestMethod]
        public void ValidaDni()
        {
            Alumno alumno = new Alumno(1, "Juan", "Perez", "90123456", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            Assert.AreEqual(alumno.DNI, 90123456);
        }
    }
}
