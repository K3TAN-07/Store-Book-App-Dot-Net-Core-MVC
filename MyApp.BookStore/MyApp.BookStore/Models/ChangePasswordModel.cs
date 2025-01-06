using System.ComponentModel.DataAnnotations;

namespace MyApp.BookStore.Models
{
    public class ChangePasswordModel
    {
        [Required, DataType(DataType.Password), Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required, DataType(DataType.Password), Display(Name ="New Password")]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage ="Confirm new password doest not match with new password")]
        public string ConfirmNewPassword { get; set; }
    }
}
