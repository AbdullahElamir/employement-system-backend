using System.Collections.Generic;
using System.Linq;
using WebServerAPI.DTOs;

namespace WebServerAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<EmployeeDto> _employees;

        public EmployeeService()
        {
            // Initialize with some sample data
            _employees = new List<EmployeeDto>
            {
                new EmployeeDto { EmployeeId = 1, FullName = "John Doe", Email = "john.doe@gmail.com" },
                new EmployeeDto { EmployeeId = 2, FullName = "Jane Smith", Email = "jane.smith@gmail.com" },
                new EmployeeDto { EmployeeId = 3, FullName = "Michael Brown", Email = "michael.brown@gmail.com" },
                new EmployeeDto { EmployeeId = 4, FullName = "Emily Johnson", Email = "emily.johnson@gmail.com" },
                new EmployeeDto { EmployeeId = 5, FullName = "David Wilson", Email = "david.wilson@gmail.com" }
            };
        }

        public List<EmployeeDto> GetAllEmployees()
        {
            return _employees;
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            return _employees.SingleOrDefault(e => e.EmployeeId == id);
        }

        public List<EmployeeDto> GetEmployeesByName(string name)
        {
            return _employees.Where(e => e.FullName.StartsWith(name)).ToList();
        }

        public List<EmployeeDto> GetEmployeesByEmail(string email)
        {
            return _employees.Where(e => e.Email.StartsWith(email)).ToList();
        }

        public void AddEmployee(EmployeePostDto employee)
        {
            var newEmployee = new EmployeeDto
            {
                EmployeeId = (_employees.Count == 0 ? 1 : (_employees.Max(e => e.EmployeeId) + 1)),
                FullName = employee.FullName,
                Email = employee.Email
            };

            _employees.Add(newEmployee);
        }
    }
}
