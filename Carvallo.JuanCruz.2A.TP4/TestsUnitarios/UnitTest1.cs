using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestsUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestListPaquetes_OK()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestAgregarPaquetes_Falla()
        {
            Correo correo = new Correo();
            Paquete paqueteUno = new Paquete("Calle Uno", "1111111111");
            Paquete paqueteDos = new Paquete("Calle Dos", "1111111112");
            Paquete paqueteTres = new Paquete("Calle Tres", "1111111111");

            correo += paqueteUno;
            correo += paqueteDos;
            correo += paqueteTres;
        }

    }
}
