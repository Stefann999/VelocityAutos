﻿using VelocityAutos.Data.Models;
using VelocityAutos.Web.ViewModels.User;

namespace VelocityAutos.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> GetFullNameByEmailAddressAsync(string emailAddress);

        Task<string> GetPhoneNumberByEmailAddressAsync(string emailAddress);

        Task<string> GetFullNameByIdAsync(string userId);

        Task<IEnumerable<UserViewModel>> AllAsync();

        Task<bool> ExistsByIdAsync(string userId);

        Task<ApplicationUser> GetUserByIdAsync(string userId);
    }
}
