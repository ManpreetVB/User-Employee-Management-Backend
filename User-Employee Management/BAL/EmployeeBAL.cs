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
                return "EmployeeName is required";
            }
            if (string.IsNullOrEmpty(employeeDetails.Email))
            {
                return "Email is required";
            }
            return employeeDAL.AddEmployee(employeeDetails);
        }

        public string UpdateEmployee(EmployeeDetails employeeDetails)
        {
            if (string.IsNullOrEmpty(employeeDetails.EmployeeName))
                return "EmployeeName is required";

            if (string.IsNullOrEmpty(employeeDetails.Email))
                return "Email is required";

            return employeeDAL.UpdateEmployee(employeeDetails);
        }


        public EmployeeDetails GetEmployeeById(int employeeId)
        {
            return employeeDAL.GetEmployeeById(employeeId);
        }

        public string DeleteEmployee(int employeeId)
        {
            return employeeDAL.DeleteEmployee(employeeId);
        }


    }
}
