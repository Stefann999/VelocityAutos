using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using VelocityAutos.Data;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Common;
using VelocityAutos.Web.ViewModels.Car;
using VelocityAutos.Web.ViewModels.Car.Enums;

namespace VelocityAutos.Tests
{
    [TestFixture]
    public class CarServiceTests
    {
        private VelocityAutosDbContext dbContext;
        private IEnumerable<ApplicationUser> users;
        private IEnumerable<Car> cars;
        private IEnumerable<Post> posts;
        private IEnumerable<Category> categories;
        private IEnumerable<FuelType> fuelTypes;
        private IEnumerable<TransmissionType> transmissionTypes;

        private IRepository repository;
        private ICarService carService;

        // User
        private ApplicationUser user1;

        // Cars
        private Car gt63;
        private Car a4;
        private Car m3;
        private Car corolla;

        // Post
        private Post gtPost;
        private Post a4Post;
        private Post m3Post;

        // Categories
        private Category Sedan;
        private Category Coupe;
        private Category Hatchback;

        // FuelTypes
        private FuelType Petrol;
        private FuelType Diesel;
        private FuelType Electric;

        // TransmissionTypes
        private TransmissionType Manual;
        private TransmissionType Automatic;
        private TransmissionType SemiAutomatic;

        // UsersSaved
        private UserCar savedA4;


