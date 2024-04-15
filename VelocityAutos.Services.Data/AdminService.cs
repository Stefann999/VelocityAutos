using Dropbox.Api.TeamLog;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Common;
using static VelocityAutos.Common.GeneralApplicationConstants;

namespace VelocityAutos.Services.Data
{
    public class AdminService : IAdminService
    {
        private readonly IUserService userService;
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminService(IUserService userService, IRepository repository, UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.repository = repository;
            this.userManager = userManager;

        }

        public async Task<string> AddAdminAsync(string userId)
        {
            ApplicationUser user = userService.GetUserByIdAsync(userId).Result;

            await userManager.AddToRoleAsync(user, AdminRoleName);
            await repository.SaveChangesAsync();

            return user.Id.ToString();
        }

        public async Task<string> RemoveAdminAsync(string userId)
        {
            ApplicationUser user = userService.GetUserByIdAsync(userId).Result;

            await userManager.RemoveFromRoleAsync(user, AdminRoleName);
            await repository.SaveChangesAsync();

            return user.Id.ToString();
        }
    }
}
