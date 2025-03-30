﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogodavelha
{
    class Jogador
    {
        public string Nome { get; private set; }
        public char Simbolo { get; private set; }
        public int Vitorias = 0;


        public Jogador(string nome, char simbolo)
        {
            Nome = nome;
            Simbolo = simbolo;
        }

        public Jogador(string nome, Jogador jogador1)
        {
            Nome = nome;
            Simbolo = jogador1.Simbolo == 'X' ? 'O' : 'X';
        }

        public void TrocarSimbolo(Jogador jogador)
        {
            Char Aux = Simbolo;
            Simbolo = jogador.Simbolo;
            jogador.Simbolo = Aux;
        }
    }
}
