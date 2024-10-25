using TaskManager.Data;
using TaskManager.Models;
using TaskManager.Models.DTO;

namespace TaskManager.API.Service;

public interface ITaskService
{
    List<ToDo> GetAllTasks();
    ToDo GetTasksById(int id);

    void AddTask(ToDoDto todo);

    ToDo UpdateTask(ToDo todo);

    string DeleteTask(int id);
}