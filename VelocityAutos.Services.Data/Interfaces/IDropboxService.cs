using Microsoft.AspNetCore.Http;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface IDropboxService
    {
        Task<List<string>> UploadImagesAsync(IEnumerable<IFormFile> images, Guid carId);
    }
}
