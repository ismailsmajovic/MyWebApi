/*using System;

namespace MyWebApi.Models
{
    public class Employee
    { 
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; } 
        public string Contact { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string Position { get; set; }
        public string Supervisor { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}\nIme: {FirstName}\nPrezime: {LastName}\nAdresa: {Address}\nKontakt: " +
                $"{Contact}\nDatum zaposlenja: {EmploymentDate.ToString("dd.MM.yyyy")}\nPozicija: " +
                $"{Position}\nNadređeni: {Supervisor}";
        }
    }
}*/

namespace MyWebApi.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string Position { get; set; }
    }
}
