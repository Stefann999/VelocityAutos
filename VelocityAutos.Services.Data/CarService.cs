using Microsoft.EntityFrameworkCore;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Data;
using VelocityAutos.Web.ViewModels.Car;
using VelocityAutos.Data.Models;

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

        public async Task CreateAsync(CarFormModel carFormModel)
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
        }

        public async Task<Car> GetCarAsync(CarFormModel formModel, string userId)
        {
            var car = new Car()
            {
                Make = formModel.Make,
                Model = formModel.Model,
                Price = formModel.Price,
                Month = formModel.Month,
                Year = formModel.Year,
                Mileage = formModel.Mileage,
                HorsePower = formModel.HorsePower,
                FuelTypeId = formModel.FuelTypeId,
                FuelConsumption = formModel.FuelConsumption,
                TransmissionTypeId = formModel.TransmissionTypeId,
                Color = formModel.Color,
                Description = formModel.Description,
                LocationCity = formModel.LocationCity,
                LocationCountry = formModel.LocationCountry,
                CategoryId = formModel.CategoryId
            };

            return car;
        }

        public async Task<CarDetailsViewModel> GetCarAsync(string carId)
        {
            var car = await this.dbContext
                .Cars
                .AsNoTracking()
                .Where(c => c.Id.ToString() == carId)
                .Select(c => new CarDetailsViewModel
                {
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
    }
}
