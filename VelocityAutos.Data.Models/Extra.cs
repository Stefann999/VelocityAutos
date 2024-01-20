using System.ComponentModel.DataAnnotations;

namespace VelocityAutos.Data.Models
{
    public class Extra
    {
        public Extra()
        {
            this.CarExtras = new HashSet<CarExtra>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public Guid TypeId { get; set; }

        public ExtraType ExtraType { get; set; } = null!;

        public virtual ICollection<CarExtra> CarExtras { get; set; }

    }
}
