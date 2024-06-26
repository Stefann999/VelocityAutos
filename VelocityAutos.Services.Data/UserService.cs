﻿using Microsoft.EntityFrameworkCore;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Common;
using VelocityAutos.Web.ViewModels.User;
using static VelocityAutos.Common.GeneralApplicationConstants;

namespace VelocityAutos.Services.Data
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> GetFullNameByEmailAddressAsync(string emailAddress)
        {
            ApplicationUser? user = await repository.AllAsReadOnly<ApplicationUser>()
                .Where(u => u.Email == emailAddress)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<string> GetPhoneNumberByEmailAddressAsync(string emailAddress)
        {
            ApplicationUser? user = await repository.AllAsReadOnly<ApplicationUser>()
                .Where(u => u.Email == emailAddress)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return string.Empty;
            }

            return user.PhoneNumber;
        }

        public async Task<string> GetFullNameByIdAsync(string userId)
        {
            ApplicationUser user = await repository.AllAsReadOnly<ApplicationUser>()
                .Where(u => u.Id.ToString() == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            ICollection<UserViewModel> allUsers = await repository.AllAsReadOnly<ApplicationUser>()
                .Where(u => u.Email != DevelopmentAdminEmail)
                .Select(u => new UserViewModel
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}",
                    PhoneNumber = u.PhoneNumber,
                })
                .ToListAsync();

            var postsCnt = 0;

            foreach (var user in allUsers)
            {
                postsCnt = await repository.AllAsReadOnly<Post>()
                    .Where(p => p.SellerId.ToString() == user.Id)
                    .CountAsync();

                user.PostsCount = postsCnt;
            }

            return allUsers;
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repository.AllAsReadOnly<ApplicationUser>().AnyAsync(u => u.Id.ToString() == userId);
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            return await repository.All<ApplicationUser>()
                .Where(u => u.Id.ToString() == userId)
                .FirstOrDefaultAsync();
        }
    }
}
