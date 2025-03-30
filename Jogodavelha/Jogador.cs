using System;
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
        public string Teste { get; set; }


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
    }
}
