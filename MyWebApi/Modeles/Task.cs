using System;

namespace MyWebApi.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
        public Employee AssignedTo { get; set; }

        public TaskItem(int id, string taskName, string description, string priority, DateTime deadline, Employee assignedTo)
        {
            Id = id;
            TaskName = taskName;
            Description = description;
            Priority = priority;
            Deadline = deadline;
            Status = "Pending";
            AssignedTo = assignedTo;
        }
    }
}
