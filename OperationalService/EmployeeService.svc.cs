using OperationalService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OperationalService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        private readonly string connectionString = string.Empty;


        public EmployeeService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        }
        public ServiceResponse<Employee> AddEmployee(Employee emp)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Employees (Name, Department, Salary) OUTPUT INSERTED.Id VALUES (@Name, @Department, @Salary)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", emp.Name);
                    cmd.Parameters.AddWithValue("@Department", emp.Department);
                    cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                    conn.Open();
                    emp.Id = (int)cmd.ExecuteScalar();
                    return new ServiceResponse<Employee>
                    {
                        Success = true,
                        Message = "Employee added successfully.",
                        Data = emp
                    };

                }
            }
            catch (Exception ex)
            {

                return new ServiceResponse<Employee>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        public ServiceResponse<bool> DeleteEmployee(string id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<List<Employee>> GetAllEmployees()
        {
            var employees = new List<Employee>();

            try
            {
                using (SqlConnection conn= new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Employees";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        employees.Add(new Employee
                        {
                            Id = (int)reader["id"]  ,
                            Name = (string)reader["name"] ,
                            Department = (string)reader["Department"],
                            Salary = Convert.ToDecimal(reader["Salary"])
                        });
                    }
                }
                return new ServiceResponse<List<Employee>>
                {
                    Success = true,
                    Message = "All employees fetched.",
                    Data = employees
                };
            }
            catch (Exception ex)
            {

                return new ServiceResponse<List<Employee>>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        public ServiceResponse<Employee> GetEmployeeById(string id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<Employee> UpdateEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }
    }
}
