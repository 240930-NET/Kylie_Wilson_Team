using AutoMapper;
using TaskManager.Data;
using TaskManager.Models;
using TaskManager.Models.DTO;

namespace TaskManager.API.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITasksRepo _tasksRepo;

        private readonly IMapper _mapper;

        public TaskService(ITasksRepo tasksRepo, IMapper mapper)
        {
            _tasksRepo = tasksRepo;
            _mapper = mapper;
        }

        public List<ToDo> GetAllTasks()
        {
            List<ToDo> result = _tasksRepo.GetAllTasks();
            return result.Count == 0 ? new List<ToDo>() : result;
        }

        public ToDo GetTasksById(int id)
        {
            return _tasksRepo.GetTasksById(id);
        }

        public void AddTask(ToDoDto taskDto)
        {
            if (taskDto == null)
            {
                throw new ArgumentNullException(nameof(taskDto), "Task cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(taskDto.Title))
            {
                throw new Exception("Invalid Task. Please check title!");
            }

            var todo = _mapper.Map<ToDo>(taskDto);
            _tasksRepo.AddTask(todo);
            Console.WriteLine($"Task '{todo.Title}' added successfully!"); // Logging for success
        }

        public ToDo UpdateTask(ToDo todo)
        {
            ToDo existingTask = _tasksRepo.GetTasksById(todo.Id);
            if (existingTask == null)
            {
                throw new Exception("Invalid Task. Does not exist.");
            }

            if (string.IsNullOrEmpty(todo.Title))
            {
                throw new Exception("Invalid Task. Please check title!");
            }

            existingTask.Title = todo.Title;
            existingTask.Due = todo.Due;
            existingTask.State = todo.State;

            _tasksRepo.UpdateTask(existingTask);
            return existingTask;
        }

        public string DeleteTask(int id)
        {
            ToDo taskToDelete = _tasksRepo.GetTasksById(id);
            if (taskToDelete == null)
            {
                throw new Exception($"Task with id {id} does not exist");
            }

            _tasksRepo.DeleteTask(taskToDelete);
            return $"Task with id {id} deleted successfully!";
        }
    }
}