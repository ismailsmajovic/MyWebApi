using System;

namespace MyWebApi.Models
{
    public class Training
    {
        public string TrainingName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan Duration => EndDate - StartDate; 
        public int Rating { get; set; }
        public string Certificate { get; set; }
        public decimal TrainingCost { get; set; }
        public string Location { get; set; }
    }
}
