using VelocityAutos.Web.ViewModels.Car;
using VelocityAutos.Services.Data.Models.Car;
using VelocityAutos.Data.Models;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface ICarService
    {
        Task<bool> ExistsByIdAsync(string carId);

        Task CreateAsync(CarFormModel carFormModel, string currUserId);

        Task<IEnumerable<CarAllViewModel>> GetAllCarsAsync();

        Task<bool> IsUserCarOwnerById(string carId, string userId);
    }
}
