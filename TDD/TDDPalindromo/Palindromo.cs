using System;

namespace TDDPalindromo
{
    public class Palindromo
    {
        public string Frase { get; set; }

        public Palindromo(string frase)
        {
            if (!String.IsNullOrEmpty(frase))
            {
                this.Frase = frase.Replace(" ","").Replace("-","").ToLower();
            }
        }
        public Palindromo() { }

    }
}
