
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;
using System.Collections.Generic;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Performance>> GetPerformances()
        {
            
            List<Performance> performances = new List<Performance>
            {
                new Performance
                {
                    EmployeeId = 1,
                    Rating = "9/10",
                    Goals = "Postignuti",
                    Comment = "Izuzetan rad u poslednjem kvartalu"
                },
                new Performance
                {
                    EmployeeId = 2,
                    Rating = "8/10",
                    Goals = "Delimično postignuti",
                    Comment = "Potrebno unapređenje u komunikaciji sa kolegama"
                }
            };

            return performances;
        }
    }
}
