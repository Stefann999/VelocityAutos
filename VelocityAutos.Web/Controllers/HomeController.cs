using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VelocityAutos.Web.Infrastructure.Extensions;
using VelocityAutos.Web.ViewModels.Home;
using static VelocityAutos.Common.GeneralApplicationConstants;

namespace VelocityAutos.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                return this.View("Error404");
            }
            else if (statusCode == 400)
            {
                return this.View("Error400");
            }

            return View();
        }
    }
}
