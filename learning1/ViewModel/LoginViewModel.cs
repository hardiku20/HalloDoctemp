using System.ComponentModel.DataAnnotations;

namespace learning1.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username field is required")]
        [RegularExpression(@"^[\w!#$%&'*+/=?^`{|}~-]+(?:\.[\w!#$%&'*+/=?^`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}$"
, ErrorMessage = "Invalid Username,Enter Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        public string Password { get; set; }
    }
}
