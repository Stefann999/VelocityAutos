using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelocityAutos.Data.Models;

namespace VelocityAutos.Data.Seeding
{
    public class ExtrasTypesSeeder : IEntityTypeConfiguration<ExtraType>
    {
        public void Configure(EntityTypeBuilder<ExtraType> builder)
        {
            builder.HasData(this.SeedCars());
        }

        private ExtraType[] SeedCars()
        {
            ICollection<ExtraType> extrasTypes = new HashSet<ExtraType>()
            {
                new ExtraType { ExtraTypeName = "Safety", Id = 1 },
                new ExtraType { ExtraTypeName = "Exterior", Id = 2 },
                new ExtraType { ExtraTypeName = "Secutiry", Id = 3 },
                new ExtraType { ExtraTypeName = "Confort", Id = 4 },
                new ExtraType { ExtraTypeName = "Others", Id = 5 }
            };

            return extrasTypes.ToArray();
        }

    }
}
