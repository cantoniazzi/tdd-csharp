using System.Collections.Generic;

namespace TDDLeilao
{
    public class Leilao
    {
        public string Descricao { get; set; }
        public List<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        public void Propoe (Lance lance)
        {
            Lances.Add(lance);
        }
    }
}
