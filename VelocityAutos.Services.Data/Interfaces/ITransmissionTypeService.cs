using VelocityAutos.Web.ViewModels.SelectViewModels;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface ITransmissionTypeService
    {
        Task<IEnumerable<CarSelectTransmissionFormModel>> AllTransmissionTypesAsync();

        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<string>> AllTransmissionTypeNamesAsync();
    }
}
