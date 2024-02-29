using System.ComponentModel.DataAnnotations;

namespace VelocityAutos.Data.Models
{
    public class Post
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? UpdatedOn { get; set;}

        public bool IsDeleted { get; set; }

        [Required]
        public string SellerId { get; set; } = null!;

        public ApplicationUser ApplicationUser { get; set; } = null!;

        public Guid CarId { get; set; }

        public Car Car { get; set; }

        [Required]
        public string SellerFirstName { get; set; } = null!;

        [Required]
        public string SellerLastName { get; set; } = null!;

        [Required]
        public string SellerPhoneNumber { get; set; } = null!;

        public string? SellerEmailAddress { get; set; }
    }
}
