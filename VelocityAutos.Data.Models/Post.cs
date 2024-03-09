using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static VelocityAutos.Common.EntityValidationConstants.Post;

namespace VelocityAutos.Data.Models
{
    public class Post
    {
        public Post()
        {
            IsActive = true;
        }

        public Guid Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = MyDateTimeFormat)]
        public DateTime CreatedOn { get; set; }

        [DisplayFormat(DataFormatString = MyDateTimeFormat)]
        public DateTime? DeletedOn { get; set; }

        [DisplayFormat(DataFormatString = MyDateTimeFormat)]
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
        [MinLength(SellerFirstNameMinLength)]
        [MaxLength(SellerFirstNameMaxLength)]
        public string SellerFirstName { get; set; } = null!;

        [Required]
        [MinLength(SellerLastNameMinLength)]
        [MaxLength(SellerLastNameMaxLength)]
        public string SellerLastName { get; set; } = null!;

        [Required]
        [MinLength(SellerPhoneNumberMinLength)]
        [MaxLength(SellerPhoneNumberMaxLength)]
        public string SellerPhoneNumber { get; set; } = null!;

        [RegularExpression(SellerEmailAddressRegex)]
        public string? SellerEmailAddress { get; set; }
    }
}
