using Jogodavelha;

namespace TestesJogoDaVelha
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void TestJogador2RecebeoSimboloCerto()
        {
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            char simbolo2Esperado = 'O';
            string nome2 = "André";
            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2,jogador1);
            Assert.AreEqual(simbolo2Esperado, jogador2.Simbolo, "O símbolo não corresponde");
        }
    }
}
