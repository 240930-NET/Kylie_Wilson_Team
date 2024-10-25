using TaskManager.Data;
using TaskManager.Models;
using TaskManager.Models.DTO; 

namespace TaskManager.API.Service;

public interface ITaskService {
    public List<ToDo> GetAllTasks();
    public ToDo GetTasksById(int id);

    public string AddTask(ToDoDto todo); 

    public ToDo UpdateTask(ToDo todo);

    public string DeleteTask(int id); 
}