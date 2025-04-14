using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogodavelha
{
    public class Jogo
    {
        private bool _vezJogador1;
        public bool FimDeJogo { get; private set; } = false;
        public Tabuleiro TabuleiroJogo { get; private set; }
        public Jogador Jogador1 { get; private set; }
        public Jogador Jogador2 { get; private set; }
        public Jogador JogadorAtual { get; private set; }

        public Jogo(Jogador jogador1, Jogador jogador2)
        {
            Jogador1 = jogador1;
            Jogador2 = jogador2;
            _vezJogador1 = jogador1.Simbolo == 'X' ? true : false;
            JogadorAtual = _vezJogador1 ? jogador1 : jogador2;
            TabuleiroJogo = new Tabuleiro();
        }

        public void ControleDeVez()
        {
            JogadorAtual = _vezJogador1 ? Jogador1 : Jogador2;
        }
        public void VerificaVitoria()
        {
            if (TabuleiroJogo.VerificaVitoria(JogadorAtual))
            {
                Vitoria();
                FimDeJogo = true;
            }
        }

        public void Vitoria()
        {
            JogadorAtual.Ganhou();
            MostrarHud();
            if (JogadorAtual == Jogador1)
            Console.ForegroundColor = ConsoleColor.Red;
            else Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"O jogador {JogadorAtual.Nome} ganhou");
            Console.ResetColor();
        }

        public bool VerificaEmpate()
        {
            if (TabuleiroJogo.JogadasRealizadas == 9)
            {
                return true;
            }
            return false;
        }

        public void MostrarHud()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"*******************************************    {Jogador1.Nome}:{Jogador1.Vitorias}   X  {Jogador2.Nome}:{Jogador2.Vitorias}    *******************************************");
            Console.WriteLine();
            if (JogadorAtual == Jogador1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine($"Vez de {JogadorAtual.Nome} ({JogadorAtual.Simbolo})");
            Console.ResetColor();
            Console.WriteLine();
            TabuleiroJogo.ExibirTabuleiro();
        }

        public void ResetarJogo()
        {
            TabuleiroJogo.Resetar();
            Jogador1.TrocarSimbolo(Jogador2);
            _vezJogador1 = Jogador1.Simbolo == 'X'? true : false;
            FimDeJogo = false;
        }

        public void FinalizarJogo()
        {
            FimDeJogo = true;
        }

        public void TrocaVez()
        {
            _vezJogador1 = !_vezJogador1;
        }

    }
}
