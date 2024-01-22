using Microsoft.AspNetCore.Http;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface IDropboxService
    {
        Task<List<string>> UploadImagesAsync(List<IFormFile> images, Guid carId);
    }
}
