using Moq;
using TaskManager.API.Service;
using TaskManager.Data;
using TaskManager.Models;
using TaskManager.Models.DTO; // Ensure this namespace is included for DTOs
using Xunit;

namespace TaskManager.Tests
{
    public class TaskServiceTests
    {
        private readonly Mock<ITasksRepo> _mockRepo;
        private readonly TaskService _taskService;

        public TaskServiceTests()
        {
            _mockRepo = new Mock<ITasksRepo>();
            _taskService = new TaskService(_mockRepo.Object, null); // Assuming you pass null for IMapper for simplicity
        }

        [Fact]
        public void GetAllTasksReturnsEmptyListOnEmpty()
        {
            // Arrange
            List<ToDo> taskList = new List<ToDo>(); // Initialize an empty list

            _mockRepo.Setup(repo => repo.GetAllTasks()).Returns(taskList);

            // Act
            var result = _taskService.GetAllTasks();

            // Assert
            Assert.Empty(result); // Check that the result is an empty list
        }

        [Fact]
        public void GetAllTasksReturnsProperList()
        {
            // Arrange
            List<ToDo> taskList = new List<ToDo>
            {
                new ToDo { Title = "Coffee", State = "Pending" },
                new ToDo { Title = "Tea", State = "Completed" },
                new ToDo { Title = "Snacks", State = "Pending" }
            };

            _mockRepo.Setup(repo => repo.GetAllTasks()).Returns(taskList);

            // Act
            var result = _taskService.GetAllTasks();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Contains(result, t => t.Title.Equals("Coffee"));
        }

        [Fact]
        public void GetTasksByIdReturnsTask()
        {
            // Arrange
            var task = new ToDo { Id = 1, Title = "Coffee", State = "Pending" };
            _mockRepo.Setup(repo => repo.GetTasksById(1)).Returns(task);

            // Act
            var result = _taskService.GetTasksById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Coffee", result.Title);
        }

        [Fact]
        public void AddTaskThrowsExceptionForInvalidTitle()
        {
            // Arrange
            var taskDto = new ToDoDto { Title = "", Due = "2024-10-30", State = "Pending" };

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => _taskService.AddTask(taskDto));
            Assert.Equal("Invalid Task. Please check title!", exception.Message);
        }

        [Fact]
        public void DeleteTaskThrowsExceptionForNonExistentTask()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetTasksById(99)).Returns((ToDo)null);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => _taskService.DeleteTask(99));
            Assert.Equal("Task with id 99 does not exist", exception.Message);
        }
    }
}