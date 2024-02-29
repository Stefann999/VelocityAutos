using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VelocityAutos.Data.Models
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string ImagePath { get; set; } = null!;

        [ForeignKey(nameof(Car))]
        public Guid CarId { get; set; }

        [Required]
        public Car Car { get; set; } = null!;
    }
}
