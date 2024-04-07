﻿using VelocityAutos.Web.ViewModels.Car;
using VelocityAutos.Data.Models;
using System.Globalization;
using VelocityAutos.Services.Data.Models.Car;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface ICarService
    {
        Task<bool> ExistsByIdAsync(string carId);

        Task<string> CreateAsync(CarFormModel carFormModel);

        Task<AllCarsFilteredAndPaged> GetAllCarsAsync(AllCarsQueryModel queryModel);

        Task<Car> GetCarEntityAsync(string carId);

        Task<CarDetailsViewModel> GetCarDetailsAsync(string carId);

        Task<CarFormModel> GetCarEditAsync(string carId);

        Task UpdateAsync(CarFormModel carFormModel, string carId);

        Task<IEnumerable<CarAllViewModel>> GetOwnedCarsAsync(string userId);

        Task<bool> SaveCarAsync(string carId, string userId);

        Task<IEnumerable<CarAllViewModel>> GetSavedCarsAsync(string userId);

        Task<bool> RemoveFromSavedAsync(string carId, string userId);
    }
}
