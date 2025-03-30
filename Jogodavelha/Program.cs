using Jogodavelha;

Console.WriteLine("Digite seu nome Jogador 1: ");
string nome1 = Console.ReadLine();
char simbolo = SelecionarSimbolo(); 
Jogador jogador1 = new Jogador(nome1, simbolo);

Console.WriteLine("Digite o nome do Jogador 2: ");
string nome2 = Console.ReadLine();
Jogador jogador2 = new Jogador(nome2, jogador1);
bool vezjogador1 = jogador1.Simbolo == 'X' ? true : false;
Tabuleiro tabuleiro = new Tabuleiro();
bool vitoria = false;
while (vitoria == false)
{
    Console.Clear();
    Jogador jogadorAtual = vezjogador1 ? jogador1 : jogador2;
    Console.WriteLine($"É a vez do {jogadorAtual.Nome} com o símbolo {jogadorAtual.Simbolo} jogar:");

    tabuleiro.ExibirTabuleiro();
    tabuleiro.MarcarTabuleiro(jogadorAtual.Simbolo);
    vitoria = tabuleiro.VerificaVitoria(jogadorAtual);
    if (vitoria == false)
    {
        
        if (tabuleiro._jogadasrealizadas == 9)
        {
            Console.Clear();
            tabuleiro.ExibirTabuleiro();
            Console.WriteLine("Empate!");
            break;
        }
        vezjogador1 = !vezjogador1;
    }
    else
    {
        Console.Clear() ;
        tabuleiro.ExibirTabuleiro();
        Console.WriteLine($"O jogador {jogadorAtual.Nome} ganhou");
    }
}


static char SelecionarSimbolo() 
{
    while (true)
    {
        Console.WriteLine("Selecione o símbolo (X ou O). O X começa e o Jogador 2 ficará com o que sobrar:");
        string simbolo_string = Console.ReadLine().ToUpper();
        if (simbolo_string == "X" || simbolo_string == "O")
        {
            return simbolo_string[0]; 
        }
        else
        {
            Console.WriteLine("Entre com um símbolo válido.");
        }
    }
}
