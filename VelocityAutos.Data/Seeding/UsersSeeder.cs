using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

            ApplicationUser firstUser = new ApplicationUser()
            {
                Id = Guid.Parse("66543f29-bafc-4680-8028-5c4b7e444ccb"),
                UserName = "IvanCars",
                NormalizedUserName = "IVANCARS",
                Email = "ivancars1@cars.com",
                NormalizedEmail = "IVANCARS1@CARS.COM",
                EmailConfirmed = true,
                PasswordHash = "96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b838858cdd6ca0a1e",
                SecurityStamp = "f49c695d-b65c-4245-a204-70ac1ef3167c",
                ConcurrencyStamp = "668e7d82-3497-47eb-9098-6132d4888d53",
                PhoneNumber = "0888888888",
                PhoneNumberConfirmed = true
            };    
            
            applicationUsers.Add(firstUser);

            ApplicationUser secondUser = new ApplicationUser()
            {
                Id = Guid.Parse("ed670787-a2d5-45e9-a069-83dcd8e84e30"),
                UserName = "dimitur12",
                NormalizedUserName = "DIMITUR12",
                Email = "dimitur122@cars.com",
                NormalizedEmail = "DIMITUR122@CARS.COM",
                EmailConfirmed = true,
                PasswordHash = "96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b838858cdd6ca0a1e",
                SecurityStamp = "e5507714-6b85-407b-a9e4-85b8856de4bd",
                ConcurrencyStamp = "3f509880-8a4c-4e64-ba38-353c1611c646",
                PhoneNumber = "0999999999",
                PhoneNumberConfirmed = true
            };

            applicationUsers.Add(secondUser);

            return applicationUsers.ToArray();
        }
    }
}
