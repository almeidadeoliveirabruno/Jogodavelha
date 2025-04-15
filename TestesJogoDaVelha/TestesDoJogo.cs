using Jogodavelha;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestesJogoDaVelha
{
    [TestClass]
    public class TestesJogador
    {
        [TestMethod]
        public void TesteJogador2RecebeoSimboloCerto()
        {
            //verifica se o jogador 2 recebe o simbolo certo
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
            //verifica se a troca de simbolo acontece dentro do método
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
            // Tem que dar erro na vitoria horizontal
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
            //Verifica vitória na vertical
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
            //Situação que o número ja foi marcado no tabuleiro.
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
            //Situação que o número marcado está fora do intervalo
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
            //Situação de empate em que o tabuleiro é preenchido. O empate é dados pela contagem de jogadas.
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";
            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Jogo jogo = new Jogo(jogador1, jogador2);
            bool empate;

            jogo.TabuleiroJogo.ValidarMarcacao(1, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.TabuleiroJogo.VerificaEmpate();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 1, "O número de jogadas realizadas não foi contabilizado devidamente");
            jogo.ControleDeVez();

            jogo.TabuleiroJogo.ValidarMarcacao(2, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.TabuleiroJogo.VerificaEmpate();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 2, "O número de jogadas realizadas não foi contabilizado devidamente");
            Assert.AreEqual(empate, false, "O jogo empatou onde não deveria");
            jogo.ControleDeVez();

            jogo.TabuleiroJogo.ValidarMarcacao(3, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.TabuleiroJogo.VerificaEmpate();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 3, "O número de jogadas realizadas não foi contabilizado devidamente");
            Assert.AreEqual(empate, false, "O jogo empatou onde não deveria");
            jogo.ControleDeVez();

            jogo.TabuleiroJogo.ValidarMarcacao(4, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.TabuleiroJogo.VerificaEmpate();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 4, "O número de jogadas realizadas não foi contabilizado devidamente");
            Assert.AreEqual(empate, false, "O jogo empatou onde não deveria");
            jogo.ControleDeVez();

            jogo.TabuleiroJogo.ValidarMarcacao(5, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.TabuleiroJogo.VerificaEmpate();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 5, "O número de jogadas realizadas não foi contabilizado devidamente");
            Assert.AreEqual(empate, false, "O jogo empatou onde não deveria");
            jogo.ControleDeVez();

            jogo.TabuleiroJogo.ValidarMarcacao(9, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.TabuleiroJogo.VerificaEmpate();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 6, "O número de jogadas realizadas não foi contabilizado devidamente");
            Assert.AreEqual(empate, false, "O jogo empatou onde não deveria");
            jogo.ControleDeVez();

            jogo.TabuleiroJogo.ValidarMarcacao(8, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.TabuleiroJogo.VerificaEmpate();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 7, "O número de jogadas realizadas não foi contabilizado devidamente");
            Assert.AreEqual(empate, false, "O jogo empatou onde não deveria");
            jogo.ControleDeVez();

            jogo.TabuleiroJogo.ValidarMarcacao(7, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.TabuleiroJogo.VerificaEmpate();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 8, "O número de jogadas realizadas não foi contabilizado devidamente");
            Assert.AreEqual(empate, false, "O jogo empatou onde não deveria");
            jogo.ControleDeVez();

            jogo.TabuleiroJogo.ValidarMarcacao(6, jogo.JogadorAtual.Simbolo);
            jogo.TabuleiroJogo.VerificaVitoria(jogo.JogadorAtual);
            empate = jogo.TabuleiroJogo.VerificaEmpate();
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
            //Verifica se depois do jogador X vencer o jogo, os simbolos dos jogadores são trocados e alterna o jogador que inicia a rodada.
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

            Assert.AreEqual(jogo.JogadorAtual, jogador2, "O jogador 2 não iniciou como primeiro");
            Assert.AreEqual(jogo.JogadorAtual.Simbolo, 'X', "O jogador 2 não recebeu o símbolo X");
            Assert.AreEqual(jogo.Jogador1.Simbolo, 'O', "O  Jogador 1 não recebeu o símbolo X");
        }

        [TestMethod]
        public void ControleDeVezJogadoresEntreRodadasJogadorOVence()
        {
            //Verifica se depois do jogador O vencer o jogo, os simbolos dos jogadores são trocados e alterna o jogador que inicia a rodada.
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
        public void VerificaEfeitosColateraisResetarJogo()
        {
            //Verifica se o resetar jogo se comporta da forma adequada
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";
            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Jogo jogo = new Jogo(jogador1, jogador2);
            jogo.ResetarJogo();
            Assert.AreEqual(jogo.TabuleiroJogo.JogadasRealizadas, 0, "O número de jogadas realizadas não foi zerado");
            Assert.AreEqual(jogo.Jogador1.Simbolo, 'O', "O Símbolo do jogador 1 não foi trocado");
            Assert.AreEqual(jogo.Jogador2.Simbolo, 'X', "O Símbolo do jogador 2 não foi trocado");
            Assert.AreEqual(jogo.FimDeJogo, false, "O fim de jogo não foi passado para false");
        }

        public void PlacarIncrementaAposVitoria()
        {
            //Obs: Lembrar de trocar o jogador atual antes de confirmar a vitória, pois o método de vitória utiliza o jogador atual.
            string nome1 = "Rogério";
            char simbolo1 = 'X';
            string nome2 = "André";

            Jogador jogador1 = new Jogador(nome1, simbolo1);
            Jogador jogador2 = new Jogador(nome2, jogador1);
            Jogo jogo = new Jogo(jogador1, jogador2);

            //Vitória Jogador1 como X. Placar esperado: Rogério:1 X André:0
            jogo.TabuleiroJogo.Grade[0, 0] = 'X';
            jogo.TabuleiroJogo.Grade[0, 1] = 'X';
            jogo.TabuleiroJogo.Grade[0, 2] = 'X';
            jogo.VerificaVitoria();
            jogo.ResetarJogo();
            jogo.ControleDeVez();

            //Vitória Jogador2 como X. Placar esperado: Rogério:1 X André:1
            jogo.TabuleiroJogo.Grade[0, 0] = 'X';
            jogo.TabuleiroJogo.Grade[0, 1] = 'X';
            jogo.TabuleiroJogo.Grade[0, 2] = 'X';
            jogo.VerificaVitoria();
            jogo.ResetarJogo();
            jogo.ControleDeVez();

            //Vitória Jogador2 como O. Placar esperado: Rogério:1 X André:2
            jogo.TabuleiroJogo.Grade[0, 0] = 'O';
            jogo.TabuleiroJogo.Grade[0, 1] = 'O';
            jogo.TabuleiroJogo.Grade[0, 2] = 'O';
            jogo.VerificaVitoria();
            jogo.ResetarJogo();
            jogo.ControleDeVez();

            Assert.AreEqual(1, jogador1.Vitorias, "O placar do Jogador1 não foi incrementado após a vitória");
            Assert.AreEqual(2, jogador2.Vitorias, "O placar do Jogador2 foi alterado sem motivo");
        }

    }
}


