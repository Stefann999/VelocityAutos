namespace VelocityAutos.Web.ViewModels.Car
{
    public class CarDetailsViewModel
    {
        public string Id { get; set; } = null!;
        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public decimal Price { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public int Mileage { get; set; }

        public int HorsePower { get; set; }

        public double FuelConsumption { get; set; }

        public string Color { get; set; } = null!;

        public string? Description { get; set; }

        public string LocationCity { get; set; } = null!;

        public string LocationCountry { get; set; } = null!;

        public string TransmissionType { get; set; } = null!;

        public string FuelType { get; set; } = null!;

        public string Category { get; set; } = null!;
    }
}
