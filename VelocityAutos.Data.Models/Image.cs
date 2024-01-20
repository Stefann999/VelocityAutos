using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VelocityAutos.Data.Models
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }

        public string ImagePath { get; set; } = null!;

        [ForeignKey(nameof(Car))]
        public Guid CarId { get; set; }

        public Car Car { get; set; } = null!;
    }
}
