using Microsoft.EntityFrameworkCore;
using Moq;
using VelocityAutos.Data;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Common;

namespace VelocityAutos.Tests
{
    [TestFixture]
    public class PostServiceTests
    {
        private VelocityAutosDbContext dbContext;
        private IEnumerable<ApplicationUser> users;
        private IEnumerable<Car> cars;
        private IEnumerable<Post> posts;

        private IRepository repository;
        private IPostService postService;

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
                Description = "The Toyota Corolla is a compact post that is known for its reliability, fuel efficiency, and affordability.",
                LocationCity = "Sofia",
                LocationCountry = "Bulgaria",
                CategoryId = 1
            };

            // Post
            gtPost = new Post
            {
                Id = Guid.Parse("8657566a-d31b-4af4-8034-bedb74d928c3"),
                CreatedOn = DateTime.Parse("2024-04-13 21:12:20.5771612"),
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
                IsActive = false,
                SellerId = Guid.Parse("ED670787-A2D5-45E9-A069-83DCD8E84E30"),
                CarId = Guid.Parse("D1D3D1D3-1D3D-1D3D-1D3D-1D3D1D3D1D3D"),
                SellerFirstName = "Dimitur",
                SellerLastName = "Vasilev",
                SellerPhoneNumber = "0813819279",
                SellerEmailAddress = "dimitur122@cars.com"
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


            // DbContext
            var options = new DbContextOptionsBuilder<VelocityAutosDbContext>()
                 .UseInMemoryDatabase(databaseName: "VelocityAutosInMemoryDb")
                 .Options;


            dbContext = new VelocityAutosDbContext(options);

            dbContext.AddRange(users);
            dbContext.AddRange(cars);
            dbContext.AddRange(posts);
            dbContext.SaveChanges();

            repository = new Repository(dbContext);

            var mockIUserService = new Mock<IUserService>();

            mockIUserService
                .Setup(p => p.GetFullNameByEmailAddressAsync("ivancars1@cars.com"))
                .ReturnsAsync("Ivan Stoilov");

            mockIUserService
                .Setup(p => p.GetPhoneNumberByEmailAddressAsync("ivancars1@cars.com"))
                .ReturnsAsync("0888888888");

            postService = new PostService(repository, mockIUserService.Object);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task PostIsCreatedProperly()
        {
            var post = new Post()
            {
                Id = Guid.Parse("f3779b6b-b218-4262-b2b3-ae0a2ea2fa41"),
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
                SellerId = Guid.Parse("66543F29-BAFC-4680-8028-5C4B7E444CCB"),
                CarId = Guid.Parse("4D4D4D4D-4D4D-4D4D-4D4D-4D4D4D4D4D4D"),
                SellerFirstName = "Ivan",
                SellerLastName = "Stoilov",
                SellerPhoneNumber = "0867219923",
                SellerEmailAddress = "ivancars1@cars.com",
                Car = gt63
            };

            await postService.CreateAsync(post.CarId.ToString().ToLower(), post.SellerId.ToString().ToLower(), post.SellerEmailAddress);

            var createdPost = await postService.GetPostForDetailsByIdAsync(post.CarId.ToString());

            Assert.IsTrue(createdPost != null);
        }

        [Test]
        public async Task GetPostDetailsSuccessfully()
        {
            string carId = "9219E817-E86A-4EA0-807F-976D8195D93A";

            var post = await postService.GetPostForDetailsByIdAsync(carId.ToLower());

            Assert.IsNotNull(post);
            Assert.AreEqual(DateTime.Parse("2024-04-13 21:12:20.5771612"), post.CreatedOn);
            Assert.IsNull(post.UpdatedOn);
            Assert.IsNull(post.DeletedOn);
            Assert.AreEqual("Ivan Stoilov", post.SellerName);
            Assert.AreEqual("0867219923", post.SellerPhoneNumber);
            Assert.AreEqual("ivancars1@cars.com", post.SellerEmailAddress);
            Assert.AreEqual(true, post.IsActive);
            Assert.AreEqual("66543F29-BAFC-4680-8028-5C4B7E444CCB".ToLower(), post.SellerId);
        }

        [Test]
        public async Task PostEditedSuccessfully()
        {
            await postService.UpdateAsync("8657566a-d31b-4af4-8034-bedb74d928c3");

            var updatedPost = await postService.GetPostForDetailsByIdAsync("9219E817-E86A-4EA0-807F-976D8195D93A".ToLower());

            Assert.IsNotNull(updatedPost.UpdatedOn);
        }


        [Test]
        public async Task IsUserPostOwnerByIdAsyncReturnsTrue()
        {
            bool result = await postService.IsUserPostOwnerByIdAsync("9219E817-E86A-4EA0-807F-976D8195D93A".ToLower(), "66543F29-BAFC-4680-8028-5C4B7E444CCB".ToLower());

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsUserPostOwnerByIdAsyncReturnsFalse()
        {
            bool result = await postService.IsUserPostOwnerByIdAsync("asd".ToLower(), "66543F29-BAFC-4680-8028-5C4B7E444CCB".ToLower());

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetPostForDeleteSuccessfully()
        {
            var result = await postService.GetPostForDeleteAsync("9219E817-E86A-4EA0-807F-976D8195D93A".ToLower());

            Assert.AreEqual("Mercedes", result.Make);
        }

        [Test]
        public async Task DeletePostSuccessfully()
        {
            await postService.DeleteAsync("9219E817-E86A-4EA0-807F-976D8195D93A".ToLower());

            var post = await postService.GetPostForDetailsByIdAsync("9219E817-E86A-4EA0-807F-976D8195D93A".ToLower());
            
            Assert.IsNotNull(post.DeletedOn);
            Assert.IsFalse(post.IsActive);
        }

        [Test]
        public async Task ActivatePostSuccessfully()
        {
            await postService.ActivateAsync("D1D3D1D3-1D3D-1D3D-1D3D-1D3D1D3D1D3D".ToLower());

            var updatedPost = await postService.GetPostForDetailsByIdAsync("D1D3D1D3-1D3D-1D3D-1D3D-1D3D1D3D1D3D".ToLower());

            string dateTimeFormat = "yy/MM/dd HH:ss";

            string updatedOnStr = updatedPost.UpdatedOn != null ? updatedPost.UpdatedOn.Value.ToString(dateTimeFormat) : null;

            Assert.AreEqual(DateTime.Now.ToString(dateTimeFormat), updatedOnStr);
            Assert.IsTrue(updatedPost.IsActive);
        }
    }
}