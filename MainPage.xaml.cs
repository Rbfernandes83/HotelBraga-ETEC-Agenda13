namespace HotelBraga;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

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

    private async void ConsultarReserva_Clicked(
        object sender, EventArgs e)
    {
        if (TipoQuarto.SelectedIndex == -1)
        {
            await DisplayAlert(
                "Atenção",
                "Selecione o tipo de quarto.",
                "OK");
            return;
        }

        if (DataSaida.Date <= DataEntrada.Date)
        {
            await DisplayAlert(
                "Atenção",
                "A data de saída deve ser posterior à entrada.",
                "OK");
            return;
        }

        string quarto = TipoQuarto.SelectedItem.ToString()!;
        int hospedes = (int)QuantidadeHospedes.Value;
        int diarias = (DataSaida.Date - DataEntrada.Date).Days;

        string mensagem =
            $"Quarto: {quarto}\n" +
            $"Entrada: {DataEntrada.Date:dd/MM/yyyy}\n" +
            $"Saída: {DataSaida.Date:dd/MM/yyyy}\n" +
            $"Hóspedes: {hospedes}\n" +
            $"Diárias: {diarias}";

        await DisplayAlert(
            "Resumo da reserva",
            mensagem,
            "OK");
    }

    private async void AbrirSobre_Clicked(
        object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SobrePage());
    }
}


