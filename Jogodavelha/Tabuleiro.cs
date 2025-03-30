using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Jogodavelha
{
    class Tabuleiro
    {
        public char[,] _tabuleiro { get; private set; }
        public int _jogadasrealizadas { get; private set; }
        public Tabuleiro()
        {
            _tabuleiro = new char[3, 3]
            {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
            };
            _jogadasrealizadas = 0;

        }

        public void ExibirTabuleiro()
        {
            Console.WriteLine(); 
            Console.WriteLine(" {0} | {1} | {2} ", _tabuleiro[0, 0], _tabuleiro[0, 1], _tabuleiro[0, 2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", _tabuleiro[1, 0], _tabuleiro[1, 1], _tabuleiro[1, 2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", _tabuleiro[2, 0], _tabuleiro[2, 1], _tabuleiro[2, 2]);
            Console.WriteLine();
        }

        public void MarcarTabuleiro(Char simboloAtual)
        {
            bool jogadaInvalida = true;
            while (jogadaInvalida)
            {
                try
                {
                    Console.WriteLine("Digite um número para marcar: ");
                    int num = int.Parse(Console.ReadLine());
                    ValidarMarcacao(num, simboloAtual);
                    jogadaInvalida = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Digite um número válido!");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Digite o número dentro de um intervalo válido");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Este quadrado ja foi marcado");
                }
            }
        }

        private void ValidarMarcacao(int num, char simboloatual)
        {
            Dictionary<int, (int, int)> numeroMarcado = new Dictionary<int, (int, int)>
            {
                { 1, (0, 0) },
                { 2, (0, 1) },
                { 3, (0, 2) },
                { 4, (1, 0) },
                { 5, (1, 1) },
                { 6, (1, 2) },
                { 7, (2, 0) },
                { 8, (2, 1) },
                { 9, (2, 2) },
            };
            if (num < 1 || num > 9)
            {
                throw new ArgumentOutOfRangeException();
            }

            (int linha, int coluna) = numeroMarcado[num];
            if (_tabuleiro[linha, coluna] == 'X' || _tabuleiro[linha, coluna] == 'O')
            {
                throw new InvalidOperationException("Ja foi marcado");
            }

            _tabuleiro[linha, coluna] = simboloatual;
            _jogadasrealizadas++;

        }

        public bool VerificaVitoria(Jogador jogadoratual)
        {
            char simbolo = jogadoratual.Simbolo;
            for (int i = 0; i < 3; i++)
            {
                //Verifica a linha
                if ((_tabuleiro[i, 0] == simbolo) && (_tabuleiro[i, 1] == simbolo) && (_tabuleiro[i, 2] == simbolo))
                {
                    jogadoratual.Vitorias++;
                    return true;
                }

                //Verifica a coluna
                if ((_tabuleiro[0, i] == simbolo) && (_tabuleiro[1, i] == simbolo) && (_tabuleiro[2, i] == simbolo))
                {
                    jogadoratual.Vitorias++;
                    return true;
                }
            }

            //diagonal principal
            if ((_tabuleiro[0, 0] == simbolo) && (_tabuleiro[1, 1] == simbolo) && (_tabuleiro[2, 2] == simbolo))
            {
                jogadoratual.Vitorias++;
                return true;
            }
            if (_tabuleiro[0, 2] == simbolo && _tabuleiro[1, 1] == simbolo && _tabuleiro[2, 0] == simbolo)
            {
                jogadoratual.Vitorias++;
                return true;
            }
            return false;
        }
        public void Resetar()
        {
            _tabuleiro = new char[3, 3]
            {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
            };
            _jogadasrealizadas = 0;
        }
    }
    
}
