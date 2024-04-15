using System.ComponentModel.DataAnnotations;

namespace VelocityAutos.Web.ViewModels.User
{
    public class UserMakeAdminViewModel
    {
        public string Id { get; set; } = null!;

        [Display(Name = "Full Name")]
        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public bool IsAdmin { get; set; }
    }
}
