
Console.WriteLine("==================================");
Console.WriteLine("          PASSWORD GUARD");
Console.WriteLine("      AUDITOR DE SENHAS");
Console.WriteLine("==================================");

Console.WriteLine();

Console.Write("Digite uma senha para analisar: ");

string senha = Console.ReadLine() ?? "";

if (string.IsNullOrWhiteSpace(senha))
{
    Console.WriteLine("Erro: voce precisa informar uma senha.");
    return;
}

Console.WriteLine();
Console.WriteLine("Analisando senha...");
Console.WriteLine();

AnalisadorSenha analisador = new AnalisadorSenha();

ResultadoAnalise resultado = analisador.Analisar(senha);

Console.WriteLine("===== RESULTADO DA ANALISE =====");

Console.WriteLine($"Comprimento: {resultado.Comprimento} caracteres");
Console.WriteLine($"Maiusculas: {(resultado.PossuiMaiuscula ? "Sim" : "Nao")}");
Console.WriteLine($"Minusculas: {(resultado.PossuiMinuscula ? "Sim" : "Nao")}");
Console.WriteLine($"Numeros: {(resultado.PossuiNumero ? "Sim" : "Nao")}");
Console.WriteLine($"Simbolos: {(resultado.PossuiSimbolo ? "Sim" : "Nao")}");
Console.WriteLine($"Senha previsivel: {(resultado.EhPrevisivel ? "Sim" : "Nao")}");
Console.WriteLine($"Possui repeticoes: {(resultado.PossuiRepeticao ? "Sim" : "Nao")}");
Console.WriteLine($"Possui sequencias: {(resultado.PossuiSequencia ? "Sim" : "Nao")}");

Console.WriteLine();
Console.WriteLine($"Pontuacao: {resultado.Pontuacao}/6");
Console.WriteLine($"Classificacao: {resultado.Classificacao}");

Console.WriteLine();
Console.WriteLine("===== RECOMENDACOES =====");

foreach (string recomendacao in resultado.Recomendacoes)
{
    Console.WriteLine($"- {recomendacao}");
}

Console.WriteLine("==================================");
