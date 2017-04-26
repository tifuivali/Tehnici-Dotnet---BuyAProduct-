using System.ComponentModel.DataAnnotations;

namespace Store.Web.Models
{
    public class UserAccountViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(256, ErrorMessage = "First name must be smaller than 256 characters.")]
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(256, ErrorMessage = "Last name must be smaller than 256 characters.")]
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [MaxLength(256, ErrorMessage = "Email must be smaller than 256 characters.")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email.")]
        public string Email { get; set; }

        [Display(Name = "Address")]
        [MaxLength(256, ErrorMessage = "Address must be smaller than 256 characters.")]
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Display(Name = "Phone")]
        [Phone(ErrorMessage = "Phone number is invalid.")]
        [MaxLength(10, ErrorMessage = "Phone must be smaller or equal with 10 characters.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be larger than 6 characters.")]
        [MaxLength(30, ErrorMessage = "Password must be smaller than 30 characters.")]
        public string Password { get; set; }
    }
}