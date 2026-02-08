using User_Employee_Management.DAL;
using User_Employee_Management.Models;

namespace User_Employee_Management.BAL
{
    public class EmployeeBAL
    {
        private readonly EmployeeDAL employeeDAL;
        public EmployeeBAL(IConfiguration configuration)
        {
            employeeDAL = new EmployeeDAL(configuration);
        }

        public List<EmployeeDetails> GetAllEmployees()
        {
            return employeeDAL.GetAllEmployees();
        }
        public string AddEmployee(EmployeeDetails employeeDetails)
        {
            if (string.IsNullOrEmpty(employeeDetails.EmployeeName))
            {
                return "UserName is required";
            }
            if (string.IsNullOrEmpty(employeeDetails.Email))
            {
                return "Email is required";
            }
            return employeeDAL.AddEmployee(employeeDetails);
        }

    }
}
