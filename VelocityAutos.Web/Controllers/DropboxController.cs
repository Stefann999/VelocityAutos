using Dropbox.Api;
using Microsoft.AspNetCore.Mvc;

public class DropboxController : Controller
{
    private readonly IConfiguration _config;

    public DropboxController(IConfiguration config)
    {
        this._config = config;
    }

    public IActionResult Authorize()
    {
        var appId = _config["Dropbox:AppId"];
        var redirectUri = _config["Dropbox:RedirectUri"];

        var authorizeUri = DropboxOAuth2Helper.GetAuthorizeUri(OAuthResponseType.Code, appId, new Uri(redirectUri));
        return Redirect(authorizeUri.ToString());
    }


    public async Task<IActionResult> Callback(string code)
    {
        var appId = _config["Dropbox:AppId"];
        var appSecret = _config["Dropbox:AppSecret"];
        var redirectUriString = _config["Dropbox:RedirectUri"];

        var response = await DropboxOAuth2Helper.ProcessCodeFlowAsync(code, appId, appSecret, redirectUriString);
        //var accessToken = response.AccessToken;

        // For demonstration purposes, let's assume storing access token in the session.
        //HttpContext.Session.SetString("DropboxAccessToken", accessToken);

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Authorized()
    {
        return View();
    }
}
