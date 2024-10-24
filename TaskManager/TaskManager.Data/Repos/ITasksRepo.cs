using System.Reflection.Metadata.Ecma335;
using TaskManager.Models;




namespace TaskManager.Data;
public interface ITasksRepo {
    public List<ToDo> GetAllTasks();
     
    public ToDo GetTasksById(int id);

}