using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VelocityAutos.Data.Models
{
    public class UserCar
    {
        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Car))]
        public Guid CarId { get; set; }

        public Car Car { get; set; } = null!;
    }
}
