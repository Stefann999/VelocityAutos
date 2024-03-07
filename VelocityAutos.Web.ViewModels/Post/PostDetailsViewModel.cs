using VelocityAutos.Web.ViewModels.Car;
using VelocityAutos.Web.ViewModels.FuelType;
using VelocityAutos.Web.ViewModels.SelectViewModels;

namespace VelocityAutos.Web.ViewModels.Post
{
    public class PostDetailsViewModel
    {
       public CarDetailsViewModel Car { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string SellerName { get; set; } = null!;

        public string SellerPhoneNumber { get; set; } = null!;

        public string? SellerEmailAddress { get; set; } = null!;
    }
}
