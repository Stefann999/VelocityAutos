using VelocityAutos.Data.Models;
using VelocityAutos.Web.ViewModels.Car;
using VelocityAutos.Web.ViewModels.Post;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface IPostService
    {
        public Task CreateAsync(PostFormModel postFormModel, Car car, string currUserId);

        public Task<bool> IsUserPostOwnerById(string carId, string userId);

        public Task<PostDetailsViewModel> GetPostForDetailsByIdAsync(string carId);

        public Task<PostFormModel> GetPostForEditByIdAsync(string carId);

        public Task UpdateAsync(PostFormModel postFormModel, string carId);

        public Task<CarDeleteViewModel> GetPostForDelete(string carId);

        public Task DeleteAsync(string carId);
    }
}
