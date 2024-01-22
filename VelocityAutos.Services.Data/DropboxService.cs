using Microsoft.AspNetCore.Http;

using Dropbox.Api;
using Dropbox.Api.Files;

public class DropboxService
{
    private readonly string _accessToken; // Replace with your actual access token

    public DropboxService(string accessToken)
    {
        _accessToken = accessToken;
    }

    public async Task<List<string>> UploadImagesAsync(List<IFormFile> images, int carId)
    {
        var uploadedUrls = new List<string>();

        using (var dbx = new DropboxClient(_accessToken))
        {
            var folderName = $"Car_{carId}";
            var folderPath = $"/{folderName}";

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

