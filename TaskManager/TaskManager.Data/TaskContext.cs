using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Data
{
    public class TasksContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }

        public TasksContext(DbContextOptions<TasksContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDo>().HasData(
                new ToDo
                {
                    Id = 1,
                    Title = "Complete Project Proposal",
                    Due = "10/30/24 12:05 PM", // This will still work as DateTime is stored correctly
                    State = "Not Started"
                },
                new ToDo
                {
                    Id = 2,
                    Title = "Review Code Changes",
                    Due = "10/28/24 2:05 PM", // Same here
                    State = "In Progress"
                }
            );
        }
    }
}