using Microsoft.AspNetCore.Http;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface IDropboxService
    {
        Task<string> UploadImagesAsync(IEnumerable<IFormFile> images, string carId);

        Task<List<string>> GetCarImages(string carFolderPath, bool isForAll);

        Task DeleteImagesAsync(string carFolderPath);

    }
}
