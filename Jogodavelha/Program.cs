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


Tabuleiro _tabuleiro = new Tabuleiro();
bool fim = false;
bool vezjogador1 = jogador1.Simbolo == 'X';
while (fim == false)
{
    Jogador jogadorAtual = vezjogador1 ? jogador1 : jogador2;
    MostrarInterface(jogador1,jogador2,_tabuleiro,jogadorAtual);
    _tabuleiro.MarcarTabuleiro(jogadorAtual.Simbolo);
    fim = _tabuleiro.VerificaVitoria(jogadorAtual);
    if (fim == false)
    {
        if (_tabuleiro._jogadasrealizadas == 9)
        {
            MostrarInterface(jogador1, jogador2, _tabuleiro, jogadorAtual);
            Console.WriteLine("Empate!");
            fim = ResetarJogo(jogador1, jogador2, ref _tabuleiro, ref vezjogador1);
        }
        else {  
            vezjogador1 = !vezjogador1; // O resetarjogo ja está invertendo isso daqui, por isso coloquei  else
        }
    }
    else
    {
        MostrarInterface(jogador1, jogador2, _tabuleiro, jogadorAtual);
        Console.WriteLine($"O jogador {jogadorAtual.Nome} ganhou");
        fim = ResetarJogo(jogador1, jogador2, ref _tabuleiro, ref vezjogador1);
    }
}
Console.WriteLine("Obrigado Por Jogar!");
Console.ReadLine();


static char  SelecionarSimbolo(string nome) 
    //Método para garantir que o símbolo seja corretamente selecionado e para garantir que é um char.
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
    /* Método para exibir a interface */
{
    Console.Clear();
    Console.WriteLine($"*******************************************    {jogador1.Nome}:{jogador1.Vitorias}   X  {jogador2.Nome}:{jogador2.Vitorias}    *******************************************");
    Console.WriteLine();
    Console.WriteLine($"É a vez do {jogadorAtual.Nome} com o símbolo {jogadorAtual.Simbolo} jogar!");
    Console.WriteLine();
    tabuleiro.ExibirTabuleiro();
    Console.WriteLine();
    
}

static bool ResetarJogo(Jogador jogador1, Jogador jogador2, ref Tabuleiro tabuleiro, ref bool vezjogador1)
    //Método para resetar o jogo ou finalizar. Ele altera tudo que é necessário para iniciar uma nova rodada 
{
    while (true)
    {
        Console.WriteLine("Você deseja Jogar novamente (S ou N)?");
        string resposta = Console.ReadLine().ToUpper();
        if (resposta == "S")
        {
            tabuleiro.Resetar();
            jogador1.TrocarSimbolo(jogador2);
            vezjogador1 = jogador1.Simbolo == 'X'; 
            return false;
        }
        else if (resposta == "N")
        {
            return true;
        }
        Console.WriteLine("Digite (S) para resetar ou (N) para parar de jogar");
    }
}