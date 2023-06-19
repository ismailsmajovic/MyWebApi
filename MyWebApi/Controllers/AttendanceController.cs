
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private Attendance attendance;

        public AttendanceController()
        {
            attendance = new Attendance();
        }

        [HttpPost("arrival/{employeeId}")]
        public IActionResult RecordArrival(int employeeId)
        {
            attendance.RecordArrival(employeeId);
            return Ok("Employee arrival recorded.");
        }

        [HttpPost("departure/{employeeId}")]
        public IActionResult RecordDeparture(int employeeId)
        {
            attendance.RecordDeparture(employeeId);
            return Ok("Employee departure recorded.");
        }

        [HttpGet("workinghours/{employeeId}/{startDate}/{endDate}")]
        public IActionResult CalculateTotalWorkingHours(int employeeId, DateTime startDate, DateTime endDate)
        {
            TimeSpan totalWorkingHours = attendance.CalculateTotalWorkingHours(employeeId, startDate, endDate);
            return Ok($"Total working hours for employee {employeeId} between {startDate.ToShortDateString()}" +
                $" and {endDate.ToShortDateString()}: {totalWorkingHours.TotalHours} hours");
        }

        [HttpGet("report/{date}")]
        public IActionResult GenerateAttendanceReport(DateTime date)
        {
            attendance.GenerateAttendanceReport(date);
            return Ok();
        }

        [HttpGet("search/{date}/{status}")]
        public IActionResult SearchAttendance(DateTime date, string status)
        {
            List<int> employees = attendance.SearchAttendance(date, status);
            return Ok(employees);
        }
    }
}