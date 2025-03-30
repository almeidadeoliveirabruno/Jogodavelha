using Jogodavelha;

#region Bem vindo
Console.WriteLine("Bem vindo ao jogo da Velha!");
Console.WriteLine("O Símbolo X começa e caso tenha revanche, os símbolos são trocados");
Console.WriteLine("Aperte enter para continuar");
Console.ReadLine();
Console.Clear();
Console.WriteLine("Digite seu nome Jogador 1: ");
string nome1 = Console.ReadLine();
char simbolo = SelecionarSimbolo(nome1); 
Jogador jogador1 = new Jogador(nome1, simbolo);
Console.Clear();
Console.WriteLine("Digite o nome do Jogador 2: ");
string nome2 = Console.ReadLine();
Jogador jogador2 = new Jogador(nome2, jogador1);
Console.Clear();
#endregion


Tabuleiro tabuleiro = new Tabuleiro();
bool fim = false;
bool vezjogador1 = true;
while (fim == false)
{
    if (tabuleiro._jogadasrealizadas == 0)
    {
        vezjogador1 = jogador1.Simbolo == 'X' ? true : false;
    }

    Jogador jogadorAtual = vezjogador1 ? jogador1 : jogador2;
    MostrarInterface(jogador1,jogador2,tabuleiro,jogadorAtual);
    tabuleiro.MarcarTabuleiro(jogadorAtual.Simbolo);
    fim = tabuleiro.VerificaVitoria(jogadorAtual);
    if (fim == false)
    {
        if (tabuleiro._jogadasrealizadas == 9)
        {
            MostrarInterface(jogador1, jogador2, tabuleiro, jogadorAtual);
            Console.WriteLine("Empate!");
            fim = ResetarJogo(jogador1, jogador2, ref tabuleiro, ref vezjogador1);
        }
        vezjogador1 = !vezjogador1;
    }
    else
    {
        MostrarInterface(jogador1, jogador2, tabuleiro, jogadorAtual);
        Console.WriteLine($"O jogador {jogadorAtual.Nome} ganhou");
        fim = ResetarJogo(jogador1, jogador2, ref tabuleiro, ref vezjogador1);
    }
}
Console.WriteLine("Obrigado Por Jogar!");
Console.ReadLine();


static char SelecionarSimbolo(string nome) 
{
    while (true)
    {
        Console.WriteLine($"Selecione o símbolo {nome} (X ou O).");
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
static void MostrarInterface(Jogador jogador1, Jogador jogador2, Tabuleiro tabuleiro, Jogador jogadorAtual)
{
    Console.Clear();
    Console.WriteLine($"*********************************************    {jogador1.Nome}:{jogador1.Vitorias}   X  {jogador2.Nome}:{jogador2.Vitorias}    *********************************************");
    Console.WriteLine();
    tabuleiro.ExibirTabuleiro();
    Console.WriteLine($"É a vez do {jogadorAtual.Nome} com o símbolo {jogadorAtual.Simbolo} jogar:");
}

static bool ResetarJogo(Jogador jogador1, Jogador jogador2, ref Tabuleiro tabuleiro, ref bool vezjogador1)
{
    while (true)
    {
        Console.WriteLine("Você deseja Jogar novamente (S ou N)?");
        string resposta = Console.ReadLine().ToUpper();
        if (resposta == "S")
        {
            tabuleiro = new Tabuleiro();
            jogador1.TrocarSimbolo(jogador2);
            tabuleiro.ResetaContagemDeJogadas();
            vezjogador1 = !vezjogador1;
            return false;
        }
        else if (resposta == "N")
        {
            return true;
        }
        Console.WriteLine("Digite (S) para resetar ou (N) para parar de jogar");
    }
}