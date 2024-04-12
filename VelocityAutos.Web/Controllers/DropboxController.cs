using Microsoft.AspNetCore.Mvc;
using VelocityAutos.Services.Data.Interfaces;
using static VelocityAutos.Common.NotificationMessagesConstants;

public class DropboxController : Controller
{
    private readonly IConfiguration config;
    private readonly IDropboxService dropboxService;

    public DropboxController(IConfiguration config, IDropboxService dropboxService)
    {
        this.config = config;
        this.dropboxService = dropboxService;
    }

    public IActionResult Authorize()
    {
        var authorizeUri = dropboxService.Authorize();
        return Redirect(authorizeUri.ToString());
    }


    public async Task<IActionResult> Callback(string code)
    {
        var redirectUri = await dropboxService.Callback(code);

        TempData[SuccessMessage] = "You have successfully authorized Dropbox. If you were trying to perform an action, please do it again. If the issue continues, contact an administrator!";
        return Redirect(redirectUri);
    }
}
