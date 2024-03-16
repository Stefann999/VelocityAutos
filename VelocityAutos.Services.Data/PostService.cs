using Microsoft.EntityFrameworkCore;
using VelocityAutos.Data;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.ViewModels.Post;

namespace VelocityAutos.Services.Data
{
    public class PostService : IPostService
    {
        private readonly VelocityAutosDbContext dbContext;

        public PostService(VelocityAutosDbContext dbContext)
        {
            this.dbContext = dbContext;
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

            await this.dbContext.Posts.AddAsync(post);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<PostDetailsViewModel> GetPostForDetailsByIdAsync(string carId)
        {
            var post = await this.dbContext
                .Posts
                .AsNoTracking()
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
            var post = await this.dbContext
               .Posts
               .AsNoTracking()
               .Where(p => p.Car.Id.ToString() == carId)
               .Select(p => new PostFormModel()
               {
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
            var post = await this.dbContext
                .Posts
                .FirstOrDefaultAsync(p => p.Id.ToString() == postId);

            if (post != null)
            {
                post.SellerFirstName = postFormModel.FirstName;
                post.SellerLastName = postFormModel.LastName;
                post.SellerPhoneNumber = postFormModel.PhoneNumber;
                post.SellerEmailAddress = postFormModel.EmailAddress;
                post.UpdatedOn = DateTime.Now;
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsUserPostOwnerById(string carId, string userId)
        {
            Car? car = await this.dbContext
                .Cars
                .AsNoTracking()
                .Include(c => c.Post)
                .FirstOrDefaultAsync(c => c.Id.ToString() == carId);

            if (car == null)
            {
                return false;
            }

            return car.Post.SellerId.ToString() == userId;
        }

    }
}
