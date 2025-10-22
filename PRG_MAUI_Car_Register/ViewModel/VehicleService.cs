using PRG_MAUI_Car_Register.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;
using static System.Reflection.Metadata.BlobBuilder;

namespace PRG_MAUI_Car_Register.ViewModel
{
    class VehicleService
    {
        // för att säkerställa singleton (se ovan)
        private static VehicleService _instance;
        public static VehicleService Instance => _instance ??= new VehicleService();

        // själva listan
        public ObservableCollection<Vehicle> VehicleItems { get; set; }

        // några defaultvärden (ta bort denna sen)
        private VehicleService()
        {
            VehicleItems = new ObservableCollection<Vehicle>
            {
            new Car(),
            new Motorcycle(),
            new Truck(),
            };
        }
    }

}
