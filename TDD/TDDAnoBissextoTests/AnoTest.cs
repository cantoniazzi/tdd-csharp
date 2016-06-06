using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDAnoBissexto;

namespace TDDAnoBissextoTests
{
    [TestClass]
    public class AnoTest
    {
        [TestMethod]
        public void VerificaSeAnoEhBissexto()
        {
            Ano ano = new Ano(2016);
            Ano ano2 = new Ano(2015);

            Assert.AreEqual(true, ano2.VerificaSeEhBissexto());
            Assert.AreEqual(true,ano.VerificaSeEhBissexto());
            
        }
    }
}
