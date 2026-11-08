
using HotelBraga.Models;
using HotelBraga.Services;
using HotelBraga.Views;
using System.Globalization;

namespace HotelBraga;

public partial class MainPage : ContentPage
{
    private readonly QuartoService _quartoService;
    private readonly ReservaService _reservaService;
    private readonly List<Quarto> _quartos;

    public MainPage()
    {
        InitializeComponent();

        _quartoService = new QuartoService();
        _reservaService = new ReservaService();

        // Carrega os quatro quartos cadastrados.
        _quartos = _quartoService.ListarQuartos();

        TipoQuarto.Items.Clear();

        foreach (Quarto quarto in _quartos)
        {
            TipoQuarto.Items.Add(quarto.Nome);
        }

        // Configura as datas.
        DataEntrada.MinimumDate = DateTime.Today;
        DataEntrada.Date = DateTime.Today;

        DataSaida.MinimumDate = DateTime.Today.AddDays(1);
        DataSaida.Date = DateTime.Today.AddDays(1);

        DataEntrada.DateSelected += (sender, e) =>
        {
            DateTime novaSaida = e.NewDate.AddDays(1);

            DataSaida.MinimumDate = novaSaida;

            if (DataSaida.Date < novaSaida)
            {
                DataSaida.Date = novaSaida;
            }
        };
    }

    private async void AbrirAcomodacoes_Clicked(
        object sender, EventArgs e)
    {
        await Navigation.PushAsync(
            new AcomodacoesPage());
    }

    private async void ConsultarReserva_Clicked(
        object sender, EventArgs e)
    {
        Quarto? quartoSelecionado = null;

        if (TipoQuarto.SelectedIndex >= 0)
        {
            quartoSelecionado =
                _quartos[TipoQuarto.SelectedIndex];
        }

        Reserva reserva = new Reserva
        {
            QuartoSelecionado = quartoSelecionado,
            DataEntrada = DataEntrada.Date,
            DataSaida = DataSaida.Date,
            QuantidadeHospedes =
                (int)QuantidadeHospedes.Value
        };

        // Verifica as regras da reserva.
        string? erro =
            _reservaService.ValidarReserva(reserva);

        if (erro != null)
        {
            await DisplayAlert(
                "Atenção",
                erro,
                "OK");

            return;
        }

        // Calcula o valor da hospedagem.
        decimal valorTotal =
            _reservaService.CalcularTotal(reserva);

        string totalFormatado = valorTotal.ToString(
            "C2",
            new CultureInfo("pt-BR"));

        string mensagem =
            $"Quarto: {quartoSelecionado!.Nome}\n" +
            $"Entrada: {reserva.DataEntrada:dd/MM/yyyy}\n" +
            $"Saída: {reserva.DataSaida:dd/MM/yyyy}\n" +
            $"Hóspedes: {reserva.QuantidadeHospedes}\n" +
            $"Diárias: {reserva.QuantidadeDiarias}\n" +
            $"Valor da diária: {quartoSelecionado.PrecoFormatado}\n" +
            $"Valor total: {totalFormatado}";

        await DisplayAlert(
            "Resumo da reserva",
            mensagem,
            "OK");
    }

    private async void AbrirSobre_Clicked(
        object sender, EventArgs e)
    {
        await Navigation.PushAsync(
            new SobrePage());
    }
}
