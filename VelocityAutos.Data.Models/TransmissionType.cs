using System.ComponentModel.DataAnnotations;
using static VelocityAutos.Common.EntityValidationConstants.Car;

namespace VelocityAutos.Data.Models
{
    public class TransmissionType
    {
        public TransmissionType()
        {
            this.Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(TransmissionTypeMinLength)]
        [MaxLength(TransmissionTypeMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
