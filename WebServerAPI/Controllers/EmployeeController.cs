using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebServerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // In-memory data for demonstration purposes
        private static readonly List<Employee> Employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Position = "Developer" },
            new Employee { Id = 2, Name = "Jane Smith", Position = "Manager" }
        };

        // GET: api/employee
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(Employees);
        }

        // GET: api/employee/{id}
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = Employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
