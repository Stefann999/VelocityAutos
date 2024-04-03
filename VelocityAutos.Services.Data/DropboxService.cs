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

        public async Task<List<string>> UploadImagesAsync(IEnumerable<IFormFile> images, string carId)
        {
            var uploadedUrls = new List<string>();

            using (var dbx = new DropboxClient(accessToken))
            {
                var folderName = $"Car_{carId}";
                var folderPath = $"/VelocityAutos/CarImages/{folderName}";

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

        public async Task<List<string>> GetCarImages(string carFolderPath, bool isForAll)
        {
            var dbx = new DropboxClient(accessToken);

            List<string> imageUrls = new List<string>();

            try
            {
                var list = await dbx.Files.ListFolderAsync(carFolderPath);

                foreach (var entry in list.Entries)
                {
                    if (entry.IsFile && IsImage(entry.Name))
                    {
                        using (var response = await dbx.Files.DownloadAsync(entry.PathLower))
                        {
                            var imageBytes = await response.GetContentAsByteArrayAsync();

                            var base64String = Convert.ToBase64String(imageBytes);

                            var imageUrl = string.Format("data:image/png;base64,{0}", base64String);

                            imageUrls.Add(imageUrl);

                            if (isForAll)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return imageUrls;
        }

        // Helper method to check if a file is an image
        private bool IsImage(string fileName)
        {
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".webp", ".avif" };
            string extension = Path.GetExtension(fileName).ToLower();
            return Array.IndexOf(imageExtensions, extension) != -1;
        }
    }
}
