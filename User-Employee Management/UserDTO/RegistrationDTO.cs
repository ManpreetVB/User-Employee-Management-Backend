using System.ComponentModel.DataAnnotations;

namespace User_Employee_Management.DTO
{
    public class RegistrationDTO
    {
        [Required]
        [MinLength(3)]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}
