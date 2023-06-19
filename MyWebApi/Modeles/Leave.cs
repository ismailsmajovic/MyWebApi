using System;

namespace MyWebApi.Models
{
    public class Leave
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; } 
        public int TotalDays { get; set; }
        public int UsedDays { get; set; }
        public int RemainingDays => TotalDays - UsedDays;

        public Leave(int id, int employeeId, int totalDays, int usedDays)
        {
            Id = id;
            EmployeeId = employeeId;
            TotalDays = totalDays; 
            UsedDays = usedDays;
        }
    }
}
