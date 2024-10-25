using System.Reflection.Metadata.Ecma335;
using TaskManager.Models;

namespace TaskManager.Data;
public interface ITasksRepo {
    public List<ToDo> GetAllTasks();
     
    public ToDo GetTasksById(int id);

    //Add task
    public void AddTask(ToDo todo);

    //Delete task
   public void DeleteTask(ToDo todo);
    

    //Update task
    public void UpdateTask(ToDo todo);
} 