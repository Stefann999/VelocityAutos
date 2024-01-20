using System.ComponentModel.DataAnnotations.Schema;

namespace VelocityAutos.Data.Models
{
    public class CarExtra
    {
        [ForeignKey(nameof(Car))]
        public Guid CarId { get; set; }

        public Car Car { get; set; } = null!;

        [ForeignKey(nameof(Extra))]
        public Guid ExtraId { get; set; }

        public Extra Extra { get; set; } = null!;
    }
}
