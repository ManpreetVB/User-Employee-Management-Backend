using System.Data.SqlClient;
using System.Data;
using User_Employee_Management.Models;

namespace User_Employee_Management.DAL
{
    public class EmployeeDAL
    {
        private readonly string _connection;

        public EmployeeDAL(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("Connection");
        }
        public List<EmployeeDetails> GetAllEmployees()
        {
            List<EmployeeDetails> list = new List<EmployeeDetails>();

            using (SqlConnection con = new SqlConnection(_connection))
            {
                SqlCommand cmd = new SqlCommand("dbo.sp_GetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new EmployeeDetails
                    {
                        EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                        EmployeeName = Convert.ToString(dr["EmployeeName"]),
                        Email = Convert.ToString(dr["Email"]),
                        ContactNumber = Convert.ToString(dr["ContactNumber"]),
                        Gender = Convert.ToString(dr["Gender"]),
                        Address = Convert.ToString(dr["Address"]),
                        Department = Convert.ToString(dr["Department"]),
                       Salary = Convert.ToInt32(dr["Salary"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
                        IsActive = Convert.ToInt32(dr["IsActive"])
                    });
                }
            }

            return list;
        }

        public string AddEmployee(EmployeeDetails employeeDetails)
        {
            string response = "";

            try
            {
                using (SqlConnection con = new SqlConnection(_connection))
                {
                    SqlCommand cmd = new SqlCommand("dbo.sp_AddNewEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeName", employeeDetails.EmployeeName);
                    cmd.Parameters.AddWithValue("@Email", employeeDetails.Email);
                    cmd.Parameters.AddWithValue("@ContactNumber", employeeDetails.ContactNumber);
                    cmd.Parameters.AddWithValue("@Gender", employeeDetails.Gender);
                    cmd.Parameters.AddWithValue("@Address", employeeDetails.Address);
                    cmd.Parameters.AddWithValue("@Department", employeeDetails.Department);
                    cmd.Parameters.AddWithValue("@Salary", employeeDetails.Salary);


                    SqlParameter outputParameter = new SqlParameter("@OutputMsg", SqlDbType.NVarChar, 100);
                    outputParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    response = outputParameter.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }
        public string UpdateEmployee(EmployeeDetails employeeDetails)
        {
            string response = "";

            try
            {
                using (SqlConnection con = new SqlConnection(_connection))
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeId", employeeDetails.EmployeeId);
                    cmd.Parameters.AddWithValue("@EmployeeName", employeeDetails.EmployeeName);
                    cmd.Parameters.AddWithValue("@Email", employeeDetails.Email);
                    cmd.Parameters.AddWithValue("@ContactNumber", employeeDetails.ContactNumber);
                    cmd.Parameters.AddWithValue("@Gender", employeeDetails.Gender);
                    cmd.Parameters.AddWithValue("@Address", employeeDetails.Address);
                    cmd.Parameters.AddWithValue("@Department", employeeDetails.Department);
                    cmd.Parameters.AddWithValue("@Salary", employeeDetails.Salary);
                    cmd.Parameters.AddWithValue("@IsActive", employeeDetails.IsActive);
                    SqlParameter outputParameter = new SqlParameter("@OutputMsg", SqlDbType.NVarChar, 100);
                    outputParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    response = outputParameter.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }

        public EmployeeDetails GetEmployeeById(int EmployeeID)
        {
            EmployeeDetails employee = new EmployeeDetails();
            using (SqlConnection con = new SqlConnection(_connection))
            {
                SqlCommand cmd = new SqlCommand("sp_GetByIdEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", EmployeeID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    employee.EmployeeId = Convert.ToInt32(dt.Rows[0]["EmployeeId"]);
                    employee.EmployeeName = Convert.ToString(dt.Rows[0]["EmployeeName"]);
                    employee.Email = Convert.ToString(dt.Rows[0]["Email"]);
                    employee.ContactNumber = Convert.ToString(dt.Rows[0]["ContactNumber"]);
                    employee.Gender = Convert.ToString(dt.Rows[0]["Gender"]);
                    employee.Address = Convert.ToString(dt.Rows[0]["Address"]);
                    employee.Department = Convert.ToString(dt.Rows[0]["Department"]);
                    employee.Salary = Convert.ToInt32(dt.Rows[0]["Salary"]);
                    employee.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    employee.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);

                }
                return employee;

            }


        }

        public string DeleteEmployee(int EmployeeID)
        {
            string response = "";

            try
            {
                using (SqlConnection con = new SqlConnection(_connection))
                {
                    SqlCommand cmd = new SqlCommand("sp_DeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeID",  EmployeeID);


                    SqlParameter outputParameter = new SqlParameter("@OutputMsg", SqlDbType.NVarChar, 100);
                    outputParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    response = outputParameter.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }


    }
}
