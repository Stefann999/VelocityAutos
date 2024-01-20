using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityAutos.Data.Models
{
    public class FuelType
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FuelTypeName { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
