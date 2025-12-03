using PRG_MAUI_Car_Register.ViewModel;
using PRG_MAUI_Car_Register.View;

namespace PRG_MAUI_Car_Register.View
{
    public partial class Motorcycle : ContentPage
    {
        public Motorcycle()
        {
            InitializeComponent();
            BindingContext = new MotorcycleViewModel();
        }
    }
}
