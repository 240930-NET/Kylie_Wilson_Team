using Microsoft.EntityFrameworkCore;
namespace TaskManager.Data;

using Microsoft.Identity.Client;
using  TaskManager.Models;
public class TasksContext : DbContext
{
  public  DbSet<ToDo> ToDos {get; set;}
}
