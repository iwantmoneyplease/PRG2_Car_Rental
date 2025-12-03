using PRG_MAUI_Car_Register.ViewModel;
using PRG_MAUI_Car_Register.View;

namespace PRG_MAUI_Car_Register.View
{
    public partial class Car : ContentPage
    {
        public Car()
        {
            InitializeComponent();
            BindingContext = new CarViewModel();
        }                   
    }
}
