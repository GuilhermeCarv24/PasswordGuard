
using System;

public class AnalisadorSenha
{
    private readonly string[] padroesPrevisiveis =
    {
        "123456", "12345678", "123456789",
        "senha", "senha123", "qwerty", "abc123",
        "admin", "admin123", "password",
        "password123", "letmein", "welcome",
        "iloveyou", "000000", "111111"
    };

    private readonly string[] sequenciasConhecidas =
    {
        "123", "234", "345", "456", "567",
        "678", "789", "987", "876", "765",
        "654", "543", "432", "321",
        "abc", "bcd", "cde", "def", "efg",
        "fgh", "ghi", "hij", "ijk", "jkl",
        "klm", "lmn", "mno", "nop", "opq",
        "pqr", "qrs", "rst", "stu", "tuv",
        "uvw", "vwx", "wxy", "xyz"
    };

    public ResultadoAnalise Analisar(string senha)
    {
        ResultadoAnalise resultado = new();

        resultado.Comprimento = senha.Length;

        foreach (char c in senha)
        {
            if (char.IsUpper(c))
                resultado.PossuiMaiuscula = true;
            else if (char.IsLower(c))
                resultado.PossuiMinuscula = true;
            else if (char.IsDigit(c))
                resultado.PossuiNumero = true;
            else
                resultado.PossuiSimbolo = true;
        }

        string senhaMinuscula = senha.ToLowerInvariant();

        // Padrões conhecidos
        foreach (string padrao in padroesPrevisiveis)
        {
            if (senhaMinuscula.Contains(padrao))
            {
                resultado.EhPrevisivel = true;
                resultado.PadroesIdentificados.Add(
                    $"Padrão comum encontrado: {padrao}");
            }
        }

        // Sequências conhecidas
        foreach (string sequencia in sequenciasConhecidas)
        {
            if (senhaMinuscula.Contains(sequencia))
            {
                resultado.PossuiSequencia = true;
                resultado.PadroesIdentificados.Add(
                    $"Sequência previsível encontrada: {sequencia}");
            }
        }

        // Sequências ASCII crescentes/decrescentes
        for (int i = 0; i < senha.Length - 2; i++)
        {
            int a = senha[i];
            int b = senha[i + 1];
            int c = senha[i + 2];

            if ((b == a + 1 && c == b + 1) ||
                (b == a - 1 && c == b - 1))
            {
                resultado.PossuiSequencia = true;
                break;
            }
        }

        // Repetições consecutivas
        for (int i = 1; i < senha.Length; i++)
        {
            if (senha[i] == senha[i - 1])
            {
                resultado.PossuiRepeticao = true;
                break;
            }
        }

        if (resultado.PossuiRepeticao)
        {
            resultado.PadroesIdentificados.Add(
                "Caracteres repetidos consecutivamente");
        }

        resultado.EntropiaBits = CalcularEntropia(senha, resultado);
        resultado.Pontuacao = CalcularPontuacao(resultado);
        resultado.Classificacao = Classificar(resultado.Pontuacao);

        GerarRecomendacoes(resultado);

        return resultado;
    }

    private double CalcularEntropia(
        string senha,
        ResultadoAnalise resultado)
    {
        int alfabeto = 0;

        if (resultado.PossuiMinuscula) alfabeto += 26;
        if (resultado.PossuiMaiuscula) alfabeto += 26;
        if (resultado.PossuiNumero) alfabeto += 10;
        if (resultado.PossuiSimbolo) alfabeto += 32;

        if (senha.Length == 0 || alfabeto == 0)
            return 0;

        return senha.Length * Math.Log2(alfabeto);
    }

    private int CalcularPontuacao(ResultadoAnalise r)
    {
        // Comprimento: até 35 pontos (progressivo)
        int pontosComprimento = Math.Min(r.Comprimento, 18) * 2;

        // Diversidade: até 20 pontos
        int pontosDiversidade = 0;

        if (r.PossuiMaiuscula) pontosDiversidade += 5;
        if (r.PossuiMinuscula) pontosDiversidade += 5;
        if (r.PossuiNumero) pontosDiversidade += 5;
        if (r.PossuiSimbolo) pontosDiversidade += 5;

        // Entropia: até 25 pontos
        int pontosEntropia = (int)Math.Clamp(
            Math.Round(r.EntropiaBits / 3.2),
            0,
            25);

        int pontos = pontosComprimento
                  + pontosDiversidade
                  + pontosEntropia;

        // Penalidades
        if (r.EhPrevisivel)
            pontos -= 25;

        if (r.PossuiSequencia)
            pontos -= 15;

        if (r.PossuiRepeticao)
            pontos -= 10;

        return Math.Clamp(pontos, 0, 100);
    }

    private string Classificar(int pontos)
    {
        if (pontos < 30) return "MUITO FRACA";
        if (pontos < 50) return "FRACA";
        if (pontos < 70) return "RAZOAVEL";
        if (pontos < 90) return "FORTE";

        return "MUITO FORTE";
    }

    private void GerarRecomendacoes(ResultadoAnalise r)
    {
        if (r.Comprimento < 12)
            r.Recomendacoes.Add("Utilize pelo menos 12 caracteres.");

        if (!r.PossuiMaiuscula)
            r.Recomendacoes.Add("Adicione letras maiusculas.");

        if (!r.PossuiMinuscula)
            r.Recomendacoes.Add("Adicione letras minusculas.");

        if (!r.PossuiNumero)
            r.Recomendacoes.Add("Adicione numeros.");

        if (!r.PossuiSimbolo)
            r.Recomendacoes.Add("Adicione simbolos.");

        if (r.EhPrevisivel)
            r.Recomendacoes.Add("Evite palavras e padroes previsiveis.");

        if (r.PossuiRepeticao)
            r.Recomendacoes.Add("Evite repetir caracteres consecutivos.");

        if (r.PossuiSequencia)
            r.Recomendacoes.Add("Evite sequencias de caracteres.");

        if (r.Recomendacoes.Count == 0)
        {
            r.Recomendacoes.Add(
                "Prefira senhas unicas e geradas aleatoriamente.");
        }
    }
}
