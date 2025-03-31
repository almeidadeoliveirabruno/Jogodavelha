using Jogodavelha;

class Interface
{
    public Jogador Jogador1 { get; }
    public Jogador Jogador2 { get; }
    public Tabuleiro Tabuleiro { get; }

    public Interface(Jogador jogador1, Jogador jogador2, Tabuleiro tabuleiro)
    {
        Jogador1 = jogador1;
        Jogador2 = jogador2;
        Tabuleiro = tabuleiro;
    }

    public void Mostrar(Jogador jogadorAtual)
    {
        Console.Clear();
        Console.WriteLine($"*******************************************    {Jogador1.Nome}:{Jogador1.Vitorias}   X  {Jogador2.Nome}:{Jogador2.Vitorias}    *******************************************");
        Console.WriteLine($"Vez de {jogadorAtual.Nome} ({jogadorAtual.Simbolo})");
        Tabuleiro.ExibirTabuleiro();
    }
}