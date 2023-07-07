using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Controllers
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User name  required")]
        public string? UserName { get; set; }


        [Required(ErrorMessage = "Password required")]
        public string? Password { get; set; }
    }
}
