namespace TDDLeilao
{
    public class Lance
    {
        public Usuario Usuario  { get; set; }
        public double Valor { get; set; }

        public Lance (Usuario usuario, double valor)
        {
            this.Usuario = usuario;
            this.Valor = valor;
        }
    }
}
