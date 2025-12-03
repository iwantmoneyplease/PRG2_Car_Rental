using PRG_MAUI_Car_Register.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PRG_MAUI_Car_Register.ViewModel
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public IList<Vehicle.Type> VehicleTypes { get; } =
        Enum.GetValues(typeof(Vehicle.Type)).Cast<Vehicle.Type>().ToList();

        //PropertyChanged looks for new input
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        //INPUT (Get:Set) -------------------------------------------------------
        private string _registrationNumber;
        public string RegistrationNumber
        {
            get => _registrationNumber;
            set { _registrationNumber = value; OnPropertyChanged(); }
        }

        private string _manufacturer;
        public string Manufacturer
        {
            get => _manufacturer;
            set { _manufacturer = value; OnPropertyChanged(); }
        }

        private string _model;
        public string Model
        {
            get => _model;
            set { _model = value; OnPropertyChanged(); }
        }

        private string _modelYear;
        public string ModelYear
        {
            get => _modelYear;
            set { _modelYear = value; OnPropertyChanged(); }
        }

        private Vehicle.Type _selectedType = Vehicle.Type.Bil;
        public Vehicle.Type SelectedType
        {
            get => _selectedType;
            set { _selectedType = value; OnPropertyChanged(); }
        }

        //COMMAND AND SEARCH ----------------------------------------------------
        public ObservableCollection<Vehicle> Vehicles => VehicleService.Instance.VehicleItems;

        //Commands for buttons
        public ICommand RegisterCommand { get; }
        public ICommand SearchCommand { get; }

        //Search result
        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set { _searchQuery = value; OnPropertyChanged(); }
        }

        private string _searchResult;
        public string SearchResult
        {
            get => _searchResult;
            set { _searchResult = value; OnPropertyChanged(); }
        }

        public MainPageViewModel()
        {
            RegisterCommand = new Command(RegisterVehicle);
            SearchCommand = new Command(SearchVehicle);
        }

        //COMMAND METHODS ------------------------------------------------------
        private void RegisterVehicle()
        {
            try
            {
                Vehicle vehicle;

                switch (SelectedType)
                {
                    case Vehicle.Type.Bil:
                        vehicle = new Car();
                        break;

                    case Vehicle.Type.MC:
                        vehicle = new Motorcycle();
                        break;

                    case Vehicle.Type.Lastbil:
                        vehicle = new Truck();
                        break;

                    default:
                        throw new ArgumentException("Välj en giltig fordons typ");
                }

                vehicle.RegistrationNumber = RegistrationNumber;
                vehicle.Manufacturer = Manufacturer;
                vehicle.Model = Model;
                vehicle.ModelYear = ModelYear;

                VehicleService.Instance.VehicleItems.Add(vehicle);

                // Clear input
                ClearEntryFields();
            }
            catch (ArgumentException ex)
            {
                // Show a friendly pop-up instead of crashing
                Application.Current.MainPage.DisplayAlert("Fel", ex.Message, "OK");
            }
        }

        private void SearchVehicle()
        {
            var query = SearchQuery?.Trim() ?? "";
            var result = Vehicles.FirstOrDefault(v =>
                !string.IsNullOrEmpty(v.RegistrationNumber) &&
                v.RegistrationNumber.Contains(query, StringComparison.OrdinalIgnoreCase)
             );

            if (result == null)
            {
                SearchResult = "Inget fordon hittades.";
            }
            else
            {
                SearchResult = $"{result.Manufacturer} {result.Model} ({result.ModelYear})";
            }
        }

        public void ClearEntryFields()
        {
            RegistrationNumber = string.Empty;
            Manufacturer = string.Empty;
            Model = string.Empty;
            ModelYear = string.Empty;
        }
    }
}