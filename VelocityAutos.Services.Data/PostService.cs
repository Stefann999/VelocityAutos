using AspNetCoreTemplate.Services.Mapping;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VelocityAutos.Data;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Common;
using VelocityAutos.Web.ViewModels.Car;
using VelocityAutos.Web.ViewModels.Post;

namespace VelocityAutos.Services.Data
{
    public class PostService : IPostService
    {
        private readonly VelocityAutosDbContext dbContext;
        private readonly IRepository repository;

        public PostService(VelocityAutosDbContext dbContext, IRepository repository)
        {
            this.dbContext = dbContext;
            this.repository = repository;
        }

        public async Task CreateAsync(PostFormModel postFormModel, Car car, string currUserId)
        {
           var post = new Post
           {
               CarId = car.Id,
               SellerFirstName = postFormModel.FirstName,
               SellerLastName = postFormModel.LastName,
               SellerPhoneNumber = postFormModel.PhoneNumber,
               SellerEmailAddress = postFormModel.EmailAddress,
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
                    SellerEmailAddress = p.SellerEmailAddress
                })
                .FirstOrDefaultAsync();

            return post;
        }

        public async Task<PostFormModel> GetPostForEditByIdAsync(string carId)
        {
            var post = await repository.All<Post>()
               .Where(p => p.Car.Id.ToString() == carId)
               .Select(p => new PostFormModel()
               {
                   Id = p.Id.ToString(),
                   FirstName = p.SellerFirstName,
                   LastName = p.SellerLastName,
                   PhoneNumber = p.SellerPhoneNumber,
                   EmailAddress = p.SellerEmailAddress,
                   SellerId = p.SellerId.ToString()
               })
               .FirstOrDefaultAsync();

            return post;
        }

        public async Task UpdateAsync(PostFormModel postFormModel, string postId)
        {
            var post = await repository.All<Post>()
                .FirstOrDefaultAsync(p => p.Id.ToString() == postId.ToLower());

            if (post != null)
            {
                post.SellerFirstName = postFormModel.FirstName;
                post.SellerLastName = postFormModel.LastName;
                post.SellerPhoneNumber = postFormModel.PhoneNumber;
                post.SellerEmailAddress = postFormModel.EmailAddress;
                post.UpdatedOn = DateTime.Now;
            }
            else
            {
                throw new NullReferenceException("Post not found");
            }

            await repository.SaveChangesAsync();
        }

        public async Task<bool> IsUserPostOwnerById(string carId, string userId)
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

        public async Task<CarDeleteViewModel> GetPostForDelete(string carId)
        {
            var car = await repository.All<Car>()
                .Where(c => c.Id.ToString() == carId)
                .To<CarDeleteViewModel>()
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
    }
}
