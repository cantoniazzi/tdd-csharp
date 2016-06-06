using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDMatematicaMaluca;

namespace TDDMatematicaMalucaTests
{
    [TestClass]
    public class CalculoTest
    {
        [TestMethod]
        public void DeveMultiplicarNumerosMaioresQueTrinta()
        {
            Calculo calculo = new Calculo(35);

            Assert.AreEqual(35*4,calculo.CalculoMaluco());
        }

        [TestMethod]
        public void DeveMultiplicarNumerosMaioresQueDezEMenoresQueTrinta()
        {
            Calculo calculo = new Calculo(29);

            Assert.AreEqual(29 * 3, calculo.CalculoMaluco());
        }

        [TestMethod]
        public void DeveMultiplicarNumerosMenoresQueDez()
        {
            Calculo calculo = new Calculo(08);

            Assert.AreEqual(08 * 2, calculo.CalculoMaluco());
        }
    }
}
