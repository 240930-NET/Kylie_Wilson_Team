using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Data;

public class TasksRepo : ITasksRepo
{
    private readonly TasksContext _context;

    public TasksRepo(TasksContext context)
    {
        _context = context;
    }

    public List<ToDo> GetAllTasks()
    {
        return _context.ToDos.ToList();
    }
 
    public ToDo GetTasksById(int id)
    {
        return _context.ToDos.Find(id);
    }

    public void AddTask(ToDo todo)
    {
        _context.ToDos.Add(todo);
        _context.SaveChanges();
    }

    public void UpdateTask(ToDo todo)
    {
        _context.ToDos.Update(todo);
        _context.SaveChanges();
    }

    public void DeleteTask(ToDo todo)
    {
        _context.ToDos.Remove(todo);
        _context.SaveChanges();
    }
}