using Jogodavelha;
using System;

#region Bem vindo
Console.ForegroundColor = ConsoleColor.Yellow; 
Console.WriteLine("Bem vindo ao jogo da Velha!");
Console.ResetColor();
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("1 - O primeiro jogador pode escolher um símbolo");
Console.WriteLine();
Console.WriteLine("2 - O símbolo X começa");
Console.WriteLine();
Console.WriteLine("3 - Ao final de cada rodada os símbolos dos jogadores são trocados");
Console.WriteLine();
Console.WriteLine("4 - Quando o jogo começar, ajuste o tamanho do console para que o placar seja exibido corretamente na sua tela");
Console.WriteLine();
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Aperte enter para continuar");
Console.ResetColor();
Console.ReadLine();
Console.Clear();

string nome1 = NomeValidacao("Jogador 1");
Console.Clear();
char simbolo = SelecionarSimbolo(nome1); 
Jogador jogador1 = new Jogador(nome1, simbolo);
Console.Clear();

string nome2 = NomeValidacao("Jogador 2");
Jogador jogador2 = new Jogador(nome2, jogador1);
Console.Clear();
#endregion

#region Looping Jogo
Jogo jogo = new Jogo(jogador1, jogador2);
while (jogo.FimDeJogo == false)
{
    jogo.ControleDeVez();
    jogo.MostrarHud();
    jogo.TabuleiroJogo.MarcarTabuleiro(jogo);
    jogo.VerificaVitoria();
    if (jogo.FimDeJogo == false)
    {
        if (jogo.TabuleiroJogo.VerificaEmpate())
        {
            jogo.MostrarHud();
            Console.WriteLine("Empate!");
            PerguntaResetarJogo(jogo);
        } 
        else {  
            jogo.TrocaVez(); 
        }
    }
    else
    {
        PerguntaResetarJogo(jogo);
    }
}
#endregion

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
{
    //Método para garantir que o símbolo seja corretamente selecionado e para garantir que é um char.
    Console.WriteLine($"Selecione um símbolo {nome}, escolha X ou O.");
    while (true)
    {
        string simbolo_string = Console.ReadLine().ToUpper();
        if (simbolo_string == "X" || simbolo_string == "O")
        {
            return simbolo_string[0]; 
        }
        else
        {
            Console.Clear() ;
            Console.WriteLine($"Entre com um símbolo válido {nome}! As opções são (X ou O).");
        }
    }
}

static void PerguntaResetarJogo(Jogo jogo)
    //Método para resetar o jogo ou finalizar. Ele altera tudo que é necessário para iniciar uma nova rodada 
{
    while (true)
    {
        Console.WriteLine("Você deseja Jogar novamente (S ou N)?");
        string resposta = Console.ReadLine().ToUpper();
        if (resposta == "S")
        {
            jogo.ResetarJogo();
            break;
        }
        else if (resposta == "N")
        {
            jogo.FinalizarJogo();
            break;
        }
        Console.WriteLine("Digite (S) para resetar ou (N) para parar de jogar");
    }
}