        [SetUp]
        public void TestInitialize()
        {
            // User
            user1 = new ApplicationUser
            {
                Id = Guid.Parse("66543F29-BAFC-4680-8028-5C4B7E444CCB"),
                FirstName = "Ivan",
                LastName = "Stoilov",
                PhoneNumber = "0888888888",
                Email = "ivancars1@cars.com"
            };

            // Cars
            gt63 = new Car
            {
                Id = Guid.Parse("9219E817-E86A-4EA0-807F-976D8195D93A"),
                Make = "Mercedes",
                Model = "Gt63 S 4-door",
                Price = 200000,
                Month = 1,
                Year = 2023,
                Mileage = 5000,
                HorsePower = 639,
                FuelTypeId = 1,
                FuelConsumption = 15,
                TransmissionTypeId = 2,
                Color = "White",
                Description = "The Mercedes-AMG GT 63 S is a high-performance luxury four-door coupe that offers a combination of striking design, advanced technology, and powerful performance.",
                LocationCity = "Sofia",
                LocationCountry = "Bulgaria",
                CategoryId = 2
            };

            a4 = new Car
            {
                Id = Guid.Parse("74576F3E-A409-46E4-A8FF-9C93EB409CBA"),
                Make = "Audi",
                Model = "A4",
                Price = 50000,
                Month = 3,
                Year = 2017,
                Mileage = 10000,
                HorsePower = 150,
                FuelTypeId = 1,
                FuelConsumption = 6.5,
                TransmissionTypeId = 1,
                Color = "Black",
                Description = "The 2019 Audi A4 is a luxury compact sedan that combines sophisticated design, advanced technology, and impressive performance.",
                LocationCity = "Sofia",
                LocationCountry = "Bulgaria",
                CategoryId = 3
            };

            m3 = new Car
            {
                Id = Guid.Parse("D1D3D1D3-1D3D-1D3D-1D3D-1D3D1D3D1D3D"),
                Make = "BMW",
                Model = "M3",
                Price = 70000,
                Month = 2,
                Year = 2020,
                Mileage = 20000,
                HorsePower = 500,
                FuelTypeId = 2,
                FuelConsumption = 10,
                TransmissionTypeId = 2,
                Color = "Blue",
                Description = "The BMW M3 is a high-performance luxury sports sedan that offers a combination of striking design, advanced technology, and powerful performance.",
                LocationCity = "Sofia",
                LocationCountry = "Bulgaria",
                CategoryId = 1
            };

            corolla = new Car
            {
                Id = Guid.Parse("4D4D4D4D-4D4D-4D4D-4D4D-4D4D4D4D4D4D"),
                Make = "Toyota",
                Model = "Corolla",
                Price = 20000,
                Month = 1,
                Year = 2019,
                Mileage = 10000,
                HorsePower = 100,
                FuelTypeId = 2,
                FuelConsumption = 6.5,
                TransmissionTypeId = 1,
                Color = "Red",
                Description = "The Toyota Corolla is a compact car that is known for its reliability, fuel efficiency, and affordability.",
                LocationCity = "Sofia",
                LocationCountry = "Bulgaria",
                CategoryId = 1
            };

            // Post
            gtPost = new Post
            {
                Id = Guid.Parse("8657566a-d31b-4af4-8034-bedb74d928c3"),
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
                SellerId = Guid.Parse("66543F29-BAFC-4680-8028-5C4B7E444CCB"),
                CarId = Guid.Parse("9219E817-E86A-4EA0-807F-976D8195D93A"),
                SellerFirstName = "Ivan",
                SellerLastName = "Stoilov",
                SellerPhoneNumber = "0867219923",
                SellerEmailAddress = "ivancars1@cars.com",
                Car = gt63,
            };

            a4Post = new Post()
            {
                Id = Guid.Parse("3E5E72C8-AE7D-4C68-AD81-1BDC9C9EAAD9"),
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
                SellerId = Guid.Parse("ED670787-A2D5-45E9-A069-83DCD8E84E30"),
                CarId = Guid.Parse("74576F3E-A409-46E4-A8FF-9C93EB409CBA"),
                SellerFirstName = "Dimitur",
                SellerLastName = "Vasilev",
                SellerPhoneNumber = "0813819279",
                SellerEmailAddress = "dimitur122@cars.com",
                Car = a4
            };

            m3Post = new Post()
            {
                Id = Guid.Parse("68a3b40c-34b6-41dc-a35b-45e0bd1e00fe"),
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
                SellerId = Guid.Parse("ED670787-A2D5-45E9-A069-83DCD8E84E30"),
                CarId = Guid.Parse("D1D3D1D3-1D3D-1D3D-1D3D-1D3D1D3D1D3D"),
                SellerFirstName = "Dimitur",
                SellerLastName = "Vasilev",
                SellerPhoneNumber = "0813819279",
                SellerEmailAddress = "dimitur122@cars.com"
            };

            // Categories
            Sedan = new Category
            {
                Id = 1,
                Name = "Sedan"
            };

            Coupe = new Category
            {
                Id = 2,
                Name = "Coupe"
            };

            Hatchback = new Category
            {
                Id = 3,
                Name = "Hatchback"
            };

            // FuelTypes
            Petrol = new FuelType
            {
                Id = 1,
                Name = "Petrol"
            };

            Diesel = new FuelType
            {
                Id = 2,
                Name = "Diesel"
            };

            Electric = new FuelType
            {
                Id = 3,
                Name = "Electric"
            };

            // TransmissionTypes
            Manual = new TransmissionType
            {
                Id = 1,
                Name = "Manual"
            };

            Automatic = new TransmissionType
            {
                Id = 2,
                Name = "Automatic"
            };

            SemiAutomatic = new TransmissionType
            {
                Id = 3,
                Name = "Semi-Automatic"
            };

            // UserCar
            savedA4 = new UserCar
            {
                CarId = Guid.Parse("74576F3E-A409-46E4-A8FF-9C93EB409CBA".ToLower()),
                UserId = Guid.Parse("66543F29-BAFC-4680-8028-5C4B7E444CCB".ToLower())
            };

            users = new List<ApplicationUser>()
            {
                user1
            };

            cars = new List<Car>()
             {
                 gt63, a4, m3, corolla
             };

            posts = new List<Post>()
            {
                gtPost, a4Post, m3Post
            };

            categories = new List<Category>()
            {
                Sedan, Coupe, Hatchback
            };

            fuelTypes = new List<FuelType>()
            {
                Petrol, Diesel, Electric
            };

            transmissionTypes = new List<TransmissionType>()
            {
                Manual, Automatic, SemiAutomatic
            };


            // DbContext
            var options = new DbContextOptionsBuilder<VelocityAutosDbContext>()
                 .UseInMemoryDatabase(databaseName: "VelocityAutosInMemoryDb")
                 .Options;


            dbContext = new VelocityAutosDbContext(options);

            dbContext.AddRange(users);
            dbContext.AddRange(cars);
            dbContext.AddRange(posts);
            dbContext.AddRange(savedA4);
            dbContext.AddRange(categories);
            dbContext.AddRange(fuelTypes);
            dbContext.AddRange(transmissionTypes);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);

