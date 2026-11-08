
using HotelBraga.Models;

namespace HotelBraga.Services;

public class ReservaService
{
    public string? ValidarReserva(Reserva reserva)
    {
        if (reserva.QuartoSelecionado == null)
        {
            return "Selecione um tipo de quarto.";
        }

        if (reserva.DataEntrada.Date < DateTime.Today)
        {
            return "A data de entrada não pode ser anterior a hoje.";
        }

        if (reserva.DataSaida.Date <= reserva.DataEntrada.Date)
        {
            return "A data de saída deve ser posterior à entrada.";
        }

        if (reserva.QuantidadeHospedes < 1)
        {
            return "Informe pelo menos um hóspede.";
        }

        if (reserva.QuantidadeHospedes >
            reserva.QuartoSelecionado.CapacidadeMaxima)
        {
            return $"O quarto selecionado permite no máximo " +
                   $"{reserva.QuartoSelecionado.CapacidadeMaxima} hóspede(s).";
        }

        return null;
    }

    public decimal CalcularTotal(Reserva reserva)
    {
        return reserva.ValorTotal;
    }
}
