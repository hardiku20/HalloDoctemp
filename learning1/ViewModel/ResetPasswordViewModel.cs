using System.ComponentModel.DataAnnotations;

namespace learning1.ViewModel
{
    public class ResetPasswordViewModel
    {
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }

    }
}
