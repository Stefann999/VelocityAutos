using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Extensions;
using VelocityAutos.Web.ViewModels.User;
using static VelocityAutos.Common.GeneralApplicationConstants;
using static VelocityAutos.Common.NotificationMessagesConstants;

namespace VelocityAutos.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;
        private readonly IAdminService adminService;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(IUserService userService,
            IMemoryCache memoryCache,
            UserManager<ApplicationUser> userManager,
            IAdminService adminService)
        {
            this.userService = userService;
            this.memoryCache = memoryCache;
            this.userManager = userManager;
            this.adminService = adminService;
        }

        [Route("/User/All")]
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Client, NoStore = false)]
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> users = this.memoryCache.Get<IEnumerable<UserViewModel>>(UserCacheKey);

            if (users == null)
            {
                users = await this.userService.AllAsync();

                MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan
                        .FromMinutes(UserCacheExpirationInMinutes));

                this.memoryCache.Set(UserCacheKey, users, cacheOptions);
            }

            return this.View(users);
        }

        [HttpGet]
        public async Task<IActionResult> MakeAdmin(string id)
        {
            if (!this.User.IsAdmin())
            {
                TempData[ErrorMessage] = "Insufficient Permissions";
                return RedirectToAction(nameof(All));
            }

            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }

            var user = await userService.GetUserByIdAsync(id);

            if (await userManager.IsInRoleAsync(user, AdminRoleName))
            {
                TempData[ErrorMessage] = "User is already an Admin";
                return RedirectToAction(nameof(All));
            }

            if (user.Email == DevelopmentAdminEmail)
            {
                TempData[ErrorMessage] = "You cannot moderate this Admin";
                return RedirectToAction(nameof(All));
            }

            var makeAdminForm = new UserMakeAdminViewModel()
            {
                Id = id,
                Email = user.Email,
                PhoneNumber = userService.GetPhoneNumberByEmailAddressAsync(user.Email).Result,
                FullName = userService.GetFullNameByIdAsync(id).Result,
                IsAdmin = userManager.IsInRoleAsync(user, AdminRoleName).Result
            };

            return View(makeAdminForm);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmMakeAdmin(string id)
        {
            if (!this.User.IsAdmin())
            {
                TempData[ErrorMessage] = "Insufficient Permissions";
                return RedirectToAction(nameof(All));
            }

            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }

            var user = await userService.GetUserByIdAsync(id);

            if (await userManager.IsInRoleAsync(user, AdminRoleName))
            {
                TempData[ErrorMessage] = "User is already an Admin";
                return RedirectToAction(nameof(All));
            }

            if (user.Email == DevelopmentAdminEmail)
            {
                TempData[ErrorMessage] = "You cannot moderate this Admin";
                return RedirectToAction(nameof(All));
            }

            await adminService.AddAdminAsync(id);

            TempData[SuccessMessage] = "User is now an Admin";

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> RemoveAdmin(string id)
        {
            if (!this.User.IsAdmin())
            {
                TempData[ErrorMessage] = "Insufficient Permissions";
                return RedirectToAction(nameof(All));
            }

            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }

            var user = await userService.GetUserByIdAsync(id);

            if (!await userManager.IsInRoleAsync(user, AdminRoleName))
            {
                TempData[ErrorMessage] = "User is not an Admin";
                return RedirectToAction(nameof(All));
            }

            if (user.Email == DevelopmentAdminEmail)
            {
                TempData[ErrorMessage] = "You cannot moderate this Admin";
                return RedirectToAction(nameof(All));
            }

            var removeAdminForm = new UserMakeAdminViewModel()
            {
                Id = id,
                Email = user.Email,
                PhoneNumber = userService.GetPhoneNumberByEmailAddressAsync(user.Email).Result,
                FullName = userService.GetFullNameByIdAsync(id).Result,
                IsAdmin = userManager.IsInRoleAsync(user, AdminRoleName).Result
            };

            return View(removeAdminForm);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmRemoveAdmin(string id)
        {
            if (!this.User.IsAdmin())
            {
                TempData[ErrorMessage] = "Insufficient Permissions";
                return RedirectToAction(nameof(All));
            }

            if (!await userService.ExistsByIdAsync(id))
            {
                return BadRequest();
            }

            var user = await userService.GetUserByIdAsync(id);

            if (!await userManager.IsInRoleAsync(user, AdminRoleName))
            {
                TempData[ErrorMessage] = "User is not an Admin";
                return RedirectToAction(nameof(All));
            }

            if (user.Email == DevelopmentAdminEmail)
            {
                TempData[ErrorMessage] = "You cannot moderate this Admin";
                return RedirectToAction(nameof(All));
            }

            await adminService.RemoveAdminAsync(id);

            TempData[SuccessMessage] = "User is no longer an Admin";

            return RedirectToAction(nameof(All));
        }
    }
}
