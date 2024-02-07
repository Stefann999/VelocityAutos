using VelocityAutos.Web.ViewModels.Car;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface ICarService
    {
        Task<bool> ExistsByIdAsync(string carId);

        Task CreateAsync(CarFormModel carFormModel, string currUserId);
    }
}
