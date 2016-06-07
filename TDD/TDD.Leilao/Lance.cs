using System;

namespace TDDLeilao
{
    public class Lance
    {
        public Usuario Usuario  { get; set; }
        public double Valor { get; set; }

        public Lance (Usuario usuario, double valor)
        {
            if (valor == 0 || valor < 0)
                throw new Exception("O valor do lance tem que ser maior que zero");

            this.Usuario = usuario;
            this.Valor = valor;
        }
    }
}
