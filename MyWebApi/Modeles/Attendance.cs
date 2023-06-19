
using System;
using System.Collections.Generic;
using System.Linq;

public class AttendanceRecord
{
    public int EmployeeId { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }

    public AttendanceRecord(int employeeId, DateTime date, string status)
    {
        EmployeeId = employeeId;
        Date = date.Date;
        Status = status;
    }
}

public class Attendance
{
    private List<AttendanceRecord> attendanceRecords;

    public Attendance()
    {
        attendanceRecords = new List<AttendanceRecord>();
    }

    public void RecordArrival(int employeeId)
    {
        DateTime currentDate = DateTime.Today;

        if (!attendanceRecords.Any(r => r.EmployeeId == employeeId && r.Date == currentDate))
        {
            attendanceRecords.Add(new AttendanceRecord(employeeId, currentDate, "Arrived"));
            Console.WriteLine("Employee arrival recorded.");
        }
        else
        {
            Console.WriteLine("Employee already arrived today.");
        }
    }

    public void RecordDeparture(int employeeId)
    {
        DateTime currentDate = DateTime.Today;

        if (!attendanceRecords.Any(r => r.EmployeeId == employeeId && r.Date == currentDate))
        {
            attendanceRecords.Add(new AttendanceRecord(employeeId, currentDate, "Departed"));
            Console.WriteLine("Employee departure recorded.");
        }
        else
        {
            Console.WriteLine("Employee already departed today.");
        }
    }

    public TimeSpan CalculateTotalWorkingHours(int employeeId, DateTime startDate, DateTime endDate)
    {
        var filteredRecords = attendanceRecords
            .Where(r => r.EmployeeId == employeeId && r.Date >= startDate && r.Date <= endDate)
            .ToList();

        TimeSpan totalWorkingHours = TimeSpan.Zero;
        foreach (var record in filteredRecords)
        {
            if (record.Status == "Arrived")
            {
                DateTime departureTime = filteredRecords
                    .FirstOrDefault(r => r.EmployeeId == employeeId && r.Date == record.Date.AddDays(1) &&
                    r.Status == "Departed")?.Date ?? endDate.AddDays(1);

                TimeSpan workingHours = departureTime - record.Date;
                totalWorkingHours += workingHours;
            }
        }

        return totalWorkingHours;
    }

    public void GenerateAttendanceReport(DateTime date)
    {
        Console.WriteLine("Attendance Report for {0}", date.ToShortDateString());
        Console.WriteLine("-------------------------------------");

        var filteredRecords = attendanceRecords.Where(r => r.Date == date).ToList();

        foreach (var record in filteredRecords)
        {
            Console.WriteLine("Employee ID: {0}", record.EmployeeId);
            Console.WriteLine("Status: {0}", record.Status);
            Console.WriteLine();
        }
    }

    public List<int> SearchAttendance(DateTime date, string status)
    {
        var filteredRecords = attendanceRecords
            .Where(r => r.Date == date && r.Status == status)
            .Select(r => r.EmployeeId)
            .ToList();

        return filteredRecords;
    }
}