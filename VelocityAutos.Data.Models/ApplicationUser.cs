using Microsoft.AspNetCore.Identity;

namespace VelocityAutos.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = new Guid();
            this.OwnerdCars = new HashSet<Car>();
            this.FavouriteCars = new HashSet<Car>();
        }

        public virtual ICollection<Car> OwnerdCars { get; set; } = null!;

        public virtual ICollection<Car> FavouriteCars { get; set; } = null!;
    }
}