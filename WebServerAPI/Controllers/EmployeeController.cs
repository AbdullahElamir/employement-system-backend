using Microsoft.AspNetCore.Mvc;
using WebServerAPI.DTOs;
using WebServerAPI.Services;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetEmployee")]
        public IActionResult Get()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("GetEmployee/{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }
            return Ok(employee);
        }

        [HttpGet("GetEmployeeByQuery")]
        public IActionResult GetEmployeeByQuery([FromQuery] string? fullName, string? email)
        {
            List<EmployeeDto> employees = new List<EmployeeDto>();

            employees = _employeeService.GetAllEmployees();

            if (!string.IsNullOrEmpty(fullName))
            {
                employees = _employeeService.GetEmployeesByName(fullName);
            }
            else if (!string.IsNullOrEmpty(email))
            {
                employees = _employeeService.GetEmployeesByEmail(email);
            } 

            return Ok(employees);
        }

        [HttpPost("AddEmployee")]
        public IActionResult Post([FromBody] EmployeePostDto employee)
        {
            if (string.IsNullOrEmpty(employee.FullName) || string.IsNullOrEmpty(employee.Email))
            {
                return BadRequest("Employee name and email are required");
            }

            _employeeService.AddEmployee(employee);
            return Ok("Employee added successfully");
        }

        [HttpPut("UpdateEmployee/{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeePostDto Uemployee)
        {
            if(string.IsNullOrEmpty(Uemployee.FullName) || string.IsNullOrEmpty(Uemployee.Email))
            {
                return BadRequest("Employee name and email are required");
            }

            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            _employeeService.UpdateEmployee(id, Uemployee);
            return Ok("Employee updated successfully");
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }
            else
            {
                _employeeService.DeleteEmployee(id);
                return Ok("Employee deleted successfully");
            }
        }
    }
}
