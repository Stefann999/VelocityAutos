using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VelocityAutos.Data.Models;

namespace VelocityAutos.Data.Seeding
{
    public class TransmissionTypesSeeder : IEntityTypeConfiguration<TransmissionType>
    {
        public void Configure(EntityTypeBuilder<TransmissionType> builder)
        {
            builder.HasData(this.SeedTransmissionTypes());
        }

        private TransmissionType[] SeedTransmissionTypes()
        {
            ICollection<TransmissionType> transmissionTypes = new HashSet<TransmissionType>()
            {
                new TransmissionType { Name = "Manual", Id = 1 },
                new TransmissionType { Name = "Automatic", Id = 2 },
                new TransmissionType { Name = "Semi-automatic", Id = 3 },
                new TransmissionType { Name = "CVT" , Id = 4 },
                new TransmissionType { Name = "DSG" , Id = 5 },
                new TransmissionType { Name = "Tiptronic" , Id = 6 },
                new TransmissionType { Name = "Other", Id = 7 }
             };

            return transmissionTypes.ToArray();
        }

    }
}