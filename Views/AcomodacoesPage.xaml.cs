
using HotelBraga.Services;

namespace HotelBraga.Views;

public partial class AcomodacoesPage : ContentPage
{
    private readonly QuartoService _quartoService;

    public AcomodacoesPage()
    {
        InitializeComponent();

        _quartoService = new QuartoService();

        ListaQuartos.ItemsSource =
            _quartoService.ListarQuartos();
    }
}
