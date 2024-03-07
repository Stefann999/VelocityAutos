using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VelocityAutos.Data.Models
{
    public class Post
    {
        public Post()
        {
            IsActive = true;
        }

        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? UpdatedOn { get; set;}

        public bool IsActive { get; set; }

        [Required]
        public Guid SellerId { get; set; }

        public ApplicationUser Seller { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Car))]
        public Guid CarId { get; set; }

        public Car Car { get; set; } = null!;

        [Required]
        public string SellerFirstName { get; set; } = null!;

        [Required]
        public string SellerLastName { get; set; } = null!;

        [Required]
        public string SellerPhoneNumber { get; set; } = null!;

        public string? SellerEmailAddress { get; set; }
    }
}
