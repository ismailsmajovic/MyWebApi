
using System;
namespace MyWebApi.Models
{
    public class Performance
    {
        public int EmployeeId { get; set; }
        public string Rating { get; set; }
        public string Goals { get; set; }
        public string Comment { get; set; }

       /* public Performance(int employeeId, string rating, string goals, string comment)
        {

            EmployeeId = employeeId;
            Rating = rating;
            Goals = goals;
            Comment = comment;
        }
       */

    }
    
}
