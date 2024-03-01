using Microsoft.AspNetCore.Identity;

namespace VelocityAutos.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.OwnedPosts = new HashSet<Post>();
            this.FavouriteCars = new HashSet<Car>();
        }

        public virtual ICollection<Post> OwnedPosts { get; set; } = null!;

        public virtual ICollection<Car> FavouriteCars { get; set; } = null!;
    }
}