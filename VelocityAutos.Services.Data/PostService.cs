using Microsoft.EntityFrameworkCore;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Common;
using VelocityAutos.Web.ViewModels.Car;
using VelocityAutos.Web.ViewModels.Post;

namespace VelocityAutos.Services.Data
{
    public class PostService : IPostService
    {
        private readonly IRepository repository;
        private readonly IUserService userService;

        public PostService(IRepository repository, IUserService userService)
        {
            this.repository = repository;
            this.userService = userService;
        }

        public async Task CreateAsync(string carId, string currUserId, string emailAddress)
        {
            string fullName = await userService.GetFullNameByEmailAddressAsync(emailAddress);
            string phoneNumber = await userService.GetPhoneNumberByEmailAddressAsync(emailAddress);

            string[] names = fullName.Split(" ").ToArray();

            var post = new Post
            {
                CarId = Guid.Parse(carId),
                SellerFirstName = names[0],
                SellerLastName = names[1],
                SellerEmailAddress = emailAddress,
                SellerPhoneNumber = phoneNumber,
                SellerId = Guid.Parse(currUserId),
                CreatedOn = DateTime.Now,
                UpdatedOn = null,
                DeletedOn = null,
                IsActive = true,
            };

            await repository.AddAsync(post);
            await repository.SaveChangesAsync();
        }

        public async Task<PostDetailsViewModel> GetPostForDetailsByIdAsync(string carId)
        {
            var post = await repository.AllAsReadOnly<Post>()
                .Where(p => p.Car.Id.ToString() == carId)
                .Select(p => new PostDetailsViewModel()
                {
                    CreatedOn = p.CreatedOn,
                    DeletedOn = p.DeletedOn,
                    UpdatedOn = p.UpdatedOn,
                    SellerName = p.SellerFirstName + " " + p.SellerLastName,
                    SellerPhoneNumber = p.SellerPhoneNumber,
                    SellerEmailAddress = p.SellerEmailAddress,
                    IsActive = p.IsActive,
                    SellerId = p.SellerId.ToString(),
                })
                .FirstOrDefaultAsync();

            return post;
        }

        public async Task UpdateAsync(string postId)
        {
            var post = await repository.All<Post>()
                .FirstOrDefaultAsync(p => p.Id.ToString() == postId.ToLower());

            if (post != null)
            {
                post.UpdatedOn = DateTime.Now;
            }
            else
            {
                throw new NullReferenceException("Post not found");
            }

            await repository.SaveChangesAsync();
        }

        public async Task<bool> IsUserPostOwnerByIdAsync(string carId, string userId)
        {
            Car? car = await repository.AllAsReadOnly<Car>()
                .Include(c => c.Post)
                .FirstOrDefaultAsync(c => c.Id.ToString() == carId);

            if (car == null)
            {
                return false;
            }

            return car.Post.SellerId.ToString() == userId;
        }

        public async Task<CarDeleteViewModel> GetPostForDeleteAsync(string carId)
        {
            var car = await repository.AllAsReadOnly<Car>()
                .Where(c => c.Id.ToString() == carId)
                .Select(c => new CarDeleteViewModel()
                {
                    Id = c.Id.ToString(),
                    Make = c.Make,
                    Model = c.Model,
                    Price = c.Price,
                    Month = c.Month,
                    Year = c.Year,
                    SellerId = c.Post.SellerId.ToString(),
                })
                .FirstOrDefaultAsync();

            return car;
        }

        public async Task DeleteAsync(string carId)
        {
            var post = await repository.All<Post>()
                .FirstOrDefaultAsync(p => p.Car.Id.ToString() == carId);

            post!.DeletedOn = DateTime.Now;
            post.IsActive = false;

            await repository.SaveChangesAsync();
        }

        public async Task ActivateAsync(string carId)
        {
            var post = await repository.All<Post>()
                .FirstOrDefaultAsync(p => p.Car.Id.ToString() == carId);

            post!.DeletedOn = null;
            post.UpdatedOn = DateTime.Now;
            post.IsActive = true;

            await repository.SaveChangesAsync();
        }
    }
}
