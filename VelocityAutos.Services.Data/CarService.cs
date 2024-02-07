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
        public async Task CreateAsync(CarFormModel carFormModel, string currUserId)
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
                CategoryId = carFormModel.CategoryId,
                OwnerId = Guid.Parse(currUserId)
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
    }
}
