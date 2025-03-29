﻿using System;
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
        public Tabuleiro()
        {
            _tabuleiro = new char[3, 3]
            {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
            };
        }

        public void ExibirTabuleiro()
        {
            Console.WriteLine();
            Console.WriteLine($"{_tabuleiro[0, 0]}|{_tabuleiro[0, 1]}|{_tabuleiro[0, 2]}");
            Console.WriteLine("-----");
            Console.WriteLine($"{_tabuleiro[1, 0]}|{_tabuleiro[1, 1]}|{_tabuleiro[1, 2]}");
            Console.WriteLine("-----");
            Console.WriteLine($"{_tabuleiro[2, 0]}|{_tabuleiro[2, 1]}|{_tabuleiro[2, 2]}");
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
                    validarmarcacao(num, simboloAtual);
                    jogadaInvalida = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Digite um número!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Digite o número dentro de um intervalo válido");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Este quadrado ja foi marcado");
                }
            }
        }

        private void validarmarcacao(int num, char simboloatual)
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

            (int linha,int coluna) = numeroMarcado[num];
            if (_tabuleiro[linha,coluna] == 'X' || _tabuleiro[linha,coluna] == 'O')
            {
                throw new InvalidOperationException("Ja foi marcado");
            }

            this._tabuleiro[linha,coluna] = simboloatual;

        }
    }
}
