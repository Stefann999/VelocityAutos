namespace VelocityAutos.Web.ViewModels.Car
{
    public class AdminCarAllViewModel
    {
        public string PostId { get; set; } = null!;

        public string CarId { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public ICollection<string> ImagesPaths { get; set; } = null!;
    }
}