            var mockIDropboxService = new Mock<IDropboxService>();
            IEnumerable<IFormFile> files = new List<IFormFile>();

            mockIDropboxService
                .Setup(p => p.UploadImagesAsync(files, "9219E817-E86A-4EA0-807F-976D8195D93A"))
                .ReturnsAsync("Car_9219E817-E86A-4EA0-807F-976D8195D93A");

            carService = new CarService(mockIDropboxService.Object, repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public void CarIsCreatedProperly()
        {
            var car = new CarFormModel()
            {
                Make = "Toyota",
                Model = "Corolla",
                Price = 20000,
                Month = 1,
                Year = 2019,
                Mileage = 10000,
                HorsePower = 100,
                FuelTypeId = 1,
                FuelConsumption = 6.5,
                TransmissionTypeId = 2,
                Color = "Red",
                Description = "The Toyota Corolla is a compact car that is known for its reliability, fuel efficiency, and affordability.",
                LocationCity = "Sofia",
                LocationCountry = "Bulgaria",
                CategoryId = 1
            };

            var id = carService.CreateAsync(car);

            Assert.IsTrue(id != null);
        }

        [Test]
        public async Task AllAsync_SortByNewest()
        {
            var queryModel = new AllCarsQueryModel()
            {
                CarSorting = CarSorting.Newest
            };

            var carsNewest = await carService.GetAllCarsAsync(queryModel);

            var carMakes = new List<string>()
            {
                carsNewest.Cars.First().Make,
                carsNewest.Cars.Skip(1).First().Make,
                carsNewest.Cars.Skip(2).First().Make,
                carsNewest.Cars.Last().Make
            };

            Assert.IsNotNull(carsNewest.Cars);
            Assert.AreEqual(4, carsNewest.Cars.Count());
            Assert.AreEqual(new List<string>() { "BMW", "Audi", "Mercedes", "Toyota" }, carMakes);
        }

        [Test]
        public async Task AllAsync_SortByOldest()
        {
            var queryModel = new AllCarsQueryModel()
            {
                CarSorting = CarSorting.Oldest
            };

            var carsOldest = await carService.GetAllCarsAsync(queryModel);

            var carMakes = new List<string>()
            {
                carsOldest.Cars.First().Make,
                carsOldest.Cars.Skip(1).First().Make,
                carsOldest.Cars.Skip(2).First().Make,
                carsOldest.Cars.Last().Make
            };

            Assert.IsNotNull(carsOldest.Cars);
            Assert.AreEqual(4, carsOldest.Cars.Count());
            Assert.AreEqual(new List<string>() { "Toyota", "Mercedes", "Audi", "BMW" }, carMakes);
        }

        [Test]
        public async Task AllAsync_SortByPriceAscending()
        {
            var queryModel = new AllCarsQueryModel()
            {
                CarSorting = CarSorting.PriceAscending
            };

            var carsPriceAscending = await carService.GetAllCarsAsync(queryModel);

            var carMakes = new List<string>()
            {
                carsPriceAscending.Cars.First().Make,
                carsPriceAscending.Cars.Skip(1).First().Make,
                carsPriceAscending.Cars.Skip(2).First().Make,
                carsPriceAscending.Cars.Last().Make
            };

            Assert.IsNotNull(carsPriceAscending.Cars);
            Assert.AreEqual(4, carsPriceAscending.Cars.Count());
            Assert.AreEqual(new List<string>() { "Toyota", "Audi", "BMW", "Mercedes"}, carMakes);
        }

        [Test]
        public async Task AllAsync_SortByPriceDescending()
        {
            var queryModel = new AllCarsQueryModel()
            {
                CarSorting = CarSorting.PriceDescending
            };

            var carsPriceDescending = await carService.GetAllCarsAsync(queryModel);

            var carMakes = new List<string>()
            {
                carsPriceDescending.Cars.First().Make,
                carsPriceDescending.Cars.Skip(1).First().Make,
                carsPriceDescending.Cars.Skip(2).First().Make,
                carsPriceDescending.Cars.Last().Make
            };

            Assert.IsNotNull(carsPriceDescending.Cars);
            Assert.AreEqual(4, carsPriceDescending.Cars.Count());
            Assert.AreEqual(new List<string>() {"Mercedes", "BMW", "Audi", "Toyota"}, carMakes);
        }

        [Test]
        public async Task AllAsync_SortByYearAscending()
        {
            var queryModel = new AllCarsQueryModel()
            {
                CarSorting = CarSorting.YearAscending
            };

            var carsYearAscending = await carService.GetAllCarsAsync(queryModel);

            var carMakes = new List<string>()
            {
                carsYearAscending.Cars.First().Make,
                carsYearAscending.Cars.Skip(1).First().Make,
                carsYearAscending.Cars.Skip(2).First().Make,
                carsYearAscending.Cars.Last().Make
            };

            Assert.IsNotNull(carsYearAscending.Cars);
            Assert.AreEqual(4, carsYearAscending.Cars.Count());
            Assert.AreEqual(new List<string>() { "Audi", "Toyota", "BMW", "Mercedes" }, carMakes);
        }

        [Test]
        public async Task AllAsync_SortByYearDescending()
        {
            var queryModel = new AllCarsQueryModel()
            {
                CarSorting = CarSorting.YearDescending
            };

            var carsYearDescending = await carService.GetAllCarsAsync(queryModel);

            var carMakes = new List<string>()
            {
                carsYearDescending.Cars.First().Make,
                carsYearDescending.Cars.Skip(1).First().Make,
                carsYearDescending.Cars.Skip(2).First().Make,
                carsYearDescending.Cars.Last().Make
            };

            Assert.IsNotNull(carsYearDescending.Cars);
            Assert.AreEqual(4, carsYearDescending.Cars.Count());
            Assert.AreEqual(new List<string>() { "Mercedes", "BMW", "Toyota", "Audi" }, carMakes);
        }

        [Test]
        public async Task AllAsync_SearchTerm()
        {
            var queryModel = new AllCarsQueryModel()
            {
                SearchTerm = "compact"
            };

            var carsSearchTerm = await carService.GetAllCarsAsync(queryModel);

            var carMakes = new List<string>()
            {
                carsSearchTerm.Cars.First().Make,
                carsSearchTerm.Cars.Last().Make
            };

            Assert.IsNotNull(carsSearchTerm.Cars);
            Assert.AreEqual(2, carsSearchTerm.Cars.Count());
            Assert.AreEqual(new List<string>() { "Audi", "Toyota" }, carMakes);
        }

        [Test]
        public async Task AllAsync_Category()
        {
            var queryModel = new AllCarsQueryModel()
            {
                Category = "Sedan"
            };

            var carsCategory = await carService.GetAllCarsAsync(queryModel);

            var carMakes = new List<string>()
            {
                carsCategory.Cars.First().Make,
                carsCategory.Cars.Last().Make
            };

            Assert.IsNotNull(carsCategory.Cars);
            Assert.AreEqual(2, carsCategory.Cars.Count());
            Assert.AreEqual(new List<string>() { "BMW", "Toyota" }, carMakes);
        }

        [Test]
        public async Task AllAsync_FuelType()
        {
            var queryModel = new AllCarsQueryModel()
            {
                FuelType = "Diesel"
            };

            var carsCategory = await carService.GetAllCarsAsync(queryModel);

            var carMakes = new List<string>()
            {
                carsCategory.Cars.First().Make,
                carsCategory.Cars.Last().Make
            };

            Assert.IsNotNull(carsCategory.Cars);
            Assert.AreEqual(2, carsCategory.Cars.Count());
            Assert.AreEqual(new List<string>() { "BMW", "Toyota" }, carMakes);
        }

        [Test]
        public async Task AllAsync_TransmissionType()
        {
            var queryModel = new AllCarsQueryModel()
            {
                TransmissionType = "Manual"
            };

            var carsCategory = await carService.GetAllCarsAsync(queryModel);

            var carMakes = new List<string>()
            {
                carsCategory.Cars.First().Make,
                carsCategory.Cars.Last().Make
            };

            Assert.IsNotNull(carsCategory.Cars);
            Assert.AreEqual(2, carsCategory.Cars.Count());
            Assert.AreEqual(new List<string>() { "Audi", "Toyota" }, carMakes);
        }

        [Test]
        public async Task GetCarDetailsSuccessfully()
        {
            string carId = "9219E817-E86A-4EA0-807F-976D8195D93A";

            var car = await carService.GetCarDetailsAsync(carId.ToLower());

            Assert.IsNotNull(car);
            Assert.AreEqual("Mercedes", car.Make);
            Assert.AreEqual("Gt63 S 4-door", car.Model);
            Assert.AreEqual(200000, car.Price);
            Assert.AreEqual(1, car.Month);
            Assert.AreEqual(2023, car.Year);
            Assert.AreEqual(5000, car.Mileage);
            Assert.AreEqual(639, car.HorsePower);
            Assert.AreEqual("Petrol", car.FuelType);
            Assert.AreEqual(15, car.FuelConsumption);
            Assert.AreEqual("Automatic", car.TransmissionType);
            Assert.AreEqual("White", car.Color);
            Assert.AreEqual("The Mercedes-AMG GT 63 S is a high-performance luxury four-door coupe that offers a combination of striking design, advanced technology, and powerful performance.", car.Description);
            Assert.AreEqual("Sofia", car.LocationCity);
            Assert.AreEqual("Bulgaria", car.LocationCountry);
            Assert.AreEqual("Coupe", car.Category);
        }

        [Test]
        public async Task GetCarForEditSuccessfully()
        {
            string carId = "9219E817-E86A-4EA0-807F-976D8195D93A";

            var car = await carService.GetCarEditAsync(carId.ToLower());

            Assert.IsNotNull(car);
            Assert.AreEqual("Mercedes", car.Make);
            Assert.AreEqual("Gt63 S 4-door", car.Model);
            Assert.AreEqual(200000, car.Price);
            Assert.AreEqual(1, car.Month);
            Assert.AreEqual(2023, car.Year);
            Assert.AreEqual(5000, car.Mileage);
            Assert.AreEqual(639, car.HorsePower);
            Assert.AreEqual(1, car.FuelTypeId);
            Assert.AreEqual(15, car.FuelConsumption);
            Assert.AreEqual(2, car.TransmissionTypeId);
            Assert.AreEqual("White", car.Color);
            Assert.AreEqual("The Mercedes-AMG GT 63 S is a high-performance luxury four-door coupe that offers a combination of striking design, advanced technology, and powerful performance.", car.Description);
            Assert.AreEqual("Sofia", car.LocationCity);
            Assert.AreEqual("Bulgaria", car.LocationCountry);
            Assert.AreEqual(2, car.CategoryId);
        }

        [Test]
        public async Task CarEditedSuccessfully()
        {
            string carId = "9219E817-E86A-4EA0-807F-976D8195D93A";

            var formModel = new CarFormModel()
            {
                Make = "Mercedes1",
                Model = "Gt63 S 4-door",
                Price = 200000,
                Month = 1,
                Year = 2023,
                Mileage = 5000,
                HorsePower = 639,
                FuelTypeId = 1,
                FuelConsumption = 15,
                TransmissionTypeId = 2,
                Color = "White",
                Description = "The Mercedes-AMG GT 63 S is a high-performance luxury four-door coupe that offers a combination of striking design, advanced technology, and powerful performance.",
                LocationCity = "Sofia",
                LocationCountry = "Bulgaria",
                CategoryId = 2
            };

            await carService.UpdateAsync(formModel, carId.ToLower());

            var updatedCar = await carService.GetCarDetailsAsync(carId.ToLower());

            Assert.AreEqual("Mercedes1", updatedCar.Make);
        }

        [Test]
        public void CarEditThrowsError()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => carService.UpdateAsync(null,"asd"));
        }

