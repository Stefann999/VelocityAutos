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
                CategoryId = 1
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
                CategoryId = 2
            };

            cars.Add(secondCar);

            Car thirdCar = new Car
            {
                Id = Guid.Parse("c48b7dcd-0d04-4a56-bfe0-df00eb6812b5"),
                Make = "Porsche",
                Model = "911 GT3 RS",
                Price = 280000,
                Month = 1,
                Year = 2024,
                Mileage = 100,
                HorsePower = 525,
                FuelTypeId = 1,
                FuelConsumption = 13.5,
                TransmissionTypeId = 2,
                Color = "White",
                Description = "The new Porsche GT3 RS is a track-focused powerhouse, featuring a high-revving naturally aspirated engine and lightweight construction for agile handling. With aerodynamic enhancements and over 500 horsepower on tap, it promises an exhilarating driving experience that's both thrilling on the track and rewarding on the road.",
                LocationCity = "Sofia",
                LocationCountry = "Bulgaria",
                CategoryId = 2
            };

            cars.Add(thirdCar);

            Car fourthCar = new Car
            {
                Id = Guid.Parse("f6707b62-64e1-415f-af35-eb635f988c47"),
                Make = "Toyota",
                Model = "Yaris",
                Price = 27000,
                Month = 4,
                Year = 2019,
                Mileage = 68000,
                HorsePower = 100,
                FuelTypeId = 4,
                FuelConsumption = 6,
                TransmissionTypeId = 2,
                Color = "Black",
                Description = "Beautiful compact hatchback. The car combines fuel efficiency with practicality, boasting a sleek design and responsive handling. Its hybrid powertrain offers a smooth driving experience while minimizing environmental impact, making it an ideal choice for eco-conscious drivers.",
                LocationCity = "Plovdiv",
                LocationCountry = "Bulgaria",
                CategoryId = 3
            };

            cars.Add(fourthCar);

            Car fifthCar = new Car
            {
                Id = Guid.Parse("82f03f75-cfb3-4434-bb73-f8c5dcf4109d"),
                Make = "Hyundai",
                Model = "I40",
                Price = 22000,
                Month = 9,
                Year = 2015,
                Mileage = 179000,
                HorsePower = 136,
                FuelTypeId = 2,
                FuelConsumption = 8,
                TransmissionTypeId = 2,
                Color = "Graphite",
                Description = "The Hyundai i40 offers a blend of comfort, performance, and technology in the midsize sedan segment. With its spacious interior, efficient engines, and modern features, the i40 delivers a refined driving experience suitable for both urban commutes and long highway journeys.",
                LocationCity = "Blagoevgrad",
                LocationCountry = "Bulgaria",
                CategoryId = 2
            };

            cars.Add(fifthCar);

            Car sixthCar = new Car
            {
                Id = Guid.Parse("fd1f3b19-7e3b-4fec-a1b0-e47188884a42"),
                Make = "BMW",
                Model = "X5",
                Price = 49999,
                Month = 2,
                Year = 2014,
                Mileage = 200000,
                HorsePower = 381,
                FuelTypeId = 2,
                FuelConsumption = 12,
                TransmissionTypeId = 2,
                Color = "Black",
                Description = "The BMW X5 epitomizes luxury and versatility in the midsize SUV segment, offering a spacious cabin, cutting-edge technology, and robust performance. With its refined interior, smooth ride, and impressive array of features, the X5 is designed to provide comfort and excitement for both daily driving and adventurous journeys alike.",
                LocationCity = "Varna",
                LocationCountry = "Bulgaria",
                CategoryId = 4
            };

            cars.Add(sixthCar);

            return cars.ToArray();
        }

    }
}
