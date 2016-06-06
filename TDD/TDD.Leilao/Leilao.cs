using System.Collections.Generic;
using System.Linq;

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

        public void DobrarLance(Usuario usuario)
        {
            if (this.CheckUsuario(usuario))
            {
                this.Propoe(new Lance(usuario, this.UltimoLanceUsuario(usuario).Valor * 2));
                
            }
        }

        private Lance UltimoLanceUsuario(Usuario usuario)
        {
            return this.Lances.Last(x => x.Usuario == usuario);
        }


        private bool CheckUsuario(Usuario usuario)
        {
            return this.Lances.Count(x => x.Usuario == usuario) > 0 ? true : false;
        }
        
        public void Propoe (Lance lance)
        {
            if ((this.Lances.Count == 0) || this.PodePropor(lance))
            {
                Lances.Add(lance);
            }
        }

        private bool PodePropor(Lance lance)
        {
            if ((this.QuantidadeLancesUsuario(lance.Usuario) < 5) && (!this.UltimoLanceDado().Usuario.Equals(lance.Usuario)))
            {
                return true;
            }
            return false;
        }

        private Lance UltimoLanceDado()
        {
            return this.Lances[Lances.Count - 1];
        }

        private int QuantidadeLancesUsuario(Usuario usuario)
        {
            if (this.Lances.Count > 0)
            {
                return this.Lances.FindAll(x => x.Usuario == usuario).Count;
            }
            return 0;
        }

    }
}
