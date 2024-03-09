using VelocityAutos.Web.ViewModels.Car;
using VelocityAutos.Data.Models;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface ICarService
    {
        Task<bool> ExistsByIdAsync(string carId);

        Task CreateAsync(CarFormModel carFormModel);

        Task<IEnumerable<CarAllViewModel>> GetAllCarsAsync();

        Task<Car> GetCarAsync(CarFormModel formModel, string currUserId);

        Task<CarDetailsViewModel> GetCarAsync(string carId);
    }
}
