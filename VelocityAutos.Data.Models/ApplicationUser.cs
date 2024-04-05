using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static VelocityAutos.Common.GeneralApplicationConstants;
using static VelocityAutos.Common.ErrorConstants;
using static VelocityAutos.Common.EntityValidationConstants.User;

namespace VelocityAutos.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.FavouriteCars = new HashSet<Car>();
        }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [MaxLength(UserFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [MaxLength(UserLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Car> FavouriteCars { get; set; } = null!;
    }
}