using System.ComponentModel.DataAnnotations;

namespace VelocityAutos.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<Car> Cars { get; set; }
    }
}
