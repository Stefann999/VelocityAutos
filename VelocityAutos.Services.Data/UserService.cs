using Microsoft.EntityFrameworkCore;
using VelocityAutos.Data;
using VelocityAutos.Data.Models;
using VelocityAutos.Services.Data.Interfaces;
using VelocityAutos.Web.Infrastructure.Common;

namespace VelocityAutos.Services.Data
{
    public class UserService : IUserService
    {
        private readonly VelocityAutosDbContext dbContext;
        private readonly IRepository repository;

        public UserService(VelocityAutosDbContext dbContext, IRepository repository)
        {
            this.dbContext = dbContext;
            this.repository = repository;
        }

        public async Task<string> GetFullNameByEmailAddress(string emailAddress)
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
    }
}
