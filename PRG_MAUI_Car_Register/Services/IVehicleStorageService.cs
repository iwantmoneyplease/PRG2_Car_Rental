using PRG_MAUI_Car_Register.Model;

namespace PRG_MAUI_Car_Register.Services
{
    // poängen med detta interface är att vi enkelt ska kunna byta Json till något annat, som SQLite
    public interface IVehicleStorageService
    {
        Task SaveAsync(IEnumerable<Vehicle> vehicles);
        Task<IList<Vehicle>> LoadAsync();
    }
}
