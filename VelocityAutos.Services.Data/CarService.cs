using Microsoft.EntityFrameworkCore;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.ViewModels.Car;
using VelocityAutos.Data.Models;
using VelocityAutos.Web.Infrastructure.Common;
using VelocityAutos.Services.Data.Models.Car;
using VelocityAutos.Web.ViewModels.Car.Enums;

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

        public async Task<AllCarsFilteredAndPaged> GetAllCarsAsync(AllCarsQueryModel queryModel)
        {
            IQueryable<Car> carsQuery = repository.AllAsReadOnly<Car>()
                .Where(c => c.Post.IsActive == true)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                carsQuery = carsQuery
                    .Where(c => c.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.FuelType))
            {
                carsQuery = carsQuery
                    .Where(c => c.FuelType.Name == queryModel.FuelType);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.TransmissionType))
            {
                carsQuery = carsQuery
                    .Where(c => c.TransmissionType.Name == queryModel.TransmissionType);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchTerm))
            {
                string wildCard = $"%{queryModel.SearchTerm.ToLower()}%";

                carsQuery = carsQuery
                    .Where(c => EF.Functions.Like(c.Make, wildCard) ||
                                EF.Functions.Like(c.Model, wildCard) ||
                                EF.Functions.Like(c.Description, wildCard));
            }

            carsQuery = queryModel.CarSorting switch
            {
                CarSorting.Newest => carsQuery.OrderByDescending(c => c.Post.CreatedOn),
                CarSorting.Oldest => carsQuery.OrderBy(c => c.Post.CreatedOn),
                CarSorting.PriceAscending => carsQuery.OrderBy(c => c.Price),
                CarSorting.PriceDescending => carsQuery.OrderByDescending(c => c.Price),
                CarSorting.YearAscending => carsQuery.OrderBy(c => c.Year),
                CarSorting.YearDescending => carsQuery.OrderByDescending(c => c.Year),
                _ => carsQuery.OrderBy(c => c.Id)
                .OrderBy(c => c.Post.CreatedOn)
            };

            IEnumerable<CarAllViewModel> allCars = await carsQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.CarsPerPage)
                .Take(queryModel.CarsPerPage)
                .Select(c => new CarAllViewModel
                {
                    Id = c.Id.ToString(),
                    Make = c.Make,
                    Model = c.Model,
                    Price = c.Price,
                    Month = c.Month,
                    Year = c.Year,
                    Mileage = c.Mileage,
                    HorsePower = c.HorsePower,
                    Description = c.Description,
                    LocationCity = c.LocationCity,
                    LocationCountry = c.LocationCountry,
                    CategoryName = c.Category.Name,
                    FuelTypeName = c.FuelType.Name,
                    TransmissionTypeName = c.TransmissionType.Name
                })
                .ToArrayAsync();

            int totalCars = await carsQuery.CountAsync();

            return new AllCarsFilteredAndPaged
            {
                TotalCarsCount = totalCars,
                Cars = allCars
            };
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
                    Description = p.Car.Description,
                    LocationCity = p.Car.LocationCity,
                    LocationCountry = p.Car.LocationCountry,
                    CategoryName = p.Car.Category.Name,
                    FuelTypeName = p.Car.FuelType.Name,
                    TransmissionTypeName = p.Car.TransmissionType.Name
                })
                .ToListAsync();

            return ownedCars;
        }

        public async Task<string> SaveCarAsync(string carId, string userId)
        {
            string returnMessage = string.Empty;

            var savedCar = await repository.All<UserCar>()
                .FirstOrDefaultAsync(uc => uc.UserId.ToString() == userId && uc.CarId.ToString() == carId);

            var user = await repository.All<ApplicationUser>()
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            var car = await repository.All<Car>()
                .Include(c => c.Post)
                .Where(c => c.Id.ToString() == carId)
                .FirstOrDefaultAsync();

            if (savedCar == null)
            {
                if (user != null && car != null)
                {
                    if (car.Post.SellerId == user.Id)
                    {
                        returnMessage = "Owned";
                        return returnMessage;
                    }

                    var newSavedCar = new UserCar
                    {
                        UserId = Guid.Parse(userId),
                        CarId = Guid.Parse(carId)
                    };

                    await repository.AddAsync(newSavedCar);
                    await repository.SaveChangesAsync();
                    
                    returnMessage = "Saved";
                    return returnMessage;
                }
                else
                {
                    returnMessage = "Not found";
                    return returnMessage;
                }
            }
            else
            {
                returnMessage = "Already saved";
                return returnMessage;
            }
        }

        public async Task<IEnumerable<CarAllViewModel>> GetSavedCarsAsync(string userId)
        {
            var savedCars = await repository.AllAsReadOnly<UserCar>()
               .Where(uc => uc.UserId.ToString() == userId && uc.Car.Post.IsActive == true)
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
                   Description = uc.Car.Description,
                   LocationCity = uc.Car.LocationCity,
                   LocationCountry = uc.Car.LocationCountry,
                   CategoryName = uc.Car.Category.Name,
                   FuelTypeName = uc.Car.FuelType.Name,
                   TransmissionTypeName = uc.Car.TransmissionType.Name
               })
               .ToListAsync();

            return savedCars;
        }

        public async Task<bool> RemoveFromSavedAsync(string carId, string userId)
        {
            var savedCar = await repository.All<UserCar>()
                .FirstOrDefaultAsync(uc => uc.UserId.ToString() == userId && uc.CarId.ToString() == carId);

            if (savedCar != null)
            {
                await repository.RemoveAsync(savedCar);
                await repository.SaveChangesAsync();

                return true;
            }

            return false;
        }

		public async Task<bool> IsSaved(string carId, string userId)
        {
            var savedCar = await repository.AllAsReadOnly<UserCar>()
                .FirstOrDefaultAsync(uc => uc.UserId.ToString() == userId && uc.CarId.ToString() == carId);

            if (savedCar != null)
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<AdminCarAllViewModel>> AdminGetAllCarsAsync()
        {
            var cars = await repository.AllAsReadOnly<Post>()
            .Select(p => new AdminCarAllViewModel
            {
                PostId = p.Id.ToString(),
                CarId = p.Car.Id.ToString(),
                Make = p.Car.Make,
                Model = p.Car.Model,
                Price = p.Car.Price,
                HorsePower = p.Car.HorsePower,
                Mileage = p.Car.Mileage,
                Month = p.Car.Month,
                Year = p.Car.Year,
                IsActive = p.IsActive,
                SellerFullName = p.Seller.FirstName + " " + p.Seller.LastName,
                SellerPhoneNumber = p.Seller.PhoneNumber,
                SellerEmail = p.Seller.Email
            })
            .ToListAsync();

            return cars;
        }
    }
}
