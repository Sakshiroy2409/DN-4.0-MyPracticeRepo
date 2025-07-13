using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi_CustomModels.Models;
using WebApi_CustomModels.Filters;

namespace WebApi_CustomModels.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(CustomAuthFilter))] // ✅ Authorization filter applied here
    public class EmployeeController : ControllerBase
    {
        // Private method to return hardcoded employee data
        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    Salary = 50000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Department = new Department { Id = 101, Name = "IT" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = "SQL" }
                    }
                }
            };
        }

        // ✅ GET: /api/employee/getall
        [HttpGet("getall")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> GetStandard()
        {
            return Ok(GetStandardEmployeeList());
        }

        // ✅ GET: /api/employee/throw → triggers CustomExceptionFilter
        [HttpGet("throw")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ThrowError()
        {
            throw new Exception("This is a test exception for filter");
        }
    }
}