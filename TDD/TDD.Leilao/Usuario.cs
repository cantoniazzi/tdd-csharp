namespace TDDLeilao
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Usuario (string nome) : this(0,nome)
        {
        }

        public  Usuario (int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
    }
}