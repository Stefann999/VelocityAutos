using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.ViewModels.User;
using static VelocityAutos.Common.GeneralApplicationConstants;

namespace VelocityAutos.Web.Areas.Admin.Controllers
{
    public class UserController :BaseAdminController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;

        public UserController(IUserService userService, IMemoryCache memoryCache)
        {
            this.userService = userService;
            this.memoryCache = memoryCache;
        }

        [Route("/User/All")]
        [ResponseCache(Duration = 30)]
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
    }
}
