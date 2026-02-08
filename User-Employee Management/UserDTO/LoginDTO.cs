using System.ComponentModel.DataAnnotations;

namespace User_Employee_Management.DTO
{
    public class LoginDTO
    {
        [Required]
        [MinLength(3)]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }
    }
}
