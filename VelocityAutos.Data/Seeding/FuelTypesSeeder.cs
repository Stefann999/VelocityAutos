using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VelocityAutos.Data.Models;

namespace VelocityAutos.Data.Seeding
{
    public class FuelTypesSeeder : IEntityTypeConfiguration<FuelType>
    {
        public void Configure(EntityTypeBuilder<FuelType> builder)
        {
            builder.HasData(this.SeedFuelTypes());
        }

        private FuelType[] SeedFuelTypes()
        {
            ICollection<FuelType> fuelTypes = new HashSet<FuelType>()
            {
                new FuelType { Name = "Petrol", Id = 1 },
                new FuelType { Name = "Diesel", Id = 2 },
                new FuelType { Name = "Electric", Id = 3 },
                new FuelType { Name = "Hybrid", Id = 4 },
                new FuelType { Name = "LPG", Id = 5 },
                new FuelType { Name = "CNG" ,Id = 6 },
                new FuelType { Name = "Ethanol", Id = 7 },
                new FuelType { Name = "Biodiesel", Id = 8 },
                new FuelType { Name = "Bioethanol", Id = 9 },
                new FuelType { Name = "Methanol", Id = 10 },
                new FuelType { Name = "Biogas", Id = 11 },
                new FuelType { Name = "Synthetic", Id = 12 },
                new FuelType { Name = "Hydrogen", Id = 13 },
                new FuelType { Name = "Other", Id = 14 }
             };

            return fuelTypes.ToArray();
        }

    }
}