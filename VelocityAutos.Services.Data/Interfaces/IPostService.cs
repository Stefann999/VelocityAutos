using VelocityAutos.Data.Models;
using VelocityAutos.Web.ViewModels.Car;
using VelocityAutos.Web.ViewModels.Post;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface IPostService
    {
        Task CreateAsync(string carId, string currUserId, string emailAddress);

        Task<bool> IsUserPostOwnerByIdAsync(string carId, string userId);

        Task<PostDetailsViewModel> GetPostForDetailsByIdAsync(string carId);

        Task UpdateAsync(string postId);

        Task<CarDeleteViewModel> GetPostForDeleteAsync(string carId);

        Task DeleteAsync(string carId);

        Task ActivateAsync(string carId);
    }
}
