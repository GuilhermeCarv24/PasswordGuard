
public class AnalisadorSenha
{
    private readonly string[] padroesPrevisiveis =
    {
        "123456",
        "12345678",
        "123456789",
        "senha",
        "senha123",
        "qwerty",
        "abc123",
        "admin",
        "admin123",
        "password",
        "password123"
    };

    public ResultadoAnalise Analisar(string senha)
    {
        ResultadoAnalise resultado = new ResultadoAnalise();

        resultado.Comprimento = senha.Length;

        foreach (char caractere in senha)
        {
            if (char.IsUpper(caractere))
                resultado.PossuiMaiuscula = true;
            else if (char.IsLower(caractere))
                resultado.PossuiMinuscula = true;
            else if (char.IsDigit(caractere))
                resultado.PossuiNumero = true;
            else
                resultado.PossuiSimbolo = true;
        }

        // Detecta padrões previsíveis
        string senhaMinuscula = senha.ToLowerInvariant();

        foreach (string padrao in padroesPrevisiveis)
        {
            if (senhaMinuscula.Contains(padrao))
            {
                resultado.EhPrevisivel = true;
                break;
            }
        }

        // Detecta repetições
        for (int i = 1; i < senha.Length; i++)
        {
            if (senha[i] == senha[i - 1])
            {
                resultado.PossuiRepeticao = true;
                break;
            }
        }

        // Detecta sequências
        for (int i = 0; i < senha.Length - 2; i++)
        {
            int primeiro = senha[i];
            int segundo = senha[i + 1];
            int terceiro = senha[i + 2];

            if ((segundo == primeiro + 1 && terceiro == segundo + 1) ||
                (segundo == primeiro - 1 && terceiro == segundo - 1))
            {
                resultado.PossuiSequencia = true;
                break;
            }
        }

        // Pontuação por comprimento
        if (resultado.Comprimento >= 12)
            resultado.Pontuacao += 2;
        else if (resultado.Comprimento >= 8)
            resultado.Pontuacao += 1;

        // Pontuação por variedade
        if (resultado.PossuiMaiuscula)
            resultado.Pontuacao++;

        if (resultado.PossuiMinuscula)
            resultado.Pontuacao++;

        if (resultado.PossuiNumero)
            resultado.Pontuacao++;

        if (resultado.PossuiSimbolo)
            resultado.Pontuacao++;

        // Penalidades
        if (resultado.EhPrevisivel)
            resultado.Pontuacao -= 2;

        if (resultado.PossuiRepeticao)
            resultado.Pontuacao--;

        if (resultado.PossuiSequencia)
            resultado.Pontuacao--;

        resultado.Pontuacao = Math.Clamp(resultado.Pontuacao, 0, 6);

        // Classificação
        if (resultado.Pontuacao <= 2)
            resultado.Classificacao = "FRACA";
        else if (resultado.Pontuacao <= 4)
            resultado.Classificacao = "RAZOAVEL";
        else
            resultado.Classificacao = "FORTE";

        // Recomendações
        if (resultado.Comprimento < 12)
            resultado.Recomendacoes.Add("Utilize pelo menos 12 caracteres.");

        if (!resultado.PossuiMaiuscula)
            resultado.Recomendacoes.Add("Adicione letras maiusculas.");

        if (!resultado.PossuiMinuscula)
            resultado.Recomendacoes.Add("Adicione letras minusculas.");

        if (!resultado.PossuiNumero)
            resultado.Recomendacoes.Add("Adicione numeros.");

        if (!resultado.PossuiSimbolo)
            resultado.Recomendacoes.Add("Adicione simbolos.");

        if (resultado.EhPrevisivel)
            resultado.Recomendacoes.Add("Evite palavras e padroes previsiveis.");

        if (resultado.PossuiRepeticao)
            resultado.Recomendacoes.Add("Evite repetir caracteres consecutivos.");

        if (resultado.PossuiSequencia)
            resultado.Recomendacoes.Add("Evite sequencias de caracteres.");

        if (resultado.Recomendacoes.Count == 0)
            resultado.Recomendacoes.Add("Nenhuma melhoria basica identificada. Prefira uma senha unica e aleatoria.");

        return resultado;
    }
}
