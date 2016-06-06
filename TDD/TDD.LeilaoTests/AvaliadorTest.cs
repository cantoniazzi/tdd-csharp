using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDLeilao;
using System.Collections.Generic;

namespace TDD.LeilaoTests
{
    [TestClass]
    public class AvaliadorTest
    {
        [TestMethod]
        public void TestMethodAvaliador()
        {
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Moutain Bike");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            //actions
            Avaliador avaliador = new Avaliador();
            avaliador.Avalia(leilao);
            
            double maiorEsperado = 400;
            double menorEsperado = 250;
            //double mediaEsperada = (250.0 + 300.0 + 400.0) / 3;

            //tests
            Assert.AreEqual(maiorEsperado, avaliador.MaiorLance);
            Assert.AreEqual(menorEsperado, avaliador.MenorLance);
            //Assert.AreEqual(mediaEsperada, avaliador.MediaLance);

        }

        [TestMethod]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Moutain Bike");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));
            leilao.Propoe(new Lance(joao, 300.0));

            //actions
            Avaliador avaliador = new Avaliador();
            avaliador.Avalia(leilao);
            IList<Lance> maiores = avaliador.TresMaiores;

            //tests
            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(300, maiores[0].Valor);
            Assert.AreEqual(200, maiores[1].Valor);
            Assert.AreEqual(100, maiores[2].Valor);

        }

        [TestMethod]
        public void DeveDevolverTodosLancesCasoTenhaApenasDoisLances()
        {
            Usuario joao = new Usuario("João");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));

            Avaliador leiloeiro = new Avaliador();

            leiloeiro.Avalia(leilao);
            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(2, maiores.Count);
            Assert.AreEqual(200, maiores[0].Valor);
            Assert.AreEqual(100, maiores[1].Valor);
        }

        [TestMethod]
        public void TestaAvaliadorComApenasUmLance()
        {
            Usuario cassio = new Usuario("Cassio");
            Leilao leilao = new Leilao("Travel to England");

            leilao.Propoe(new Lance(cassio, 200));

            //actions
            Avaliador avaliador = new Avaliador();
            avaliador.Avalia(leilao);

            //compare
            double maiorEsperado = 200;
            double menorEsperado = 200;
            
            //tests
            Assert.AreEqual(maiorEsperado, avaliador.MaiorLance);
            Assert.AreEqual(menorEsperado, avaliador.MenorLance);
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
            Usuario cassio = new Usuario("Cassio");
            Usuario josias = new Usuario("Josias");
            Usuario meredith = new Usuario("Meredith");
            Usuario bob = new Usuario("Bob");

            Leilao leilao = new Leilao("Travel to England");

            leilao.Propoe(new Lance(cassio, 400));
            leilao.Propoe(new Lance(bob, 300));
            leilao.Propoe(new Lance(josias, 200));
            leilao.Propoe(new Lance(meredith, 100));
            
            //actions
            Avaliador avaliador = new Avaliador();
            avaliador.Avalia(leilao);

            //compare
            double maiorEsperado = 400;
            double menorEsperado = 100;
            
            //tests
            Assert.AreEqual(maiorEsperado, avaliador.MaiorLance);
            Assert.AreEqual(menorEsperado, avaliador.MenorLance);
        }

        [TestMethod]
        public void Testa2LancesEmSequenciaDeUsuario()
        {
            Usuario cassio = new Usuario("Cassio");
            Usuario josias = new Usuario("Josias");

            Leilao leilao = new Leilao("Travel to Canada");

            leilao.Propoe(new Lance(cassio, 1000));
            leilao.Propoe(new Lance(cassio, 2000));
            leilao.Propoe(new Lance(cassio, 3000));
            leilao.Propoe(new Lance(josias, 4000));
            
            //tests
            Assert.AreEqual(2, leilao.Lances.Count);
            
            leilao.Propoe(new Lance(cassio, 1000));

            //tests
            Assert.AreEqual(3, leilao.Lances.Count);
        }

        [TestMethod]
        public void NaoDeveAceitarMaisDoQue5LancesDeUmMesmoUsuario()
        {
            Usuario cassio = new Usuario("Cassio");
            Usuario josias = new Usuario("Josias");

            Leilao leilao = new Leilao("Travel to Canada");

            leilao.Propoe(new Lance(cassio, 1000));
            leilao.Propoe(new Lance(josias, 2000));
            leilao.Propoe(new Lance(cassio, 1000));
            leilao.Propoe(new Lance(josias, 2000));
            leilao.Propoe(new Lance(cassio, 1000));
            leilao.Propoe(new Lance(josias, 2000));
            leilao.Propoe(new Lance(cassio, 1000));
            leilao.Propoe(new Lance(josias, 2000));
            leilao.Propoe(new Lance(cassio, 1000));
            leilao.Propoe(new Lance(josias, 2000));
            leilao.Propoe(new Lance(cassio, 1000));

            //tests
            Assert.AreEqual(10, leilao.Lances.Count);
        }

        [TestMethod]
        public void TestaDobrarLanceDeUmUsuario()
        {
            Usuario cassio = new Usuario("Cassio");
            Usuario josias = new Usuario("Josias");

            Leilao leilao = new Leilao("Travel to Canada");

            leilao.Propoe(new Lance(cassio, 1000));
            leilao.Propoe(new Lance(josias, 1100));
            leilao.DobrarLance(cassio);

            Assert.AreEqual(3, leilao.Lances.Count);
        }

        [TestMethod]
        public void NaoDeveDobrarCasoUsuarioNaoTenhaDadoLance()
        {
            Usuario cassio = new Usuario("Cassio");
            Usuario josias = new Usuario("Josias");

            Leilao leilao = new Leilao("Travel to Canada");

            leilao.Propoe(new Lance(cassio, 1000));

            leilao.DobrarLance(josias);

            Assert.AreEqual(1, leilao.Lances.Count);

        }

        
    }
}
