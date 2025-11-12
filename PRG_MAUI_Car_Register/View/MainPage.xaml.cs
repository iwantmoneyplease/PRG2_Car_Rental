using PRG_MAUI_Car_Register.Model;
using PRG_MAUI_Car_Register.ViewModel;

namespace PRG_MAUI_Car_Register
{
    public partial class MainPage : ContentPage
    {
        List<Vehicle> vehicleList = new List<Vehicle>();

        public MainPage()
        {
            InitializeComponent();
            pickerType.SelectedIndex = 0;
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            if (entryManufacturer.Text != "" && entryModel.Text != "")
            {
                try
                {
                    Vehicle vehicle;

                    switch ((Vehicle.Type)pickerType.SelectedIndex)
                    {
                        case Vehicle.Type.Bil:

                            vehicle = new Car();
                            vehicle.RegistrationNumber = entryRegistrationNumber.Text;
                            vehicle.Manufacturer = entryManufacturer.Text;
                            vehicle.Model = entryModel.Text;
                            vehicle.ModelYear = entryModelYear.Text;
                            break;

                        case Vehicle.Type.MC:

                            vehicle = new Motorcycle();
                            vehicle.RegistrationNumber = entryRegistrationNumber.Text;
                            vehicle.Manufacturer = entryManufacturer.Text;
                            vehicle.Model = entryModel.Text;
                            vehicle.ModelYear = entryModelYear.Text;

                            break;


                        case Vehicle.Type.Lastbil:

                            vehicle = new Truck();
                            vehicle.RegistrationNumber = entryRegistrationNumber.Text;
                            vehicle.Manufacturer = entryManufacturer.Text;
                            vehicle.Model = entryModel.Text;
                            vehicle.ModelYear = entryModelYear.Text;
                            break;

                        default:
                            throw new Exception("Okänd fordonstyp vald.");
                    }
                    vehicleList.Add(vehicle);
                    listViewVehicles.ItemsSource = null;
                    listViewVehicles.ItemsSource = vehicleList;

                    ClearEntryFields();
                }
                catch (ArgumentException ex)
                {
                    DisplayAlert("Fel", ex.Message, "OK");
                }
            }
        }

        private void OnRadioCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value != true) return;

            // Skapa en filtrerad lista baserat på vilken radioknapp som är vald
            List<Vehicle> filteredList;

            if (radioCar.IsChecked)
            {
                filteredList = vehicleList.Where(v => v.VehicleType == Vehicle.Type.Bil).ToList();
            }
            else if (radioMC.IsChecked)
            {
                filteredList = vehicleList.Where(v => v.VehicleType == Vehicle.Type.MC).ToList();
            }
            else if (radioTruck.IsChecked)
            {
                filteredList = vehicleList.Where(v => v.VehicleType == Vehicle.Type.Lastbil).ToList();
            }
            else
            {
                // Om "Alla" är vald, visa hela listan
                filteredList = vehicleList;
            }

            listViewVehicles.ItemsSource = filteredList;
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            string searchTerm = entrySearchRegistrationNumber.Text?.ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                entrySearchRegistrationNumber.Text = "Ange ett registreringsnummer för att söka.";
                return;
            }

            var foundVehicle = vehicleList.FirstOrDefault(v => v.RegistrationNumber?.ToLower() == searchTerm);

            if (foundVehicle != null)
            {
                labelSearchResult.Text = $"Fordon hittat:\n" +
                                         $"Registreringsnummer: {foundVehicle.RegistrationNumber}\n" +
                                         $"Tillverkare: {foundVehicle.Manufacturer}\n" +
                                         $"Modell: {foundVehicle.Model}\n" +
                                         $"Typ: {foundVehicle.VehicleType}\n" +
                                         $"År: {foundVehicle.ModelYear}";
            }
            else
            {
                labelSearchResult.Text = "Inget fordon hittades med det registreringsnumret.";
            }
        }
        private void ClearEntryFields()
        {
            entryRegistrationNumber.Text = string.Empty;
            entryManufacturer.Text = string.Empty;
            entryModel.Text = string.Empty;
            entryModelYear.Text = string.Empty;
        }
    }
}
