using Microsoft.AspNetCore.Identity;

namespace VelocityAutos.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            OwnerdCars = new List<Car>();
            FavouriteCars = new List<Car>();
        }

        public virtual ICollection<Car> OwnerdCars { get; set; } = null!;

        public virtual ICollection<Car> FavouriteCars { get; set; } = null!;
    }
}