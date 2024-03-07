using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
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
               Car = car,
               SellerFirstName = postFormModel.FirstName,
               SellerLastName = postFormModel.LastName,
               SellerPhoneNumber = postFormModel.PhoneNumber,
               SellerEmailAddress = postFormModel.EmailAddress,
               SellerId = Guid.Parse(currUserId),
               CreatedOn = DateTime.UtcNow,
               UpdatedOn = null,
               IsActive = true,
           };

            await this.dbContext.Posts.AddAsync(post);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<PostDetailsViewModel> GetPostByIdAsync(string carId)
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

        //public async Task<bool> IsUserPostOwnerById(string carId, string userId)
        //{
        //    Car? car = await this.dbContext
        //        .Cars
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(c => c.Id.ToString() == carId);

        //    if (car == null)
        //    {
        //        return false;
        //    }

        //    return car.Post.SellerId.ToString() == userId;
        //}
    }
}
