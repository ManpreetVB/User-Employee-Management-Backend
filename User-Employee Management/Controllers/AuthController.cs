using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_Employee_Management.BAL;
using User_Employee_Management.DTO;
using User_Employee_Management.Models;

namespace User_Employee_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserBAL userBAL;
        public AuthController(UserBAL BAL)
        {
            userBAL = BAL;
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            UserDetails userDetails = new UserDetails();

            userDetails.Email = loginDTO.Email;
            userDetails.Password = loginDTO.Password;

            return Ok(userBAL.LoginUser(userDetails));
        }
        [HttpPost]
        [Route("Registration")]
        public IActionResult Registration(RegistrationDTO registrationDTO)
        {
            UserDetails userDetails = new UserDetails();
            userDetails.UserName = registrationDTO.UserName;
            userDetails.Email = registrationDTO.Email;
            userDetails.Password = registrationDTO.Password;
            userDetails.Password = registrationDTO.Password;
            userDetails.Gender = registrationDTO.Gender;
            userDetails.Address = registrationDTO.Address;

            return Ok(userBAL.RegisterUser(userDetails));
        }
    }
}
