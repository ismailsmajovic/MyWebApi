using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveController : ControllerBase
    {
        private List<Leave> leaveList;

        public LeaveController() 
        {
            
            leaveList = new List<Leave>();

            
            Leave johnSmithLeave = new Leave(1, 1, 20, 15);
            leaveList.Add(johnSmithLeave);

           
            Leave emilyJohnsonLeave = new Leave(2, 2, 25, 10);
            leaveList.Add(emilyJohnsonLeave);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Leave>> GetLeaves()
        {
            return Ok(leaveList);
        }

        [HttpGet("{id}")]
        public ActionResult<Leave> GetLeave(int id)
        {
            var leave = leaveList.Find(l => l.Id == id);
            if (leave == null)
            {
                return NotFound();
            }
            return Ok(leave);
        }

        [HttpPost]
        public ActionResult<Leave> CreateLeave(Leave leave)
        {
            // Generisanje ID-a za novi odmor to je ono kad ne radis nista i PIjes KAZU U HOUSE, PARDON VINO  :-)
            int newId = leaveList.Count + 1;
            leave.Id = newId;

            
            leaveList.Add(leave);

            return CreatedAtAction(nameof(GetLeave), new { id = leave.Id }, leave);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLeave(int id, Leave updatedLeave)
        {
            var leave = leaveList.Find(l => l.Id == id);
            if (leave == null)
            {
                return NotFound();
            }

           
            leave.TotalDays = updatedLeave.TotalDays;
            leave.UsedDays = updatedLeave.UsedDays;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLeave(int id)
        {
            var leave = leaveList.Find(l => l.Id == id);
            if (leave == null)
            {
                return NotFound();
            }

           
            leaveList.Remove(leave);

            return NoContent();
        }
    }
}
