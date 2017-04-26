using System.ComponentModel.DataAnnotations;

namespace Store.Web.Models
{
    public class UserLoginAccountViewModel
    { 
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6,ErrorMessage = "Password must be larger than 6 characters.")]
        [MaxLength(30,ErrorMessage = "Password must be smaller than 30 characters.")]
        public string Password { get; set; }
    }
}