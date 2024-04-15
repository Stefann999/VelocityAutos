using System.ComponentModel.DataAnnotations;
using VelocityAutos.Services.Mapping;

namespace VelocityAutos.Web.ViewModels.Car
{
    using VelocityAutos.Data.Models;

    public class CarAllViewModel : IMapFrom<Post>
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

        public string? Description { get; set; }

        [Display(Name = "Location city")]
        public string LocationCity { get; set; } = null!;

        [Display(Name = "Location country")]
        public string LocationCountry { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public string FuelTypeName { get; set; } = null!;

        public string TransmissionTypeName { get; set; } = null!;

        public string OwnerId { get; set; } = null!;

        public virtual ICollection<string> ImagesPaths { get; set; } = null!;
    }
}
