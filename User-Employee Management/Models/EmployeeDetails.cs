namespace User_Employee_Management.Models
{
    public class EmployeeDetails
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int IsActive { get; set; }
    }
}
