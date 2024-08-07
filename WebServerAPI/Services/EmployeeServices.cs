using System.Collections.Generic;
using System.Linq;
using WebServerAPI.Data;
using WebServerAPI.DTOs;
using WebServerAPI.Models;

namespace WebServerAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<EmployeeDto> GetAllEmployees()
        {
            return _context.Employees
                .Select(e => new EmployeeDto{
                    EmployeeId = e.EmployeeId,
                    FullName = e.FullName,
                    Email = e.Email}).ToList();
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return null; 
            }
            else
            {
                return new EmployeeDto
                {
                    EmployeeId = employee.EmployeeId,
                    FullName = employee.FullName,
                    Email = employee.Email
                };
            }

        }

        public List<EmployeeDto> GetEmployeesByName(string name)
        {
            return _context.Employees.Where(e => e.FullName.StartsWith(name)).Select(e => new EmployeeDto
            {
                EmployeeId = e.EmployeeId,
                FullName = e.FullName,
                Email = e.Email
            }).ToList();
        }

        public List<EmployeeDto> GetEmployeesByEmail(string email)
        {
            return _context.Employees.Where(e => e.Email.StartsWith(email)).Select(e => new EmployeeDto
                {
                    EmployeeId = e.EmployeeId,
                    FullName = e.FullName,
                    Email = e.Email
                }).ToList();
        }

        public void AddEmployee(EmployeePostDto employeeDto)
        {
            var employee = new Employee
            {
                FullName = employeeDto.FullName,
                Email = employeeDto.Email
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(int id, EmployeePostDto employeeDto)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                employee.FullName = employeeDto.FullName;
                employee.Email = employeeDto.Email;

                _context.Employees.Update(employee);
                _context.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }


    }
}
