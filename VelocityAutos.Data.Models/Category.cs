using System.ComponentModel.DataAnnotations;
using static VelocityAutos.Common.EntityValidationConstants.Category;

namespace VelocityAutos.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Cars = new HashSet<Car>();
        }

        public Guid Id { get; init; }

        [Required]
        [MinLength(CategoryNameMinLength)]
        [MaxLength(CategoryNameMaxLength)]
        public string CategoryName { get; set; } = null!;

        public ICollection<Car> Cars { get; set; }
    }
}
