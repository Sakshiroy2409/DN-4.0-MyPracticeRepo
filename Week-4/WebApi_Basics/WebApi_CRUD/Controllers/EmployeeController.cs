using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi_CRUD.Models;

namespace WebApi_CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // Hardcoded employee list for demo purposes
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Salary = 50000 },
            new Employee { Id = 2, Name = "Bob", Salary = 60000 }
        };

        // ✅ GET: api/employee
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(employees);
        }

        // ✅ PUT: api/employee/2
        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee updatedEmp)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var existing = employees.FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return BadRequest("Invalid employee id");

            existing.Name = updatedEmp.Name;
            existing.Salary = updatedEmp.Salary;

            return Ok(existing);
        }

        // ✅ DELETE: api/employee/2
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return BadRequest("Invalid employee id");

            employees.Remove(employee);
            return Ok("Employee deleted successfully");
        }

        // ✅ POST: api/employee
        [HttpPost]
        public ActionResult<Employee> AddEmployee([FromBody] Employee emp)
        {
            emp.Id = employees.Max(e => e.Id) + 1;
            employees.Add(emp);
            return Ok(emp);
        }
    }
}