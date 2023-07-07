using System.ComponentModel.DataAnnotations;

namespace JWTAuth.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="UserName Must not be empty")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email Must not be empty")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password Must not be empty")]
        public string? Password { get; set; }
    }
}
