using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static VelocityAutos.Common.GeneralApplicationConstants;

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
        [ForeignKey(nameof(Seller))]
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

        [Required]
        public string SellerEmailAddress { get; set; }
    }
}
