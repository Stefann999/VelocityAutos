using Microsoft.EntityFrameworkCore;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Data;
using VelocityAutos.Web.ViewModels.Car;
using VelocityAutos.Data.Models;
using VelocityAutos.Web.Infrastructure.Common;
using static Dropbox.Api.Files.SearchMatchType;
using VelocityAutos.Common;

namespace VelocityAutos.Services.Data
{
    public class CarService : ICarService
    {
        private readonly IDropboxService dropboxService;
        private readonly IRepository repository;

        public CarService(IDropboxService dropboxService,
            IRepository repository)
        {
            this.dropboxService = dropboxService;
            this.repository = repository;
        }

        public async Task<bool> ExistsByIdAsync(string carId)
        {
            bool result = await repository.AllAsReadOnly<Car>()
                .AnyAsync(c => c.Id.ToString() == carId);

            return result;
        }

        public async Task<IEnumerable<CarAllViewModel>> GetAllCarsAsync()
        {
            var cars = await repository.AllAsReadOnly<Post>()
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


            string imagePath = await this.dropboxService
                .UploadImagesAsync(carFormModel.Images, newCar.Id.ToString());

            Image image = new Image
            {
                Car = newCar,
                CarId = newCar.Id,
                ImagePath = imagePath
            };

            newCar.Image = image;

            await repository.AddAsync(newCar);
            await repository.SaveChangesAsync();

            return newCar.Id.ToString();
        }

        public async Task<Car> GetCarEntityAsync(string carId)
        {
            return await repository.AllAsReadOnly<Car>()
                .FirstOrDefaultAsync(c => c.Id.ToString() == carId);
        }

        public async Task<CarDetailsViewModel> GetCarDetailsAsync(string carId)
        {
            var car = await repository.AllAsReadOnly<Car>()
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
                var car = await repository.All<Car>()
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
                    CategoryId = c.CategoryId,
                    PostId = c.Post.Id.ToString(),
                    SellerId = c.Post.SellerId.ToString()
                })
                .FirstOrDefaultAsync();

            return car;
        }

        public async Task UpdateAsync(CarFormModel carFormModel, string carId)
        {
            var carForEdit = await repository.All<Car>()
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

                if (carFormModel.Images.Any())
                {
                    await this.dropboxService.UploadImagesAsync(carFormModel.Images, carId);
                }
            }
            else
            {
                throw new NullReferenceException("Car not found");
            }

            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarAllViewModel>> GetOwnedCarsAsync(string userId)
        {
            var ownedCars = await repository.AllAsReadOnly<Post>()
                .Where(p => p.SellerId.ToString() == userId)
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

            return ownedCars;
        }

        public async Task<bool> SaveCarAsync(string carId, string userId)
        {
            var savedCar = await repository.All<UserCar>()
                .FirstOrDefaultAsync(uc => uc.UserId.ToString() == userId && uc.CarId.ToString() == carId);

            var user = await repository.All<ApplicationUser>()
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            var car = await repository.All<Car>()
                .Where(c => c.Id.ToString() == carId)
                .FirstOrDefaultAsync();

            if (savedCar == null)
            {
                if (user != null && car != null)
                {
                    var newSavedCar = new UserCar
                    {
                        UserId = Guid.Parse(userId),
                        CarId = Guid.Parse(carId)
                    };

                    await repository.AddAsync(newSavedCar);
                    await repository.SaveChangesAsync();
                    
                    return true;
                }
            }

            return false;
        }

        public async Task<IEnumerable<CarAllViewModel>> GetSavedCars(string userId)
        {
            var savedCars = await repository.AllAsReadOnly<UserCar>()
               .Where(uc => uc.UserId.ToString() == userId)
               .Select(uc => new CarAllViewModel
               {
                   Id = uc.Car.Id.ToString(),
                   Make = uc.Car.Make,
                   Model = uc.Car.Model,
                   Price = uc.Car.Price,
                   Month = uc.Car.Month,
                   Year = uc.Car.Year,
                   Mileage = uc.Car.Mileage,
                   HorsePower = uc.Car.HorsePower,
                   FuelConsumption = uc.Car.FuelConsumption,
                   Color = uc.Car.Color,
                   Description = uc.Car.Description,
                   LocationCity = uc.Car.LocationCity,
                   LocationCountry = uc.Car.LocationCountry
               })
               .ToListAsync();

            return savedCars;
        }
    }
}
