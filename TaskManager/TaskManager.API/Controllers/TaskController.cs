using TaskManager.API.Service;
using TaskManager.Models;
using TaskManager.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.API;

[ApiController]
[Route("api/[controller]")]
public class TaskController : Controller
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public IActionResult GetTasks()
    {
        try
        {
            return Ok(_taskService.GetAllTasks());
        }
        catch (Exception err)
        {
            return StatusCode(500, err.Message);
        }
    }

    [HttpGet("getTaskById/{id}")]
    public IActionResult GetTaskById(int id)
    {
        try
        {
            ToDo searchedTask = _taskService.GetTasksById(id);

            // Check if the task was found
            if (searchedTask == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }

            return Ok(searchedTask);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("addNewTask")]
    public IActionResult AddNewTask([FromBody] ToDoDto task)
    {
        try
        {
            // Validate task properties
            if (string.IsNullOrEmpty(task.Title))
            {
                return BadRequest("Title is required.");
            }

            // Check if Due is provided
            if (string.IsNullOrEmpty(task.Due))
            {
                return BadRequest("Due date is required.");
            }

            _taskService.AddTask(task);
            return Ok(task);
        }
        catch (Exception e)
        {
            return BadRequest($"Could not add task: {e.Message}");
        }
    }

    [HttpPut("editTask/{id}")]
    public async Task<IActionResult> EditTask(int id, [FromBody] ToDoDto updatedTask)
    {
        try
        {
            // Validate input
            if (string.IsNullOrEmpty(updatedTask.Title))
            {
                return BadRequest("Title is required.");
            }

            // Check if Due is provided
            if (string.IsNullOrEmpty(updatedTask.Due))
            {
                return BadRequest("Due date is required.");
            }

            // Attempt to update the task
            var existingTask = _taskService.GetTasksById(id);
            

            // Update the task properties
            existingTask.Title = updatedTask.Title;
            existingTask.Due = updatedTask.Due; // Assuming Due is a string, adjust as necessary

             _taskService.UpdateTask(existingTask);

            return Ok(existingTask);
        }
        catch (Exception e)
        {
            return BadRequest($"Could not update task: {e.Message}");
        }
    }

    [HttpDelete("deleteTask/{id}")]
    public IActionResult DeleteTask(int id)
    {
        try
        {
            _taskService.DeleteTask(id);
            return Ok("Task deleted");
        }
        catch (Exception e)
        {
            return BadRequest($"Could not delete task: {e.Message}");
        }
    }
}