using PRG_MAUI_Car_Register.Model;
using PRG_MAUI_Car_Register.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

class MotorcycleViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string n = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));

    public ObservableCollection<Vehicle> Cars { get; }
        = new ObservableCollection<Vehicle>();

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

    public ICommand SearchCommand { get; }

    public MotorcycleViewModel()
    {
        // Load cars ONCE when the page is created
        LoadCars();

        SearchCommand = new Command(SearchCar);
    }

    private void LoadCars()
    {
        Cars.Clear();
        foreach (var v in VehicleService.Instance.VehicleItems
                     .Where(v => v.VehicleType == Vehicle.Type.MC))
            Cars.Add(v);
    }

    private void SearchCar()
    {
        var q = SearchQuery?.Trim() ?? "";

        var result = Cars.FirstOrDefault(v =>
            !string.IsNullOrEmpty(v.RegistrationNumber) &&
            v.RegistrationNumber.Contains(q, StringComparison.OrdinalIgnoreCase));

        SearchResult = result == null
            ? "Ingen bil hittades."
            : $"{result.Manufacturer} {result.Model} ({result.ModelYear})";
    }
}