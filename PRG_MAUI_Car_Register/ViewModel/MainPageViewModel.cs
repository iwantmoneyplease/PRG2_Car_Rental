using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.ViewModel
{
    namespace PRG_MAUI_Car_Register.ViewModel
    {
        class MainPageViewModel : INotifyPropertyChanged
        {
            //on property changed
            //public event PropertyChangedEventHandler PropertyChanged;
            //void OnPropertyChanged([CallerMemberName] string name = null)
            //    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

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

            private string _selectedType;
            public string SelectedType
            {
                get => _selectedType;
                set { _selectedType = value; OnPropertyChanged(); }
            }

            public ObservableCollection<Vehicle> Vehicles => VehicleService.Instance.VehicleItems;

            public ICommand RegisterCommand { get; }
            public ICommand SearchCommand { get; }

            private string _searchQuery;
            public string SearchQuery
            {
                get => _searchQuery;
                set { _searchQuery = value; 
                    OnPropertyChanged(); }
            }

            private string _searchResult;
            public string SearchResult
            {
                get => _searchResult;
                set { _searchResult = value; 
                    OnPropertyChanged(); }
            }


            public MainPageViewModel()
            {
                RegisterCommand = new Command(RegisterVehicle);
                SearchCommand = new Command(SearchVehicle);
            }

            private void RegisterVehicle()
            {
                Vehicle v = SelectedType switch
                {
                    "Bil" => new Car(),
                    "MC" => new Motorcycle(),
                    "Lastbil" => new Truck(),
                    _ => null
                };

                if (v == null) return;

                try
                {
                    v.RegistrationNumber = RegistrationNumber;
                    v.Manufacturer = Manufacturer;
                    v.Model = Model;
                    v.ModelYear = ModelYear;

                    Vehicles.Add(v);

                    RegistrationNumber = "";
                    Manufacturer = "";
                    Model = "";
                    ModelYear = "";
                    SelectedType = null;
                }
                catch (Exception ex)
                {
                    SearchResult = ex.Message;
                }
            }

            private void SearchVehicle()
            {
                var result = Vehicles.FirstOrDefault(v => v.RegistrationNumber == SearchQuery);

                SearchResult = result == null
                    ? "Inget fordon hittades."
                    : $"{result.Manufacturer} {result.Model} ({result.ModelYear})";
            }
        }
    }
}
