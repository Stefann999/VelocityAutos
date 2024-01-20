using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VelocityAutos.Data.Models;
using VelocityAutos.Data.Seeding;

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

        public DbSet<Extra> Extras { get; set; }

        public DbSet<CarExtra> CarExtras { get; set; }

        public DbSet<ExtraType> ExtraTypes { get; set; }

        public DbSet<FuelType> FuelTypes { get; set; }

        public DbSet<TransmissionType> TransmissionTypes { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Car>()
                .HasOne(c => c.Owner)
                .WithMany(u => u.OwnerdCars)
                .HasForeignKey(c => c.OwnerId);

            builder
                .Entity<Car>()
                .HasMany(c => c.UsersFavourite)
                .WithMany(u => u.FavouriteCars);


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

            builder
                .Entity<Extra>()
                .HasOne(e => e.ExtraType)
                .WithMany(et => et.Extras)
                .HasForeignKey(e => e.TypeId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .Entity<CarExtra>()
                .HasKey(ce => new { ce.CarId, ce.ExtraId });

            builder
                .Entity<CarExtra>()
                .HasOne(ce => ce.Extra)
                .WithMany(e => e.CarExtras)
                .HasForeignKey(ce => ce.ExtraId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<CarExtra>()
                .HasOne(ce => ce.Car)
                .WithMany(c => c.CarExtras)
                .HasForeignKey(ce => ce.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            if (this.seedDb)
            {
                builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            }

            base.OnModelCreating(builder);
        }
    }
}