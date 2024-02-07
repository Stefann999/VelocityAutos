using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelocityAutos.Data.Models;

namespace VelocityAutos.Data.Seeding
{
    public class CarsSeeder : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(this.SeedCars());
        }

        private Car[] SeedCars()
        {
            ICollection<Car> cars = new HashSet<Car>();

            Car firstCar = new Car
            {
                Id = Guid.Parse("74576f3e-a409-46e4-a8ff-9c93eb409cba"),
                Make = "Audi",
                Model = "A4",
                Price = 50000,
                Month = 3,
                Year = 2019,
                Mileage = 10000,
                HorsePower = 150,
                FuelTypeId = 1,
                FuelConsumption = 6.5,
                TransmissionTypeId = 1,
                Color = "Black",
                Description = "The 2019 Audi A4 is a luxury compact sedan that combines sophisticated design, advanced technology, and impressive performance.",
                LocationCity = "Sofia",
                LocationCountry = "Bulgaria",
                CategoryId = 1,
                OwnerId = Guid.Parse("66543f29-bafc-4680-8028-5c4b7e444ccb"),
                isSold = false
            };
            cars.Add(firstCar);

            Car secondCar = new Car
            {
                Id = Guid.Parse("9219e817-e86a-4ea0-807f-976d8195d93a"),
                Make = "Mercedes",
                Model = "GT63 S 4-door",
                Price = 200000,
                Month = 1,
                Year = 2023,
                Mileage = 5000,
                HorsePower = 639,
                FuelTypeId = 1,
                FuelConsumption = 15,
                TransmissionTypeId = 2,
                Color = "White",
                Description = "The Mercedes-AMG GT 63 S is a high-performance luxury four-door coupe that offers a combination of striking design, advanced technology, and powerful performance.",
                LocationCity = "Sofia",
                LocationCountry = "Bulgaria",
                CategoryId = 2,
                OwnerId = Guid.Parse("ed670787-a2d5-45e9-a069-83dcd8e84e30"),
                isSold = false
            };

            cars.Add(secondCar);

            return cars.ToArray();
        }

    }
}
