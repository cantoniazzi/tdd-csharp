using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDPalindromo;

namespace TDDPalindromoTests
{
    [TestClass]
    public class PalindromoTest
    {
        [TestMethod]
        public void TestMethodPalindromo()
        {
            Palindromo palindromo = new Palindromo("Anotaram a data da maratona");

            for (int i = 0; i < palindromo.Frase.Length; i++)
            {
                Assert.AreEqual(palindromo.Frase[i], palindromo.Frase[palindromo.Frase.Length - (i + 1)]);
            }

        }
    }
}
