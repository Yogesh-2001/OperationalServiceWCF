using OperationalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace OperationalService
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/create-employee", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ServiceResponse<Employee> AddEmployee(Employee emp);

        [OperationContract]
        [WebGet(UriTemplate = "/employees/{id}", ResponseFormat = WebMessageFormat.Json)]
        ServiceResponse<Employee> GetEmployeeById(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/employees", ResponseFormat = WebMessageFormat.Json)]
        ServiceResponse<List<Employee>> GetAllEmployees();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/update-employee", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ServiceResponse<Employee> UpdateEmployee(Employee emp);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/delete-employee/{id}", ResponseFormat = WebMessageFormat.Json)]
        ServiceResponse<bool> DeleteEmployee(string id);
    }
}