        [Test]
        public async Task GetOwnedCarsSuccessfully()
        {
            var ownedCars = await carService.GetOwnedCarsAsync("66543F29-BAFC-4680-8028-5C4B7E444CCB".ToLower());

            var ownedCarMake = ownedCars.First().Make;

            Assert.AreEqual("Mercedes", ownedCarMake);
        }

        [Test]
        public async Task SaveCarReturnsAlreadySaved()
        {
            string result = await carService.SaveCarAsync("74576F3E-A409-46E4-A8FF-9C93EB409CBA".ToLower(), "66543F29-BAFC-4680-8028-5C4B7E444CCB".ToLower());
            Assert.AreEqual("Already saved", result);
        }

        [Test]
        public async Task SaveCarReturnsOwned()
        {
            string result = await carService.SaveCarAsync("9219E817-E86A-4EA0-807F-976D8195D93A".ToLower(), "66543F29-BAFC-4680-8028-5C4B7E444CCB".ToLower());
            Assert.AreEqual("Owned", result);
        }

        [Test]
        public async Task SaveCarReturnsSaved()
        {
            string result = await carService.SaveCarAsync("D1D3D1D3-1D3D-1D3D-1D3D-1D3D1D3D1D3D".ToLower(), "66543F29-BAFC-4680-8028-5C4B7E444CCB".ToLower());
            Assert.AreEqual("Saved", result);
        }

