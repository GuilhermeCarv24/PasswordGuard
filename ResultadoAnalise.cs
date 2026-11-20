public class ResultadoAnalise
{
    public int Comprimento { get; set; }
    public bool PossuiMaiuscula { get; set; }
    public bool PossuiMinuscula { get; set; }
    public bool PossuiNumero { get; set; }
    public bool PossuiSimbolo { get; set; }
    public bool EhPrevisivel { get; set; }
    public bool PossuiRepeticao { get; set; }
    public bool PossuiSequencia { get; set; }

    public double EntropiaBits { get; set; }

    public int Pontuacao { get; set; }
    public string Classificacao { get; set; } = "";

    public List<string> Recomendacoes { get; set; } = new();
    public List<string> PadroesIdentificados { get; set; } = new();
}