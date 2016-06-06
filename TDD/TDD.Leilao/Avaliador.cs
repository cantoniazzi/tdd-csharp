using System.Collections.Generic;
using System.Linq;

namespace TDDLeilao
{
    public class Avaliador
    {
        private double maiorDeTodos = double.MinValue;
        private double menorDeTodos = double.MaxValue;
        private IList<Lance> maiores;
        public void Avalia(Leilao leilao)
        {
            foreach (Lance lance in leilao.Lances)
            {
                if (lance.Valor > maiorDeTodos) maiorDeTodos = lance.Valor;
                if (lance.Valor < menorDeTodos) menorDeTodos = lance.Valor;
            }
            pegaOsMaioresNo(leilao);
        }
        private void pegaOsMaioresNo(Leilao leilao)
        {
            var filtro = leilao.Lances.OrderByDescending(p => p.Valor).Take(3);
            maiores = new List<Lance>(filtro);
        }
        public IList<Lance> TresMaiores
        {
            get { return this.maiores; }
        }
        public double MaiorLance
        {
            get { return maiorDeTodos; }
        }
        public double MenorLance
        {
            get { return menorDeTodos; }
        }
    }
}
