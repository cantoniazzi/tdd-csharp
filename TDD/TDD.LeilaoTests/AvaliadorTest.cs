using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDLeilao;
using System.Collections.Generic;
using System;

namespace TDD.LeilaoTests
{
    [TestClass]
    public class AvaliadorTest
    {
        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario jose;
        private Usuario maria;
        
        [TestInitialize]
        public void CriaAvaliador()
        {
            this.leiloeiro = new Avaliador();
            this.joao = new Usuario("João");
            this.jose = new Usuario("José");
            this.maria = new Usuario("Maria");

            Console.WriteLine("inicializando teste!");
        }

        [TestCleanup]
        public void Finaliza()
        {
            Console.WriteLine("fim");
        }

        [TestMethod]
        public void TestMethodAvaliador()
        {
            Leilao leilao = new CriadoDeLeilao().Para("Moutain Bike")
                .Lance(this.maria, 250.0)
                .Lance(this.joao, 300.0)
                .Lance(this.jose, 400.0)
                .Constroi();
            
            this.CriaAvaliador();
            this.leiloeiro.Avalia(leilao);
            
            double maiorEsperado = 400;
            double menorEsperado = 250;
            //double mediaEsperada = (250.0 + 300.0 + 400.0) / 3;

            //tests
            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance);
            //Assert.AreEqual(mediaEsperada, avaliador.MediaLance);

        }

        [TestMethod]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Leilao leilao = new CriadoDeLeilao().Para("Moutain Bike")
                .Lance(this.joao, 100.0)
                .Lance(this.maria, 200.0)
                .Lance(this.joao, 300.0)
                .Constroi();
            
            this.CriaAvaliador();
            this.leiloeiro.Avalia(leilao);
            IList<Lance> maiores = this.leiloeiro.TresMaiores;

            //tests
            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(300, maiores[0].Valor);
            Assert.AreEqual(200, maiores[1].Valor);
            Assert.AreEqual(100, maiores[2].Valor);
        }

        [TestMethod]
        public void DeveDevolverTodosLancesCasoTenhaApenasDoisLances()
        {
            Leilao leilao = new CriadoDeLeilao().Para("Playstation 3 Novo")
                .Lance(this.joao, 100.0)
                .Lance(this.maria, 200.0)
                .Constroi();
            
            this.CriaAvaliador();
            this.leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(2, maiores.Count);
            Assert.AreEqual(200, maiores[0].Valor);
            Assert.AreEqual(100, maiores[1].Valor);
        }

        [TestMethod]
        public void TestaAvaliadorComApenasUmLance()
        {
            Leilao leilao = new CriadoDeLeilao().Para("Travel to England")
                .Lance(this.joao, 200.0)
                .Constroi();
            
            this.CriaAvaliador();
            this.leiloeiro.Avalia(leilao);

            //compare
            double maiorEsperado = 200;
            double menorEsperado = 200;
            
            //tests
            Assert.AreEqual(maiorEsperado, this.leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado, this.leiloeiro.MenorLance);
        }

        [TestMethod]
        public void DeveDevolverListaVaziaCasoNaoHajaLances()
        {
            Leilao leilao = new Leilao("Playstation 3 Novo");
            Avaliador leiloeiro = new Avaliador();

            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;
            Assert.AreEqual(0, maiores.Count);
        }

        [TestMethod]
        public void TestaAvaliadorComValoresAleatorios()
        {
            Leilao leilao = new CriadoDeLeilao().Para("Travel to England")
                .Lance(this.maria, 400)
                .Lance(this.jose, 300)
                .Lance(this.joao, 200)
                .Lance(this.jose, 100)
                .Constroi();

            this.CriaAvaliador();
            this.leiloeiro.Avalia(leilao);

            //compare
            double maiorEsperado = 400;
            double menorEsperado = 100;
            
            //tests
            Assert.AreEqual(maiorEsperado, this.leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado, this.leiloeiro.MenorLance);
        }

        [TestMethod]
        public void Testa2LancesEmSequenciaDeUsuario()
        {
            Leilao leilao = new CriadoDeLeilao().Para("Travel to Canada")
                .Lance(this.maria, 1000)
                .Lance(this.maria, 2000)
                .Lance(this.maria, 3000)
                .Lance(this.jose, 4000)
                .Constroi();
            
            //tests
            Assert.AreEqual(2, leilao.Lances.Count);
            
            leilao.Propoe(new Lance(this.maria, 1000));

            //tests
            Assert.AreEqual(3, leilao.Lances.Count);
        }

        [TestMethod]
        public void NaoDeveAceitarMaisDoQue5LancesDeUmMesmoUsuario()
        {
            Leilao leilao = new CriadoDeLeilao().Para("Travel to Canada")
                .Lance(this.jose, 1000)
                .Lance(this.maria, 2000)
                .Lance(this.jose, 1000)
                .Lance(this.maria, 2000)
                .Lance(this.jose, 1000)
                .Lance(this.maria, 2000)
                .Lance(this.jose, 1000)
                .Lance(this.maria, 2000)
                .Lance(this.jose, 1000)
                .Lance(this.maria, 2000)
                .Lance(this.jose, 1000)
                .Constroi();
            
            //tests
            Assert.AreEqual(10, leilao.Lances.Count);
        }

        [TestMethod]
        public void TestaDobrarLanceDeUmUsuario()
        {
            Leilao leilao = new CriadoDeLeilao().Para("Travel to Canada")
                .Lance(this.jose, 1000)
                .Lance(this.maria, 1100)
                .Constroi();
            
            leilao.DobrarLance(this.jose);

            Assert.AreEqual(3, leilao.Lances.Count);
        }

        [TestMethod]
        public void NaoDeveDobrarCasoUsuarioNaoTenhaDadoLance()
        {
            Leilao leilao = new CriadoDeLeilao().Para("Travel to Canada")
                .Lance(this.joao, 1000)
                .Constroi();
            
            leilao.DobrarLance(this.jose);

            Assert.AreEqual(1, leilao.Lances.Count);

        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void NaoDeveAvailiarLeilaoSemLance()
        {
            Leilao leilao = new CriadoDeLeilao()
                .Para("Videocassete")
                .Constroi();

            leiloeiro.Avalia(leilao);

        }
    }
}
