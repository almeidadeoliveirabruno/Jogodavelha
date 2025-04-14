using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogodavelha
{
    public class Jogador
    {
        public string Nome { get; private set; }
        public char Simbolo { get; private set; }
        public int Vitorias { get; private set; } = 0;

        public Jogador(string nome, char simbolo)
            //construtor para o jogador 1.
        {
            Nome = nome;
            Simbolo = simbolo;
        }

        public Jogador(string nome, Jogador jogador1)
            //construtor para o jogador 2, uma vez que ja sabemos o simbolo do primeiro.
        {
            Nome = nome;
            Simbolo = jogador1.Simbolo == 'X' ? 'O' : 'X';
        }

        public void Ganhou()
        {
            Vitorias++;
        }

        public void TrocarSimbolo(Jogador jogador)
        {
            Char Aux = Simbolo;
            Simbolo = jogador.Simbolo;
            jogador.Simbolo = Aux;
        }
    }
}
