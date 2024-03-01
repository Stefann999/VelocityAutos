using VelocityAutos.Data.Models;
using VelocityAutos.Web.ViewModels.Post;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface IPostService
    {
        public Task CreateAsync(PostFormModel postFormModel, Car car, string currUserId);
        //public Task<bool> IsUserPostOwnerById(string carId, string userId);
    }
}
