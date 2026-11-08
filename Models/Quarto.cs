
namespace HotelBraga.Models;

public class Quarto
{
    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public string Imagem { get; set; } = string.Empty;

    public decimal ValorDiaria { get; set; }

    public int CapacidadeMaxima { get; set; }

    public string PrecoFormatado =>
        ValorDiaria.ToString("C",
            new System.Globalization.CultureInfo("pt-BR"));
}
