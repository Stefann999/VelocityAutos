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

        public async Task<string> UploadImagesAsync(IEnumerable<IFormFile> images, string carId)
        {
            string imagePath = string.Empty;

            using (var dbx = new DropboxClient(accessToken))
            {
                var folderName = $"Car_{carId}";
                var folderPath = $"/VelocityAutos/CarImages/{folderName}";

                bool fileExists = await FolderExistsAsync(folderPath);

                if (fileExists)
                {
                    await DeleteImagesAsync(folderPath);
                }
                else
                {
                    await dbx.Files.CreateFolderV2Async(folderPath);
                    imagePath = folderPath;
                }

                foreach (var image in images)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var dropboxPath = $"{folderPath}/{fileName}";

                    using (var stream = image.OpenReadStream())
                    {
                        var response = await dbx.Files.UploadAsync(dropboxPath, WriteMode.Overwrite.Instance, body: stream);
                    }
                }
            }

            return imagePath;
        }

        public async Task DeleteImagesAsync(string folderPath)
        {
            using (var dbx = new DropboxClient(accessToken))
            {
                try
                {
                    var list = await dbx.Files.ListFolderAsync(folderPath);

                    // Delete each file
                    foreach (var item in list.Entries)
                    {
                        if (item.IsFile)
                        {
                            await dbx.Files.DeleteV2Async(item.PathDisplay);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception();
                }
            }
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

        // Helper method to check if a folder exists
        private async Task<bool> FolderExistsAsync(string folderPath)
        {
            using (var dropboxClient = new DropboxClient(accessToken))
            {
                try
                {
                    // Check if the folder exists
                    var folderMetadata = await dropboxClient.Files.GetMetadataAsync(folderPath);

                    // If the metadata is a folder, return true
                    if (folderMetadata.IsFolder)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (ApiException<GetMetadataError> e)
                {
                    if (e.ErrorResponse.IsPath && e.ErrorResponse.AsPath.Value.IsNotFound)
                    {
                        return false; // Folder does not exist
                    }
                    else
                    {
                        throw; // Handle other errors accordingly
                    }
                }
            }
        }
    }
}
