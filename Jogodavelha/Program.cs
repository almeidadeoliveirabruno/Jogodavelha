using Jogodavelha;

Console.WriteLine("Digite seu nome Jogador 1: ");
string nome1 = Console.ReadLine();
char simbolo = SelecionarSimbolo();
Jogador jogador1 = new Jogador(nome1, simbolo);
Console.WriteLine("Digite o nome do jogador 2: ");
string nome2 = Console.ReadLine();
Jogador jogador2 = new Jogador(nome2, jogador1);
bool vezjogador1 = jogador1.Simbolo == 'X' ? true : false;
Tabuleiro tabuleiro = new Tabuleiro();

while (true)
{
    Jogador jogadorAtual = vezjogador1 ? jogador1 : jogador2;
    Console.WriteLine($"O nome do jogador1 é: {jogador1.Nome} e o simbolo {jogador1.Simbolo}");
    Console.WriteLine($"O nome do jogador 2 é: {jogador2.Nome} e o simbolo {jogador2.Simbolo}");
    Console.WriteLine($"é a vez do {jogadorAtual.Nome} com o símbolo {jogadorAtual.Simbolo}");

    tabuleiro.ExibirTabuleiro();
    tabuleiro.MarcarTabuleiro(jogadorAtual.Simbolo);
    vezjogador1 = !vezjogador1;
    Console.ReadLine();
}


static char SelecionarSimbolo()
{
    while (true)
    {
        Console.WriteLine("Selecione o símbolo X ou O:");
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
