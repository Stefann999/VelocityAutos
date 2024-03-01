using System.ComponentModel.DataAnnotations;
using VelocityAutos.Web.ViewModels.Car;
using static VelocityAutos.Common.EntityValidationConstants.Post;
using static VelocityAutos.Common.ErrorConstants;

namespace VelocityAutos.Web.ViewModels.Post
{
    public class PostFormModel
    {
        [Required]
        public CarFormModel Car { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(
            SellerFirstNameMaxLength,
            MinimumLength = SellerFirstNameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Seller First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(
           SellerLastNameMaxLength,
           MinimumLength = SellerLastNameMinLength,
           ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Seller Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(
           SellerFirstNameMaxLength,
           MinimumLength = SellerFirstNameMinLength,
           ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Seller Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [RegularExpression(SellerEmailAddressRegex, ErrorMessage = InvalidEmailAddressMessage)]
        [Display(Name = "Seller First Name")]
        public string EmailAddress { get; set; }
    }
}
