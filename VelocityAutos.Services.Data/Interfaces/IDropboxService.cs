using Microsoft.AspNetCore.Http;

using Dropbox.Api;
using Dropbox.Api.Files;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface IDropboxService
    {
        Task<string> UploadImagesAsync(List<IFormFile> images);
    }
}
