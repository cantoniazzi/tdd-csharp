namespace TDDMatematicaMaluca
{
    public class Calculo
    {
        public int Numero { get; set; }

        public Calculo(int numero)
        {
            this.Numero = numero;
        }
        public Calculo() { }

        public int CalculoMaluco()
        {
            if (this.Numero > 30) { return this.Numero * 4; }
            else if (this.Numero > 10) { return this.Numero * 3; }
            else return this.Numero * 2;
        }
    }
}
