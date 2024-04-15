using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VelocityAutos.Data.Models;

namespace VelocityAutos.Data
{
    public class VelocityAutosDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private readonly bool seedDb;

        public VelocityAutosDbContext(DbContextOptions<VelocityAutosDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<FuelType> FuelTypes { get; set; }

        public DbSet<TransmissionType> TransmissionTypes { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Car>()
                .HasOne(c => c.Post)
                .WithOne(p => p.Car)
                .HasForeignKey<Post>(p => p.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserCar>()
                .HasKey(uc => new { uc.CarId, uc.UserId });

            builder
                .Entity<Car>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Car>()
                .HasOne(c => c.FuelType)
                .WithMany(ft => ft.Cars)
                .HasForeignKey(c => c.FuelTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Car>()
                .HasOne(c => c.TransmissionType)
                .WithMany(tt => tt.Cars)
                .HasForeignKey(c => c.TransmissionTypeId)
                .OnDelete(DeleteBehavior.Restrict);


            if (this.seedDb)
            {
                builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }

            base.OnModelCreating(builder);
        }
    }
}