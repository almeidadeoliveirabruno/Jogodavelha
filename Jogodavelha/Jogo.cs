using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogodavelha
{
    public class Jogo
    {
        private bool _fimdejogo = false;
        public Tabuleiro TabuleiroJogo { get; private set; }
        public Jogador Jogador1 { get; private set; }
        public Jogador Jogador2 { get; private set; }
        public Jogador JogadorAtual { get; private set; }
        public HUD HudJogo { get; private set; }


        public Jogo(Jogador jogador1, Jogador jogador2)
        {
            Jogador1 = jogador1;
            Jogador2 = jogador2;
            JogadorAtual = jogador1.Simbolo == 'X' ? jogador1 : jogador2;
            TabuleiroJogo = new Tabuleiro();
            HudJogo = new HUD(jogador1, jogador2, TabuleiroJogo);
        }
        
        public void Partida()
        {
            while (true)
            {

            }
        }
    }

    
}
