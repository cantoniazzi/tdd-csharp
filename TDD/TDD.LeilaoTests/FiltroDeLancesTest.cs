using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDLeilao;
using System.Collections.Generic;

namespace TDD.LeilaoTests
{
    [TestClass]
    public class FiltroDeLancesTest
    {
        [TestMethod]
        public void DeveSelecionarLancesMaioresQue5000()
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
                new Lance(joao,5500),
                new Lance(joao,8000)
            });

            Assert.AreEqual(2, resultado.Count);
            Assert.AreEqual(5500, resultado[0].Valor);
        }

        [TestMethod]
        public void DeveSelecionarLancesEntre1000E3000()
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
                new Lance(joao,2000),
                new Lance(joao,1000),
                new Lance(joao,3000),
                new Lance(joao, 800)
            });

            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(2000, resultado[0].Valor);
        }

        [TestMethod]
        public void DeveSelecionarLancesEntre500E700()
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
                new Lance(joao,600),
                new Lance(joao,500),
                new Lance(joao,700),
                new Lance(joao, 800)
            });

            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(600, resultado[0].Valor);
        }

        [TestMethod]
        public void DeveEliminarMenoresQue500()
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
                new Lance(joao,300),
                new Lance(joao,400)
            });

            Assert.AreEqual(0, resultado.Count);
        }

        [TestMethod]
        public void DeveEliminarEntre3000E5000()
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
                new Lance(joao,3200),
                new Lance(joao,4900)
            });

            Assert.AreEqual(0, resultado.Count);
        }
    }
}
