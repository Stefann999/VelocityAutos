using Microsoft.EntityFrameworkCore;
using VelocityAutos.Data;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Common;

namespace VelocityAutos.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private VelocityAutosDbContext dbContext;
        IEnumerable<ApplicationUser> users;


        private IRepository repository;
        private IUserService userService;

        // Users
        private ApplicationUser user1;
        private ApplicationUser user2;



        [SetUp]
        public void TestInitialize()
        {
            // Users
            user1 = new ApplicationUser
            {
                Id = Guid.Parse("66543F29-BAFC-4680-8028-5C4B7E444CCB"),
                FirstName = "Ivan",
                LastName = "Stoilov",
                PhoneNumber = "0888888888",
                Email = "ivancars1@cars.com"
            };

            user2 = new ApplicationUser
            {
                Id = Guid.Parse("66543F29-BAFC-4680-8028-5C4B7E444CCC"),
                FirstName = "Dimitur",
                LastName = "Vasilev",
                PhoneNumber = "0999999999",
                Email = "dimitur122@cars.com"
            };

            // Collection
            users = new List<ApplicationUser>()
            {
                user1, user2
            };

            // DbContext
            var options = new DbContextOptionsBuilder<VelocityAutosDbContext>()
                 .UseInMemoryDatabase(databaseName: "VelocityAutosInMemoryDb")
                 .Options;


            dbContext = new VelocityAutosDbContext(options);

            dbContext.AddRange(users);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);

            userService = new UserService(repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task GetFullNameByEmailAddressSuccessfully()
        {
            var result = await userService.GetFullNameByEmailAddressAsync("dimitur122@cars.com");

            Assert.AreEqual(result, "Dimitur Vasilev");
        }

        [Test]
        public async Task GetFullNameByEmailAddressReturnsEmptyString()
        {
            var result = await userService.GetFullNameByEmailAddressAsync("asd");

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public async Task GetPhoneNumberByEmailAddressSuccessfully()
        {
            var result = await userService.GetPhoneNumberByEmailAddressAsync("dimitur122@cars.com");

            Assert.AreEqual(result, "0999999999");
        }

        [Test]
        public async Task GetPhoneNumberByEmailAddressReturnsEmptyString()
        {
            var result = await userService.GetPhoneNumberByEmailAddressAsync("asd");

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public async Task GetFullNameByIdSuccessfully()
        {
            var result = await userService.GetFullNameByIdAsync("66543F29-BAFC-4680-8028-5C4B7E444CCC".ToLower());

            Assert.AreEqual(result, "Dimitur Vasilev");
        }

        [Test]
        public async Task GetFullNameByIdReturnsEmptyString()
        {
            var result = await userService.GetFullNameByIdAsync("asd");

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public async Task GetAllSuccessfully()
        {
            var result = await userService.AllAsync();

            var users = result.ToList();

            Assert.AreEqual(result.Count(), 2);
            Assert.AreEqual(users[0].FullName, "Ivan Stoilov");
            Assert.AreEqual(users[1].FullName, "Dimitur Vasilev");
        }
    }
}