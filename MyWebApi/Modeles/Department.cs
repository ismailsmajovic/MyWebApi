
using System.Collections.Generic;

namespace MyWebApi.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int ParentDepartmentId { get; set; }
        public List<int> EmployeeIds { get; set; }

        public Department(int departmentId, string departmentName, int parentDepartmentId)
        {
            DepartmentId = departmentId;
            DepartmentName = departmentName;
            ParentDepartmentId = parentDepartmentId;
            EmployeeIds = new List<int>();
        }
    }
}

