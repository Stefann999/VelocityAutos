using VelocityAutos.Web.ViewModels.Car;
using VelocityAutos.Data.Models;
using System.Globalization;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface ICarService
    {
        Task<bool> ExistsByIdAsync(string carId);

        Task<string> CreateAsync(CarFormModel carFormModel);

        Task<IEnumerable<CarAllViewModel>> GetAllCarsAsync();

        Task<Car> GetCarEntityAsync(string carId);

        Task<CarDetailsViewModel> GetCarDetailsAsync(string carId);

        Task<CarFormModel> GetCarEditAsync(string carId);

        Task UpdateAsync(CarFormModel carFormModel, string carId);
    }
}
