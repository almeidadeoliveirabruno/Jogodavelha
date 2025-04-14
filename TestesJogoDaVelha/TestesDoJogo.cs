using Jogodavelha;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestesJogoDaVelha
{
    [TestClass]
    public class TestesJogador
    {
        [TestMethod]
        public void TesteJogador2RecebeoSimboloCerto()
        {
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            char simbolo2Esperado = 'O';
            string nome2 = "André";
            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Assert.AreEqual(simbolo2Esperado, jogador2.Simbolo, "O símbolo não corresponde");
        }

        [TestMethod]
        public void TesteTrocaDeSimbolos()
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
            //O jogador atual deve ser o último a jogar
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";

            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Tabuleiro tabuleiroTestes = new Tabuleiro();
            Jogador jogadorAtual = jogador1;
            bool vitoria;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiroTestes.Grade[i, j] = 'X';
                }

                vitoria = tabuleiroTestes.VerificaVitoria(jogadorAtual);
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
            tabuleiroTestes.Grade[0, 0] = 'X';
            tabuleiroTestes.Grade[0, 1] = 'O';
            tabuleiroTestes.Grade[0, 2] = 'X';

            vitoria = tabuleiroTestes.VerificaVitoria(jogadorAtual);
            Assert.AreEqual(vitoria, false, "Existe erro na lógica de vitória");
        }

        [TestMethod]
        public void VitoriaVertical()
        {
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";
            bool vitoria;

            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Tabuleiro tabuleiroTestes = new Tabuleiro();
            Jogador jogadorAtual = jogador2;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiroTestes.Grade[j, i] = 'O';
                }

                vitoria = tabuleiroTestes.VerificaVitoria(jogadorAtual);
                Assert.AreEqual(vitoria, true, "Existe erro na lógica de vitória");
                tabuleiroTestes.Resetar();
            }
        }

        [TestMethod]
        public void VitorialVerticalFalha()
        {
            //O jogador atual deve ser o último a jogar
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";
            bool vitoria;

            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Tabuleiro tabuleiroTestes = new Tabuleiro();
            Jogador jogadorAtual = jogador1;
            tabuleiroTestes.Grade[1, 0] = 'X';
            tabuleiroTestes.Grade[0, 0] = 'O';
            tabuleiroTestes.Grade[2, 2] = 'X';

            vitoria = tabuleiroTestes.VerificaVitoria(jogadorAtual);
            Assert.AreEqual(vitoria, false, "Erro na lógica de vitória");
        }
        [TestMethod]
        public void VitoriaDiagonal()
        {
            // //O jogador atual deve ser o último a jogar
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";
            bool vitoria;

            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Tabuleiro tabuleiroTestes = new Tabuleiro();
            Jogador jogadorAtual = jogador1;
            tabuleiroTestes.Grade[0, 0] = 'X';
            tabuleiroTestes.Grade[1, 1] = 'X';
            tabuleiroTestes.Grade[2, 2] = 'X';
            vitoria = tabuleiroTestes.VerificaVitoria(jogadorAtual);
            Assert.AreEqual(vitoria, true, "Erro na lógica de vitória");
            tabuleiroTestes.Resetar();

            tabuleiroTestes.Grade[0, 2] = 'X';
            tabuleiroTestes.Grade[1, 1] = 'X';
            tabuleiroTestes.Grade[2, 0] = 'X';
            vitoria = tabuleiroTestes.VerificaVitoria(jogadorAtual);
            Assert.AreEqual(vitoria, true, "Erro na lógica de vitória");
        }

        [TestMethod]
        public void VitoriaDiagonalFalha()
        {
            //O jogador atual deve ser o último a jogar
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";
            bool vitoria;

            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Tabuleiro tabuleiroTestes = new Tabuleiro();
            Jogador jogadorAtual = jogador1;
            tabuleiroTestes.Grade[0, 0] = 'X';
            tabuleiroTestes.Grade[1, 1] = 'O';
            tabuleiroTestes.Grade[2, 2] = 'X';
            vitoria = tabuleiroTestes.VerificaVitoria(jogadorAtual);
            Assert.AreEqual(vitoria, false, "Erro na lógica de vitória");
            tabuleiroTestes.Resetar();

            tabuleiroTestes.Grade[0, 2] = 'X';
            tabuleiroTestes.Grade[1, 1] = 'O';
            tabuleiroTestes.Grade[2, 0] = 'X';
            vitoria = tabuleiroTestes.VerificaVitoria(jogadorAtual);
            Assert.AreEqual(vitoria, false, "Erro na lógica de vitória");

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void JogadaInvalidaNumeroJaMarcado()
        {
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";
            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Tabuleiro tabuleiroTestes = new Tabuleiro();
            Jogo jogo = new Jogo(jogador1, jogador2);
            jogo.TabuleiroJogo.ValidarMarcacao(1, 'X');
            jogo.TabuleiroJogo.ValidarMarcacao(1, 'O');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void JogadaInvalidaNumeroForaDoIntervalo()

        {
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";
            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Tabuleiro tabuleiroTestes = new Tabuleiro();
            Jogo jogo = new Jogo(jogador1, jogador2);
            jogo.TabuleiroJogo.ValidarMarcacao(31231203, 'X');
        }
    }

    [TestClass]
    public class TestesJogo
    {
        [TestMethod]
        public void Empate()
        {
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";
            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Jogo jogo = new Jogo(jogador1, jogador2);
            bool empate;

            jogo.TabuleiroJogo.ValidarMarcacao(1, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.VerificaEmpate();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 1, "O número de jogadas realizadas não foi contabilizado devidamente");
            jogo.ControleDeVez();

            jogo.TabuleiroJogo.ValidarMarcacao(2, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.VerificaEmpate();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 2, "O número de jogadas realizadas não foi contabilizado devidamente");
            Assert.AreEqual(empate, false, "O jogo empatou onde não deveria");
            jogo.ControleDeVez();

            jogo.TabuleiroJogo.ValidarMarcacao(3, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.VerificaEmpate();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 3, "O número de jogadas realizadas não foi contabilizado devidamente");
            Assert.AreEqual(empate, false, "O jogo empatou onde não deveria");
            jogo.ControleDeVez();

            jogo.TabuleiroJogo.ValidarMarcacao(4, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.VerificaEmpate();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 4, "O número de jogadas realizadas não foi contabilizado devidamente");
            Assert.AreEqual(empate, false, "O jogo empatou onde não deveria");
            jogo.ControleDeVez();

            jogo.TabuleiroJogo.ValidarMarcacao(5, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.VerificaEmpate();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 5, "O número de jogadas realizadas não foi contabilizado devidamente");
            Assert.AreEqual(empate, false, "O jogo empatou onde não deveria");
            jogo.ControleDeVez();

            jogo.TabuleiroJogo.ValidarMarcacao(9, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.VerificaEmpate();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 6, "O número de jogadas realizadas não foi contabilizado devidamente");
            Assert.AreEqual(empate, false, "O jogo empatou onde não deveria");
            jogo.ControleDeVez();

            jogo.TabuleiroJogo.ValidarMarcacao(8, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.VerificaEmpate();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 7, "O número de jogadas realizadas não foi contabilizado devidamente");
            Assert.AreEqual(empate, false, "O jogo empatou onde não deveria");
            jogo.ControleDeVez();

            jogo.TabuleiroJogo.ValidarMarcacao(7, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.VerificaEmpate();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 8, "O número de jogadas realizadas não foi contabilizado devidamente");
            Assert.AreEqual(empate, false, "O jogo empatou onde não deveria");
            jogo.ControleDeVez();

            jogo.TabuleiroJogo.ValidarMarcacao(6, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.VerificaEmpate();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 9, "O número de jogadas realizadas não foi contabilizado devidamente");
            Assert.AreEqual(empate, true, "O jogo  não empatou onde deveria");
            jogo.ControleDeVez();

            jogo.TabuleiroJogo.Resetar();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 0, "O tabuleiro não foi resetado corretamente");

        }
        [TestMethod]
        public void ControleDeVezJogadoresAlternandoDurantePartida()
        {
            // Esse teste não considera vitórias ou empates, o objetivo é apenas preencher o tabuleiro e verificar se a alternancia entre jogadores está funcional dentro da partida
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";
            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Jogo jogo = new Jogo(jogador1, jogador2);

            jogo.TabuleiroJogo.ValidarMarcacao(1, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();
            jogo.ControleDeVez();
            Assert.AreEqual(jogador2, jogo.JogadorAtual, "Ocorreu erro na troca");

            jogo.TabuleiroJogo.ValidarMarcacao(2, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();
            jogo.ControleDeVez();
            Assert.AreEqual(jogador1, jogo.JogadorAtual, "Ocorreu erro na troca");

            jogo.TabuleiroJogo.ValidarMarcacao(3, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();
            jogo.ControleDeVez();
            Assert.AreEqual(jogador2, jogo.JogadorAtual, "Ocorreu erro na troca");

            jogo.TabuleiroJogo.ValidarMarcacao(4, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();
            jogo.ControleDeVez();
            Assert.AreEqual(jogador1, jogo.JogadorAtual, "Ocorreu erro na troca");

            jogo.TabuleiroJogo.ValidarMarcacao(5, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();
            jogo.ControleDeVez();
            Assert.AreEqual(jogador2, jogo.JogadorAtual, "Ocorreu erro na troca");

            jogo.TabuleiroJogo.ValidarMarcacao(6, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();
            jogo.ControleDeVez();
            Assert.AreEqual(jogador1, jogo.JogadorAtual, "Ocorreu erro na troca");

            jogo.TabuleiroJogo.ValidarMarcacao(7, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();
            jogo.ControleDeVez();
            Assert.AreEqual(jogador2, jogo.JogadorAtual, "Ocorreu erro na troca");

            jogo.TabuleiroJogo.ValidarMarcacao(8, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();
            jogo.ControleDeVez();
            Assert.AreEqual(jogador1, jogo.JogadorAtual, "Ocorreu erro na troca");

            jogo.TabuleiroJogo.ValidarMarcacao(9, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();
            jogo.ControleDeVez();
            Assert.AreEqual(jogador2, jogo.JogadorAtual, "Ocorreu erro na troca");

        }
        [TestMethod]
        public void ControleDeVezJogadoresEntreRodadasJogadorXVence()
        {
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";
            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Jogo jogo = new Jogo(jogador1, jogador2);

            jogo.ControleDeVez();
            jogo.TabuleiroJogo.ValidarMarcacao(1, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();

            jogo.ControleDeVez();
            jogo.TabuleiroJogo.ValidarMarcacao(5, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();

            jogo.ControleDeVez();
            jogo.TabuleiroJogo.ValidarMarcacao(2, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();

            jogo.ControleDeVez();
            jogo.TabuleiroJogo.ValidarMarcacao(6, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();
     
            // Vitória do jogador com símbolo X
            jogo.ControleDeVez();
            jogo.TabuleiroJogo.ValidarMarcacao(3, jogo.JogadorAtual.Simbolo);
            jogo.ResetarJogo();
            jogo.ControleDeVez();

            Assert.AreEqual(jogo.JogadorAtual, jogador2, "O jogador 2 não iniciou como primero");
            Assert.AreEqual(jogo.JogadorAtual.Simbolo, 'X', "O jogador 2 não recebeu o símbolo X");
            Assert.AreEqual(jogo.Jogador1.Simbolo , 'O', "O  Jogador 1 não recebeu o símbolo X");
        }

        [TestMethod]
        public void ControleDeVezJogadoresEntreRodadasJogadorOVence()
        {
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";
            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Jogo jogo = new Jogo(jogador1, jogador2);

            jogo.ControleDeVez();
            jogo.TabuleiroJogo.ValidarMarcacao(5, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();

            jogo.ControleDeVez();
            jogo.TabuleiroJogo.ValidarMarcacao(1, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();

            jogo.ControleDeVez();
            jogo.TabuleiroJogo.ValidarMarcacao(6, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();

            jogo.ControleDeVez();
            jogo.TabuleiroJogo.ValidarMarcacao(2, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();

            jogo.ControleDeVez();
            jogo.TabuleiroJogo.ValidarMarcacao(7, jogo.JogadorAtual.Simbolo);
            jogo.TrocaVez();

            //Vitória do jogador com símbolo "O"
            jogo.ControleDeVez();
            jogo.TabuleiroJogo.ValidarMarcacao(3, jogo.JogadorAtual.Simbolo);
            jogo.ResetarJogo();
            jogo.ControleDeVez();

            Assert.AreEqual(jogo.JogadorAtual, jogador2, "O jogador 2 não iniciou como primeiro");
            Assert.AreEqual(jogo.JogadorAtual.Simbolo, 'X', "O jogador 2 não recebeu o símbolo X");
            Assert.AreEqual(jogo.Jogador1.Simbolo, 'O', "O  Jogador 1 não recebeu o símbolo X");
        }
        [TestMethod]
        public void ContagemDeVitorias()
        {
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";
            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Jogo jogo = new Jogo(jogador1, jogador2);

        }
    }
}

