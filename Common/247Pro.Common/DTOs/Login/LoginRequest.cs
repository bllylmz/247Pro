using System.ComponentModel.DataAnnotations;

namespace _247Pro.Common.DTOs.Login
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
