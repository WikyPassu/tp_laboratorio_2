﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class TestUnitario
    {
        /// <summary>
        /// Verifica si la lista de paquetes del correo esta instanciada.
        /// </summary>
        [TestMethod]
        public void ListaPaquetesInstanciada()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        /// <summary>
        /// Verifica si no se pueden cargar dos paquetes con el mismo Tracking ID.
        /// </summary>
        [TestMethod]
        public void PaqueteRepetido()
        {
            try
            {
                Correo correo = new Correo();

                Paquete unPaquete = new Paquete("Av. Mitre 750", "123-456-7890");
                Paquete otroPaquete = new Paquete("Av. San Martin 437", "987-450-1234");

                correo += unPaquete;
                correo += otroPaquete;
                correo += unPaquete;

                Assert.Fail("Deberia decir que el Tracking ID ya figura en la lista de envios.");
            }
            catch (Exception error)
            {
                Assert.IsInstanceOfType(error, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
