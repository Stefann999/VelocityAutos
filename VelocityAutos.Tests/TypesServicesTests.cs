using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using VelocityAutos.Data;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Common;
using static Dropbox.Api.Sharing.ListFileMembersIndividualResult;

namespace VelocityAutos.Tests
{
    [TestFixture]
    public class TypesServicesTests
    {
        private VelocityAutosDbContext dbContext;
        private IEnumerable<Category> categories;
        private IEnumerable<FuelType> fuelTypes;
        private IEnumerable<TransmissionType> transmissionTypes;

        private IRepository repository;
        private ICategoryService categoryService;
        private IFuelTypeService fuelTypeService;
        private ITransmissionTypeService transmissionTypeService;

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


        [SetUp]
        public void TestInitialize()
        {
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

            // Collections

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

            dbContext.AddRange(categories);
            dbContext.AddRange(fuelTypes);
            dbContext.AddRange(transmissionTypes);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);

            categoryService = new CategoryService(repository);
            fuelTypeService = new FuelTypeService(repository);
            transmissionTypeService = new TransmissionTypeService(repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task GetAllCategoriesSuccessfuly()
        {
			var result = await categoryService.AllCategoriesAsync();

			var carCategories = new List<string>()
			{
                result.First().Name,
				result.Skip(1).First().Name,
				result.Last().Name
			};

			Assert.IsNotNull(result);
			Assert.AreEqual(3, result.Count());
			Assert.AreEqual(new List<string>() { "Sedan", "Coupe", "Hatchback" }, carCategories);
		}

		[Test]
		public async Task CategoryExistsByIdReturnsTrue()
		{
			bool exists = await categoryService.ExistsByIdAsync(1);

            Assert.IsTrue(exists);
		}

		[Test]
		public async Task CategoryExistsByIdReturnsFalse()
		{
			bool exists = await categoryService.ExistsByIdAsync(11);

			Assert.IsFalse(exists);
        }

        [Test]
        public async Task GetAllCategoriesNamesSuccessfully()
        {
			var result = await categoryService.AllCategoryNamesAsync();

			var carCategories = new List<string>()
            {
				result.First(),
				result.Skip(1).First(),
				result.Last()
			};

		    Assert.IsNotNull(result);
			Assert.AreEqual(3, result.Count());
			Assert.AreEqual(new List<string>() { "Sedan", "Coupe", "Hatchback" }, carCategories);
        }


        [Test]
		public async Task GetAllFuelTypesSuccessfully()
		{
			var result = await fuelTypeService.AllFuelTypesAsync();

			var carFuelTypes = new List<string>()
			{
				result.First().Name,
				result.Skip(1).First().Name,
				result.Last().Name
			};

			Assert.IsNotNull(result);
			Assert.AreEqual(3, result.Count());
			Assert.AreEqual(new List<string>() { "Petrol", "Diesel", "Electric" }, carFuelTypes);
		}

		[Test]
		public async Task FuelTypeExistsByIdReturnsTrue()
		{
			bool exists = await fuelTypeService.ExistsByIdAsync(1);

			Assert.IsTrue(exists);
		}

		[Test]
		public async Task FuelTypeExistsByIdReturnsFalse()
		{
			bool exists = await fuelTypeService.ExistsByIdAsync(11);

			Assert.IsFalse(exists);
		}

		[Test]
		public async Task GetAllFuelTypesNamesSuccessfully()
		{
			var result = await fuelTypeService.AllFuelTypeNamesAsync();

			var carCategories = new List<string>()
			{
				result.First(),
				result.Skip(1).First(),
				result.Last()
			};

			Assert.IsNotNull(result);
			Assert.AreEqual(3, result.Count());
			Assert.AreEqual(new List<string>() { "Petrol", "Diesel", "Electric" }, carCategories);
		}

		[Test]
        public async Task GetAllTransmissionTypesSuccessfully()
        {
            var result = await transmissionTypeService.AllTransmissionTypesAsync();

            var carFuelTypes = new List<string>()
            {
                result.First().Name,
                result.Skip(1).First().Name,
                result.Last().Name
            };

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(new List<string>() { "Manual", "Automatic", "Semi-Automatic" }, carFuelTypes);
        }

		[Test]
		public async Task TransmissionTypeExistsByIdReturnsTrue()
		{
			bool exists = await transmissionTypeService.ExistsByIdAsync(1);

			Assert.IsTrue(exists);
		}

		[Test]
		public async Task TransmissionTypeExistsByIdReturnsFalse()
		{
			bool exists = await transmissionTypeService.ExistsByIdAsync(11);

			Assert.IsFalse(exists);
		}

		[Test]
		public async Task GetAllTransmissiontypesNamesSuccessfully()
		{
			var result = await transmissionTypeService.AllTransmissionTypeNamesAsync();

			var carTransmissionTypes = new List<string>()
			{
				result.First(),
				result.Skip(1).First(),
				result.Last()
			};

			Assert.IsNotNull(result);
			Assert.AreEqual(3, result.Count());
			Assert.AreEqual(new List<string>() { "Manual", "Automatic", "Semi-Automatic" }, carTransmissionTypes);
		}
	}
}