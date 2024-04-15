using System.ComponentModel.DataAnnotations;

namespace VelocityAutos.Data.Models
{
    public class FuelType
    {
        public FuelType()
        {
            this.Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; set; }
    }
}
