using System.ComponentModel.DataAnnotations;

namespace VelocityAutos.Web.ViewModels.Car
{
    public class CarAllViewModel
    {
        public CarAllViewModel()
        {
            this.ImagesPaths = new HashSet<string>();
        }

        public string Id { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public decimal Price { get; set; }

        [Display(Name = "Month of production")]
        public int Month { get; set; }

        [Display(Name = "Year of production")]
        public int Year { get; set; }

        [Display(Name = "Mileage in kilometers")]
        public int Mileage { get; set; }

        public int HorsePower { get; set; }

        [Display(Name = "Fuel consumption in liters per 100 km")]
        public double FuelConsumption { get; set; }

        public string Color { get; set; } = null!;

        public string? Description { get; set; }

        [Display(Name = "Location city")]
        public string LocationCity { get; set; } = null!;

        [Display(Name = "Location country")]
        public string LocationCountry { get; set; } = null!;

        public int CategoryId { get; set; }

        public string OwnerId { get; set; } = null!;

        public virtual ICollection<string> ImagesPaths { get; set; } = null!;
    }
}
