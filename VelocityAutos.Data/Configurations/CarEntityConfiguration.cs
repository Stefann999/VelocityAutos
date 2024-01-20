using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelocityAutos.Data.Models;

namespace VelocityAutos.Data.Configurations
{
    public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasOne(c => c.Owner)
                .WithMany(u => u.OwnerdCars)
                .HasForeignKey(c => c.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(c => c.UsersFavourite)
                .WithMany(u => u.FavouriteCars);
        }
    }
}
