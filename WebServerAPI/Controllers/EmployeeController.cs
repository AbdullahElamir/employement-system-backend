using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebServerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // In-memory data store for demonstration purposes
        // comment for the testing
        private static List<Employee> Employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Position = "Developer" },
            new Employee { Id = 2, Name = "Jane Smith", Position = "Manager" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return Ok(Employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = Employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            employee.Id = Employees.Count + 1;
            Employees.Add(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            var employee = Employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = updatedEmployee.Name;
            employee.Position = updatedEmployee.Position;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = Employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            Employees.Remove(employee);
            return NoContent();
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
    }
}
