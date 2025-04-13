using Jogodavelha;

namespace TestesJogoDaVelha
{
    [TestClass]
    public class TestesJogador
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

        [TestMethod]
        public void TestTrocaDeSimbolos()
        {
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";
            char simbolo1Esperado = 'O';
            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            jogador1.TrocarSimbolo(jogador2);
            Assert.AreEqual(simbolo1Esperado, jogador1.Simbolo, "Troca deu errado");
        }
    }

    [TestClass]
    public class TestesTabuleiro()
    {
        [TestMethod]
        public void VitoriaHorizontal()
        {
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";
            bool vitoria;

            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Tabuleiro tabuleiroTestes = new Tabuleiro();
            Jogador jogadorAtual = jogador1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j< 3; j++)
                {
                    tabuleiroTestes.Grade[i, j] = 'X';
                }

                vitoria = tabuleiroTestes.VerificaVitoria(jogador1);
                Assert.AreEqual(vitoria, true, "Existe erro na lógica de vitória");
                tabuleiroTestes.Resetar();
            }
        }
        
        [TestMethod]
        public void VitoriaHorizontalFalha()
        {
            // Tem que dar erro
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";
            bool vitoria;

            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Tabuleiro tabuleiroTestes = new Tabuleiro();
            Jogador jogadorAtual = jogador1;
            vitoria = tabuleiroTestes.VerificaVitoria(jogadorAtual);
            Assert.AreEqual(vitoria, true, "Existe erro na lógica de vitória");
                tabuleiroTestes.Resetar();
        }
        public void VitoriaVertical()
        {

        }
    }
}
