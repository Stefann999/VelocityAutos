namespace VelocityAutos.Web.ViewModels.Car
{
    public class CarDeleteViewModel
    {
        public string Id { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public decimal Price { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public string SellerId { get; set; } = null!;
    }
}
