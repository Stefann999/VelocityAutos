using VelocityAutos.Web.ViewModels.FuelType;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface IFuelTypeService
    {
        Task<IEnumerable<CarSelectFuelTypeFormModel>> AllFuelTypesAsync();

        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<string>> AllFuelTypeNamesAsync();
    }
}
