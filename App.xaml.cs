using HotelBraga.Views;

namespace HotelBraga;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new MainPage())
        {
            BarBackgroundColor = Color.FromArgb("#142D4E"),
            BarTextColor = Colors.White
        };
    }
}
