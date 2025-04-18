﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Jogodavelha
{
    public class Tabuleiro
    {
        public char[,] Grade { get; private set; }
        public int JogadasRealizadas { get; private set; }
       
        public Tabuleiro()
        {
            Grade = new char[3, 3]
            {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
            };
            JogadasRealizadas = 0;
        }

        public void ExibirTabuleiro()
            //exibição do tabuleiro
        {
            Console.WriteLine(); 
            Console.WriteLine(" {0} | {1} | {2} ", Grade[0, 0], Grade[0, 1], Grade[0, 2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", Grade[1, 0], Grade[1, 1], Grade[1, 2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", Grade[2, 0], Grade[2, 1], Grade[2, 2]);
            Console.WriteLine();
        }
        
        
        public void MarcarTabuleiro(Char simboloJogadorAtual, Action mostrarHud)
            //Action é para quando é passada um método que não retorna nada para outra funcao

            //marca o simbolo no tabuleiro, ele recebe o simbolo do jogador atual
        {
            bool jogadaInvalida = true;
            while (jogadaInvalida)
            {
                Console.WriteLine("Digite um número para marcar: ");
                try
                {
                    int num = int.Parse(Console.ReadLine());
                    ValidarMarcacao(num, simboloJogadorAtual);
                    jogadaInvalida = false;
                }
                catch (FormatException ex)
                {
                    mostrarHud();
                    Console.WriteLine("Digite apenas números inteiros!");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    mostrarHud();
                    Console.WriteLine("Digite um número de 1 até 9!"); 
                }
                catch (InvalidOperationException ex)
                {
                    mostrarHud();
                    Console.WriteLine("Este quadrado ja foi marcado!");
                }
            }
        }

        public void ValidarMarcacao(int num, char simboloatual)
            //verifica se o quadrado marcado pode ser marcado
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
            if (Grade[linha, coluna] == 'X' || Grade[linha, coluna] == 'O')
            {
                throw new InvalidOperationException();
            }

            Grade[linha, coluna] = simboloatual;
            JogadasRealizadas++;
        }

        public bool VerificaVitoria(char simboloJogadorAtual)
        {
            for (int i = 0; i < 3; i++)
            {
                //Verifica a linha
                if ((Grade[i, 0] == simboloJogadorAtual) && (Grade[i, 1] == simboloJogadorAtual) && (Grade[i, 2] == simboloJogadorAtual))
                {
                    return true;
                }

                //Verifica a coluna
                if ((Grade[0, i] == simboloJogadorAtual) && (Grade[1, i] == simboloJogadorAtual) && (Grade[2, i] == simboloJogadorAtual))
                {
                    return true;
                }
            }

            //Diagonal principal
            if ((Grade[0, 0] == simboloJogadorAtual) && (Grade[1, 1] == simboloJogadorAtual) && (Grade[2, 2] == simboloJogadorAtual))
            {
                return true;
            }
            
            //Diagonal Secundária
            if (Grade[0, 2] == simboloJogadorAtual && Grade[1, 1] == simboloJogadorAtual && Grade[2, 0] == simboloJogadorAtual)
            {
                return true;
            }
            return false;
        }

        public bool VerificaEmpate()
        {
            if (JogadasRealizadas == 9)
            {
                return true;
            }
            return false;
        }
        public void Resetar()
            //Reinicia o tabuleiro
        {
            Grade = new char[3, 3]
            {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
            };
            JogadasRealizadas = 0;
        }
    }
    
}
