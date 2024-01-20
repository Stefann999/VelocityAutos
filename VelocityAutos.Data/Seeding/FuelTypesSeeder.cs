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
                new FuelType { FuelTypeName = "Petrol", Id = 1 },
                new FuelType { FuelTypeName = "Diesel", Id = 2 },
                new FuelType { FuelTypeName = "Electric", Id = 3 },
                new FuelType { FuelTypeName = "Hybrid", Id = 4 },
                new FuelType { FuelTypeName = "LPG", Id = 5 },
                new FuelType { FuelTypeName = "CNG" ,Id = 6 },
                new FuelType { FuelTypeName = "Ethanol", Id = 7 },
                new FuelType { FuelTypeName = "Biodiesel", Id = 8 },
                new FuelType { FuelTypeName = "Bioethanol", Id = 9 },
                new FuelType { FuelTypeName = "Methanol", Id = 10 },
                new FuelType { FuelTypeName = "Biogas", Id = 11 },
                new FuelType { FuelTypeName = "Synthetic", Id = 12 },
                new FuelType { FuelTypeName = "Hydrogen", Id = 13 },
                new FuelType { FuelTypeName = "Other", Id = 14 }
             };

            return fuelTypes.ToArray();
        }

    }
}