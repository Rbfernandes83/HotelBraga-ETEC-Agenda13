
namespace HotelBraga.Models;

public class Reserva
{
    public Quarto? QuartoSelecionado { get; set; }

    public DateTime DataEntrada { get; set; } = DateTime.Today;

    public DateTime DataSaida { get; set; } = DateTime.Today.AddDays(1);

    public int QuantidadeHospedes { get; set; } = 1;

    public int QuantidadeDiarias =>
        Math.Max(0, (DataSaida.Date - DataEntrada.Date).Days);

    public decimal ValorTotal =>
        (QuartoSelecionado?.ValorDiaria ?? 0m) * QuantidadeDiarias;

    public string ValorTotalFormatado =>
        ValorTotal.ToString("C",
            new System.Globalization.CultureInfo("pt-BR"));
}
