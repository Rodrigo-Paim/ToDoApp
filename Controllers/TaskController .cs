using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.Controllers
{
    // Controllers/TaskController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetTasks() => Ok(_taskService.GetAll());

        [HttpPost]
        public IActionResult AddTask([FromBody] TaskDto dto)
        {
            _taskService.Add(new Models.Task { Title = dto.Title, Description = dto.Description });
            return Ok("Task added.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskDto dto)
        {
            if (!_taskService.Update(id, dto.Title, dto.Description))
                return NotFound("Task not found.");
            return Ok("Task updated.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            if (!_taskService.Remove(id)) return NotFound("Task not found.");
            return Ok("Task deleted.");
        }
    }

    // TaskDto
    public class TaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

}
