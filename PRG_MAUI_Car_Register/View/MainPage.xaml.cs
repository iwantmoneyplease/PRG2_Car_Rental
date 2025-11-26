using PRG_MAUI_Car_Register.Model;
using PRG_MAUI_Car_Register.ViewModel;

namespace PRG_MAUI_Car_Register
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
