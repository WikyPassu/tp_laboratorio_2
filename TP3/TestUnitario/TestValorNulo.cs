using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using EntidadesExcepciones;

namespace TestUnitario
{
    [TestClass]
    public class TestValorNulo
    {
        [TestMethod]
        public void ListaAlumnosCorrecta()
        {
            Universidad universidad = new Universidad();
            Assert.IsNotNull(universidad.Alumnos);
        }
    }
}
