using Microsoft.AspNetCore.Mvc;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.ViewModels.User;

namespace VelocityAutos.Web.Areas.Admin.Controllers
{
    public class UserController :BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("/User/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> users = await this.userService.AllAsync();

            return this.View(users);
        }
    }
}
