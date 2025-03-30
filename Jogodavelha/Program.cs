using Jogodavelha;

#region Bem vindo
Console.WriteLine("Bem vindo ao jogo da Velha!");
Console.WriteLine("O Símbolo X começa e caso tenha revanche, os símbolos são trocados");
Console.WriteLine("Aperte enter para continuar");
Console.ReadLine();
Console.Clear();
#endregion

string nome1 = NomeValidacao("Jogador 1");
char simbolo = SelecionarSimbolo(nome1); 
Jogador jogador1 = new Jogador(nome1, simbolo);
Console.Clear();
string nome2 = NomeValidacao("Jogador 2");
Jogador jogador2 = new Jogador(nome2, jogador1);
Console.Clear();
Tabuleiro tabuleiro = new Tabuleiro();
bool vezjogador1 = jogador1.Simbolo == 'X';
HUD interfaceJogo = new HUD(jogador1, jogador2, tabuleiro);
bool fim = false;
while (fim == false)
{
    Jogador jogadorAtual = vezjogador1 ? jogador1 : jogador2;
    interfaceJogo.Mostrar(jogadorAtual);
    tabuleiro.MarcarTabuleiro(jogadorAtual.Simbolo);
    fim = tabuleiro.VerificaVitoria(jogadorAtual);
    if (fim == false)
    {
        if (tabuleiro.JogadasRealizadas == 9)
        {
            interfaceJogo.Mostrar(jogadorAtual);
            Console.WriteLine("Empate!");
            fim = ResetarJogo(jogador1, jogador2, ref tabuleiro, ref vezjogador1);
        } 
        else {  
            vezjogador1 = !vezjogador1; 
        }
    }
    else
    {
        interfaceJogo.Mostrar(jogadorAtual);
        Console.WriteLine($"O jogador {jogadorAtual.Nome} ganhou");
        fim = ResetarJogo(jogador1, jogador2, ref tabuleiro, ref vezjogador1);
    }
}
Console.WriteLine("Obrigado Por Jogar!");
Console.ReadLine();

static string NomeValidacao(string JogadorNumero)
{
    string nome = "";
    bool nomeinvalido = true;
    while (nomeinvalido)
    {
        Console.WriteLine($"Digite o nome do {JogadorNumero}: ");
        nome = Console.ReadLine();
        nomeinvalido = string.IsNullOrWhiteSpace(nome);
        if (nomeinvalido)
        {
            Console.Clear();
            Console.WriteLine("Digite um nome com pelo menos um caractere");
        }
    }
    return nome;
}
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