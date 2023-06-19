using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayrollController : ControllerBase
    {
        private readonly List<Employee> _employees;
        private readonly List<Payroll> _payrolls;

        public PayrollController()
        {
           
            _employees = new List<Employee>
            {
                
                new Employee { Id = 1, FirstName = "John", LastName = "Smith" },
                new Employee { Id = 2, FirstName = "Emily", LastName = "Johnson" }
            };

            _payrolls = new List<Payroll>
            {
                // Dodajte informacije o obračunima plata TO JE ONO NOVAC ==== SRECA!
                new Payroll { Id = 1, EmployeeId = 1, Salary = 5000, Tax = 1000, Contributions = 500, Bonus = 100 },
                new Payroll { Id = 2, EmployeeId = 2, Salary = 6000, Tax = 1200, Contributions = 600, Bonus = 200 }
            };
        }

        [HttpGet]
        public ActionResult<IEnumerable<Payroll>> GetPayrolls()
        {
            return Ok(_payrolls);
        }

        [HttpGet("{id}")]
        public ActionResult<Payroll> GetPayroll(int id)
        {
            var payroll = _payrolls.Find(p => p.Id == id);

            if (payroll == null)
            {
                return NotFound();
            }

            return Ok(payroll);
        }
    }
}
