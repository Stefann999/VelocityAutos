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
                new TransmissionType { TransmissionTypeName = "Manual", Id = 1 },
                new TransmissionType { TransmissionTypeName = "Automatic", Id = 2 },
                new TransmissionType { TransmissionTypeName = "Semi-automatic", Id = 3 },
                new TransmissionType { TransmissionTypeName = "CVT" , Id = 4 },
                new TransmissionType { TransmissionTypeName = "DSG" , Id = 5 },
                new TransmissionType { TransmissionTypeName = "Tiptronic" , Id = 6 },
                new TransmissionType { TransmissionTypeName = "Other", Id = 7 }
             };

            return transmissionTypes.ToArray();
        }

    }
}