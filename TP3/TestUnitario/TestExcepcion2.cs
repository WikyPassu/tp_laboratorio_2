using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using EntidadesExcepciones;

namespace TestUnitario
{
    [TestClass]
    public class TestExcepcion2
    {
        [TestMethod]
        public void ValidaNacionalidad()
        {
            try
            {
                Alumno alumno = new Alumno(1, "Juan", "Perez", "12345678", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
                Assert.Fail("La nacionalidad no se condice con el DNI.");
            }
            catch (Exception error)
            {
                Assert.IsInstanceOfType(error, typeof(NacionalidadInvalidaException));
            }
        }
    }
}
