using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TDDLeilao;

namespace TDD.LeilaoTests
{
    [TestClass]
    public class LanceTest
    {
        private Usuario cassio;
        
        [TestInitialize]
        public void CriaUsuario()
        {
            this.cassio = new Usuario("cassio");
        }
        
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ValorDoLanceTemQueSerMaiorQueZero()
        {
            Lance lance = new Lance(this.cassio, 0);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ValorDoLanceTemQueSerPositivo()
        {
            Lance lance = new Lance(this.cassio, -10);
        }
    }
}
