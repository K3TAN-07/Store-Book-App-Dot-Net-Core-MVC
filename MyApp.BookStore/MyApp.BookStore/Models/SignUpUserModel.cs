using System.ComponentModel.DataAnnotations;

namespace MyApp.BookStore.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Please enter your email")]
        [Display(Name ="Email address")]
        [EmailAddress(ErrorMessage ="Please enter valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter strong password")]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
