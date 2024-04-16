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

        public string SellerFullName { get; set; } = null!;

        public string SellerPhoneNumber { get; set; } = null!;

        public string SellerEmail { get; set; } = null!;

        public int HorsePower { get; set; }

        public int Mileage { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public ICollection<string> ImagesPaths { get; set; } = null!;
    }
}
