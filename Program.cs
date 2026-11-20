
using System.Text;

Console.WriteLine("==================================");
Console.WriteLine("          PASSWORD GUARD");
Console.WriteLine("       AUDITOR DE SENHAS V2");
Console.WriteLine("==================================");
Console.WriteLine();

string senha;

do
{
    Console.Write("Digite uma senha para analisar: ");
    senha = LerSenhaProtegida();

    if (string.IsNullOrWhiteSpace(senha))
    {
        Console.WriteLine("Erro: a senha não pode estar vazia.");
        Console.WriteLine();
    }

} while (string.IsNullOrWhiteSpace(senha));

Console.WriteLine();
Console.WriteLine("Analisando senha...");
Console.WriteLine();

AnalisadorSenha analisador = new AnalisadorSenha();
ResultadoAnalise resultado = analisador.Analisar(senha);

Console.WriteLine("========== RESULTADO ==========");
Console.WriteLine($"Comprimento: {resultado.Comprimento}");
Console.WriteLine($"Maiúsculas: {(resultado.PossuiMaiuscula ? "Sim" : "Não")}");
Console.WriteLine($"Minúsculas: {(resultado.PossuiMinuscula ? "Sim" : "Não")}");
Console.WriteLine($"Números: {(resultado.PossuiNumero ? "Sim" : "Não")}");
Console.WriteLine($"Símbolos: {(resultado.PossuiSimbolo ? "Sim" : "Não")}");
Console.WriteLine($"Previsível: {(resultado.EhPrevisivel ? "Sim" : "Não")}");
Console.WriteLine($"Repetições: {(resultado.PossuiRepeticao ? "Sim" : "Não")}");
Console.WriteLine($"Sequências: {(resultado.PossuiSequencia ? "Sim" : "Não")}");
Console.WriteLine($"Entropia estimada: {resultado.EntropiaBits:F2} bits");
Console.WriteLine();

Console.WriteLine($"Pontuação: {resultado.Pontuacao}/100");
Console.WriteLine($"Classificação: {resultado.Classificacao}");
Console.WriteLine();

Console.WriteLine("======= PADRÕES DETECTADOS =======");

if (resultado.PadroesIdentificados.Count > 0)
{
    foreach (string padrao in resultado.PadroesIdentificados)
    {
        Console.WriteLine($"[ALERTA] {padrao}");
    }
}
else
{
    Console.WriteLine("Nenhum padrão conhecido foi identificado.");
}

Console.WriteLine();
Console.WriteLine("======= RECOMENDAÇÕES =======");

foreach (string recomendacao in resultado.Recomendacoes)
{
    Console.WriteLine($"- {recomendacao}");
}

Console.WriteLine();
Console.WriteLine("=============================");
Console.WriteLine("Análise finalizada.");

static string LerSenhaProtegida()
{
    StringBuilder senha = new();

    while (true)
    {
        ConsoleKeyInfo tecla = Console.ReadKey(true);

        if (tecla.Key == ConsoleKey.Enter)
        {
            Console.WriteLine();
            return senha.ToString();
        }

        if (tecla.Key == ConsoleKey.Backspace)
        {
            if (senha.Length > 0)
            {
                senha.Length--;
                Console.Write("\b \b");
            }

            continue;
        }

        if (char.IsControl(tecla.KeyChar))
            continue;

        senha.Append(tecla.KeyChar);
        Console.Write("*");
    }
}