        [Test]
        public async Task SaveCarReturnsNotFound()
        {
            string result = await carService.SaveCarAsync("ASD".ToLower(), "66543F29-BAFC-4680-8028-5C4B7E444CCB".ToLower());
            Assert.AreEqual("Not found", result);
        }

        [Test]
        public async Task GetSavedCarsSuccessfully()
        {
            var savedCars = await carService.GetSavedCarsAsync("66543F29-BAFC-4680-8028-5C4B7E444CCB".ToLower());

            var savedCarMake = savedCars.First().Make;

            Assert.AreEqual("Audi", savedCarMake);
        }

        [Test]
        public async Task RemoveFromSavedReturnsTrue()
        {
            bool result = await carService.RemoveFromSavedAsync("74576F3E-A409-46E4-A8FF-9C93EB409CBA".ToLower(), "66543F29-BAFC-4680-8028-5C4B7E444CCB".ToLower());
            
            Assert.IsTrue(result);
        }

        [Test]
        public async Task RemoveFromSavedReturnsFalse()
        {
            bool result = await carService.RemoveFromSavedAsync("9219E817-E86A-4EA0-807F-976D8195D93A", "0468d5ff-ea08-45ef-ae22-3ab18a6888ec");

            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsSavedReturnsTrue()
        {
            bool result = await carService.IsSaved("74576F3E-A409-46E4-A8FF-9C93EB409CBA".ToLower(), "66543F29-BAFC-4680-8028-5C4B7E444CCB".ToLower());

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsSavedReturnsFalse()
        {
            bool result = await carService.IsSaved("9219E817-E86A-4EA0-807F-976D8195D93A", "0468d5ff-ea08-45ef-ae22-3ab18a6888ec");

            Assert.IsFalse(result);
        }
    }
}