using System.Collections.Generic;
using WebServerAPI.DTOs;

namespace WebServerAPI.Services
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployeeById(int id);
        List<EmployeeDto> GetEmployeesByName(string name);
        List<EmployeeDto> GetEmployeesByEmail(string email);
        void AddEmployee(EmployeePostDto employee);
        void UpdateEmployee(int id, EmployeePostDto Uemployee);
        void DeleteEmployee(int id);
    }
}
