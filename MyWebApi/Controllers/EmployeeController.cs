/*using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MyWebApi.Models;


namespace MyWebApi.Controllers
{ 
    [ApiController] 
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    { 
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                Address = "123 Main Street",
                Contact = "john.smith@example.com",
                EmploymentDate = new DateTime(2019, 1, 1),
                Position = "Softverski inženjer",
                Supervisor = "Jane Johnson"
            },
            new Employee
            {
                Id = 2,
                FirstName = "Emily",
                LastName = "Johnson",
                Address = "456 Oak Avenue",
                Contact = "emily.johnson@example.com",
                EmploymentDate = new DateTime(2020, 2, 1),
                Position = "Finansijski analitičar",
                Supervisor = "Mark Davis"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
    }
}
*/

using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;
using System.Collections.Generic;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private List<Employee> employees;

        public EmployeeController()
        {
            employees = new List<Employee>();
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            // Generisanje jedinstvenog ID-a za zaposlenog
            employee.EmployeeId = GenerateEmployeeId();

            // Dodavanje zaposlenog u listu
            employees.Add(employee);

            return Ok(employee);
        }

        private static int EmployeeIdCount = 0;

        private static int GenerateEmployeeId()
        {
            // Logika za generisanje jedinstvenog ID-a za zaposlenog
            EmployeeIdCount++;
            return EmployeeIdCount;
        }
    }
}
