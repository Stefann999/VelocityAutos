using Microsoft.AspNetCore.Http;

using Dropbox.Api.Files;
using Dropbox.Api;

using VelocityAutos.Services.Data.Interfaces;

namespace VelocityAutos.Services.Data
{
    public class DropboxService : IDropboxService
    {
        private readonly string accessToken;

        public DropboxService(string accessToken)
        {
            this.accessToken = accessToken;
        }

        public async Task<List<string>> UploadImagesAsync(List<IFormFile> images, Guid carId)
        {
            var uploadedUrls = new List<string>();

            using (var dbx = new DropboxClient(accessToken))
            {
                var folderName = $"Car_{carId}";
                var folderPath = $"/VelocityAutos/CarImages/{folderName}";

                // Create a folder with the carId in Dropbox
                await dbx.Files.CreateFolderV2Async(folderPath);

                foreach (var image in images)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var dropboxPath = $"{folderPath}/{fileName}";

                    using (var stream = image.OpenReadStream())
                    {
                        var response = await dbx.Files.UploadAsync(dropboxPath, WriteMode.Overwrite.Instance, body: stream);
                        uploadedUrls.Add(response.PathDisplay);
                    }
                }
            }

            return uploadedUrls;
        }
    }
}
