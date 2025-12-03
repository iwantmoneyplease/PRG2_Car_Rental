using PRG_MAUI_Car_Register.ViewModel;
using PRG_MAUI_Car_Register.View;

namespace PRG_MAUI_Car_Register.View
{
    public partial class Truck : ContentPage
    {
        public Truck()
        {
            InitializeComponent();
            BindingContext = new TruckViewModel();
        }
    }
}
