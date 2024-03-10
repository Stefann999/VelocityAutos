﻿using Microsoft.EntityFrameworkCore;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Data;
using VelocityAutos.Web.ViewModels.Car;
using VelocityAutos.Data.Models;

using System.Drawing;

namespace VelocityAutos.Services.Data
{
    public class CarService : ICarService
    {
        private readonly VelocityAutosDbContext dbContext;
        private readonly IDropboxService dropboxService;

        public CarService(VelocityAutosDbContext dbContext, IDropboxService dropboxService)
        {
            this.dbContext = dbContext;
            this.dropboxService = dropboxService;

        }

        public async Task<bool> ExistsByIdAsync(string carId)
        {
            bool result = await this.dbContext
                .Cars
                .AnyAsync(c => c.Id.ToString() == carId);

            return result;
        }

        public async Task<IEnumerable<CarAllViewModel>> GetAllCarsAsync()
        {
            var cars = await this.dbContext
                .Posts
                .AsNoTracking()
                .Where(p => p.IsActive == true)
                .Select(p => new CarAllViewModel
                {
                    Id = p.Car.Id.ToString(),
                    Make = p.Car.Make,
                    Model = p.Car.Model,
                    Price = p.Car.Price,
                    Month = p.Car.Month,
                    Year = p.Car.Year,
                    Mileage = p.Car.Mileage,
                    HorsePower = p.Car.HorsePower,
                    FuelConsumption = p.Car.FuelConsumption,
                    Color = p.Car.Color,
                    Description = p.Car.Description,
                    LocationCity = p.Car.LocationCity,
                    LocationCountry = p.Car.LocationCountry
                })
                .ToListAsync();

            return cars;
        }

        public async Task<string> CreateAsync(CarFormModel carFormModel)
        {
            Car newCar = new Car
            {
                Make = carFormModel.Make,
                Model = carFormModel.Model,
                Price = carFormModel.Price,
                Month = carFormModel.Month,
                Year = carFormModel.Year,
                Mileage = carFormModel.Mileage,
                HorsePower = carFormModel.HorsePower,
                FuelTypeId = carFormModel.FuelTypeId,
                FuelConsumption = carFormModel.FuelConsumption,
                TransmissionTypeId = carFormModel.TransmissionTypeId,
                Color = carFormModel.Color,
                Description = carFormModel.Description,
                LocationCity = carFormModel.LocationCity,
                LocationCountry = carFormModel.LocationCountry,
                CategoryId = carFormModel.CategoryId
            };

            ICollection<Image> images = new HashSet<Image>();

            var imageUrls = await this.dropboxService
                .UploadImagesAsync(carFormModel.Images, newCar.Id);

            foreach (var imageUrl in imageUrls)
            {
                string[] parts = imageUrl.Split('/');

                // Get the last part which contains the file name with extension
                string lastPart = parts[parts.Length - 1];

                // Remove the extension
                string fileNameWithoutExtension = lastPart.Substring(0, lastPart.LastIndexOf('.'));

                Image currImage = new Image
                {
                    Id = Guid.Parse(fileNameWithoutExtension),
                    ImagePath = imageUrl,
                    CarId = newCar.Id
                };
                await this.dbContext.Images.AddAsync(currImage);
                images.Add(currImage);
            }

            newCar.Images = images;

            await this.dbContext.Cars.AddAsync(newCar);
            await this.dbContext.SaveChangesAsync();

            return newCar.Id.ToString();
        }

        public async Task<Car> GetCarEntityAsync(string carId)
        {
            return await this.dbContext
                .Cars
                .FirstOrDefaultAsync(c => c.Id.ToString() == carId);
        }

        public async Task<CarDetailsViewModel> GetCarDetailsAsync(string carId)
        {
            var car = await this.dbContext
                .Cars
                .AsNoTracking()
                .Where(c => c.Id.ToString() == carId)
                .Select(c => new CarDetailsViewModel
                {
                    Id = c.Id.ToString(),
                    Make = c.Make,
                    Model = c.Model,
                    Price = c.Price,
                    Month = c.Month,
                    Year = c.Year,
                    Mileage = c.Mileage,
                    HorsePower = c.HorsePower,
                    FuelConsumption = c.FuelConsumption,
                    Color = c.Color,
                    Description = c.Description,
                    LocationCity = c.LocationCity,
                    LocationCountry = c.LocationCountry,
                    Category = c.Category.Name,
                    FuelType = c.FuelType.Name,
                    TransmissionType = c.TransmissionType.Name
                })
                .FirstOrDefaultAsync();

            return car;
        }

        public async Task<CarFormModel> GetCarEditAsync(string carId)
        {
                var car = await this.dbContext
                .Cars
                .AsNoTracking()
                .Where(c => c.Id.ToString() == carId)
                .Select(c => new CarFormModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    Price = c.Price,
                    Month = c.Month,
                    Year = c.Year,
                    Mileage = c.Mileage,
                    HorsePower = c.HorsePower,
                    FuelTypeId = c.FuelTypeId,
                    FuelConsumption = c.FuelConsumption,
                    TransmissionTypeId = c.TransmissionTypeId,
                    Color = c.Color,
                    Description = c.Description,
                    LocationCity = c.LocationCity,
                    LocationCountry = c.LocationCountry,
                    CategoryId = c.CategoryId
                })
                .FirstOrDefaultAsync();

            return car;
        }

        public async Task UpdateAsync(CarFormModel carFormModel, string carId)
        {
            var carForEdit = await this.dbContext
                .Cars
                .FirstOrDefaultAsync(c => c.Id.ToString() == carId);

            if (carForEdit != null)
            {
                carForEdit.Make = carFormModel.Make;
                carForEdit.Model = carFormModel.Model;
                carForEdit.Price = carFormModel.Price;
                carForEdit.Month = carFormModel.Month;
                carForEdit.Year = carFormModel.Year;
                carForEdit.Mileage = carFormModel.Mileage;
                carForEdit.HorsePower = carFormModel.HorsePower;
                carForEdit.FuelTypeId = carFormModel.FuelTypeId;
                carForEdit.FuelConsumption = carFormModel.FuelConsumption;
                carForEdit.TransmissionTypeId = carFormModel.TransmissionTypeId;
                carForEdit.Color = carFormModel.Color;
                carForEdit.Description = carFormModel.Description;
                carForEdit.LocationCity = carFormModel.LocationCity;
                carForEdit.LocationCountry = carFormModel.LocationCountry;
                carForEdit.CategoryId = carFormModel.CategoryId;
            }

            await this.dbContext.SaveChangesAsync();
        }
    }
}
