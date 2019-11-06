using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesExcepciones;
using EntidadesInstanciables;

namespace TestUnitario4
{
    [TestClass]
    public class TestUnitario4
    {
        [TestMethod]
        public void ListaAlumnosCorrecta()
        {
            Universidad universidad = new Universidad();
            Assert.IsNotNull(universidad.Alumnos);
        }
    }
}
