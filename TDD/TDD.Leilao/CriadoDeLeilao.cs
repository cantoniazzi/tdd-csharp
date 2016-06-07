using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDLeilao
{
    public class CriadoDeLeilao
    {
        private Leilao leilao;

        public CriadoDeLeilao() { }

        public CriadoDeLeilao Para(string descricao)
        {
            this.leilao = new Leilao(descricao);
            return this;
        }

        public CriadoDeLeilao Lance (Usuario usuario, double valor)
        {
            this.leilao.Propoe(new Lance(usuario, valor));
            return this;
        }

        public Leilao Constroi()
        {
            return this.leilao;
        }
    }
}
