using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_Employee_Management.BAL;
using User_Employee_Management.DTO;
using User_Employee_Management.Models;
using User_Employee_Management.NewFolder4;

namespace User_Employee_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeBAL employeeBAL;
        public EmployeeController(EmployeeBAL BAL)
        {
            employeeBAL = BAL;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(employeeBAL.GetAllEmployees());
        }
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDTO employeeDTO)
        {
            EmployeeDetails employeeDetails = new EmployeeDetails ();
            employeeDetails.EmployeeName = employeeDTO.EmployeeName;
            employeeDetails.Email = employeeDTO.Email;
            employeeDetails.ContactNumber = employeeDTO.ContactNumber;
            employeeDetails.Gender = employeeDTO.Gender;
            employeeDetails.Address = employeeDTO.Address;
            employeeDetails.Department = employeeDTO.Department;
            employeeDetails.Salary = employeeDTO.Salary;
            return Ok(employeeBAL.AddEmployee(employeeDetails));
        }

    }
}
