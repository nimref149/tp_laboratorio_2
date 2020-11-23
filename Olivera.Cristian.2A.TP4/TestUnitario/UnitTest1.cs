using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        
        /// <summary>
        /// //Test unitario que verifica que 2 bananas sean iguales
        /// </summary>
        [TestMethod]
        public void VerificarIgualdadBananas_Ok()
        {
          
            Banana v1 = new Banana("amarillo", 6, "brasil");
            Banana v2 = new Banana("amarillo", 6, "brasil");

            bool rta = v1 == v2;

            Assert.IsTrue(rta);

        }

        /// <summary>
        /// Test unitario que verifica que se lanze una excepcion en caso de que se supere la cantidad maxima agregada al estante
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(EstanteLlenoException))]
        public void AgregarBananas_Exception()
        {
            Estante<Banana> v = new Estante<Banana>(21.5, 1); ;
            Banana v1 = new Banana("amarillo", 6, "brasil");
            Banana v2 = new Banana("verde", 8, "colombia");

            v += v1;
            v += v2;
        }
    }
}
