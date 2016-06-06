using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDAnoBissexto
{
    public class Ano
    {
        public int Data { get; set; }

        public Ano(int data)
        {
            this.Data = data;
        }

        public bool VerificaSeEhBissexto()
        {
            if ((this.Data % 400 == 0) || (this.Data % 4 == 0) && (this.Data % 100 != 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
