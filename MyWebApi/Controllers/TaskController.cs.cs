using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;
using System;
using System.Collections.Generic;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private List<TaskItem> tasks;

        public TaskController()
        {
            tasks = new List<TaskItem>();
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult AddTask(TaskItem task)
        {
            tasks.Add(task);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveTask(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            tasks.Remove(task);
            return NoContent();
        }
    }
}






/*
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private List<TaskItem> tasks;

        public TaskController()
        {
            tasks = new List<TaskItem>();
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult AddTask(TaskItem task)
        {
            tasks.Add(task);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveTask(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            tasks.Remove(task);
            return NoContent();
        }
    }
}

*/