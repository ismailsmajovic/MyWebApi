using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private List<Department> departments;

        public DepartmentController()
        {
            departments = new List<Department>();
        }

        [HttpGet]
        public ActionResult GetAllDepartments()
        {
            return Ok(departments);
        }

        [HttpGet("{departmentId}")]
        public ActionResult GetDepartmentById(int departmentId)
        {
            var department = departments.FirstOrDefault(d => d.DepartmentId == departmentId);
            if (department != null)
            {
                return Ok(department);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{departmentId}/employees")]
        public ActionResult GetEmployeesByDepartmentId(int departmentId)
        {
            var department = departments.FirstOrDefault(d => d.DepartmentId == departmentId);
            if (department != null)
            {
                var employeeIds = department.EmployeeIds;
               
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult CreateDepartment([FromBody] Department department)
        {
            departments.Add(department);
            return Ok();
        }

        [HttpPut("{departmentId}")]
        public ActionResult UpdateDepartment(int departmentId, [FromBody] Department department)
        {
            var existingDepartment = departments.FirstOrDefault(d => d.DepartmentId == departmentId);
            if (existingDepartment != null)
            {
                existingDepartment.DepartmentName = department.DepartmentName;
                existingDepartment.ParentDepartmentId = department.ParentDepartmentId;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{departmentId}")]
        public ActionResult DeleteDepartment(int departmentId)
        {
            var department = departments.FirstOrDefault(d => d.DepartmentId == departmentId);
            if (department != null)
            {
                departments.Remove(department);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
