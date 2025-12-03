using PRG_MAUI_Car_Register.ViewModel;
using PRG_MAUI_Car_Register.View;

namespace PRG_MAUI_Car_Register.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}
