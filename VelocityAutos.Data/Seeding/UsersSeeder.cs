using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Claims;
using VelocityAutos.Data.Models;

namespace VelocityAutos.Data.Seeding
{
    public class UsersSeeder : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(this.SeedUsers());
        }

        private ApplicationUser[] SeedUsers()
        {
            ICollection<ApplicationUser> applicationUsers = new HashSet<ApplicationUser>();

            var hasher = new PasswordHasher<ApplicationUser>();

            ApplicationUser firstUser = new ApplicationUser()
            {
                Id = Guid.Parse("66543f29-bafc-4680-8028-5c4b7e444ccb"),
                UserName = "ivancars1@cars.com",
                NormalizedUserName = "IVANCARS1@CARS.COM",
                Email = "ivancars1@cars.com",
                NormalizedEmail = "IVANCARS1@CARS.COM",
                EmailConfirmed = true,
                SecurityStamp = "f49c695d-b65c-4245-a204-70ac1ef3167c",
                ConcurrencyStamp = "668e7d82-3497-47eb-9098-6132d4888d53",
                PhoneNumber = "0888888888",
                PhoneNumberConfirmed = true,
                FirstName = "Ivan",
                LastName = "Stoilov"
            };

            firstUser.PasswordHash = hasher.HashPassword(firstUser, "123123");

            applicationUsers.Add(firstUser);

            ApplicationUser secondUser = new ApplicationUser()
            {
                Id = Guid.Parse("ed670787-a2d5-45e9-a069-83dcd8e84e30"),
                UserName = "dimitur122@cars.com",
                NormalizedUserName = "DIMITUR122@CARS.COM",
                Email = "dimitur122@cars.com",
                NormalizedEmail = "DIMITUR122@CARS.COM",
                EmailConfirmed = true,
                SecurityStamp = "e5507714-6b85-407b-a9e4-85b8856de4bd",
                ConcurrencyStamp = "3f509880-8a4c-4e64-ba38-353c1611c646",
                PhoneNumber = "0999999999",
                PhoneNumberConfirmed = true,
                FirstName = "Dimitur",
                LastName = "Vasilev"
            };

            secondUser.PasswordHash = hasher.HashPassword(secondUser, "123123");

			applicationUsers.Add(secondUser);

            ApplicationUser adminUser = new ApplicationUser()
            {
                Id = Guid.Parse("80821bfc-806b-4ae5-b279-b931e1afc048"),
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = "7533496a-0b1c-43e0-97a1-ece7f8a8f526",
                ConcurrencyStamp = "f2c5b8ae-1b99-4213-9f32-e4b37fa08277",
                PhoneNumber = "0999999999",
                PhoneNumberConfirmed = true,
                FirstName = "Admin",
                LastName = "Admin"
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "admin123");

            applicationUsers.Add(adminUser);

            return applicationUsers.ToArray();
        }
    }
}
