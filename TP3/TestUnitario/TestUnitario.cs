using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using EntidadesExcepciones;

namespace TestUnitario
{
    [TestClass]
    public class TestUnitario
    {
        [TestMethod]
        public void AlumnoRepetido()
        {
            try
            {
                Universidad universidad = new Universidad();

                Alumno alumno1 = new Alumno(1, "Juan", "Perez", "12345678", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Alumno alumno2 = new Alumno(2, "Calos", "Lopez", "12345678", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

                universidad += alumno1;
                universidad += alumno2;

                Assert.Fail("El alumno esta repetido.");
            }
            catch (Exception error)
            {
                Assert.IsInstanceOfType(error, typeof(AlumnoRepetidoException));
            }
        }

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

        [TestMethod]
        public void ValidaDni()
        {
            Alumno alumno = new Alumno(1, "Juan", "Perez", "90123456", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            Assert.AreEqual(alumno.DNI, 90123456);
        }

        [TestMethod]
        public void ListaAlumnosCorrecta()
        {
            Universidad universidad = new Universidad();
            Assert.IsNotNull(universidad.Alumnos);
        }
    }
}
