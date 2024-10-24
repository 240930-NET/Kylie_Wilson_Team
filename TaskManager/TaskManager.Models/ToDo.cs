namespace TaskManager.Models;

public class ToDo
{
    public class UserTask
{
    // Property to store the title of the task
    public string? Title { get; set; }

    // Property to store the due date of the task
    public DateTime Due { get; set; }

    // Property to store the state of the task, with a default value of "In progress"
    public string? State { get; set; } = "In progress";

    // Constructor to create a new UserTask object
    public UserTask(string? title, DateTime due, string? state)
    {
        // Initialize the Title property with the provided title
        Title = title;

        // Initialize the Due property with the provided due date
        Due = due;

        // Initialize the State property with the provided state
        // If no state is provided, it will use the default value "In progress"
        State = state;
    }

    // Method to display the details of the task
    public void TaskSpecifics()
    {
        // Print a formatted string containing the task's title, due date, and state
        Console.WriteLine($"Task: {Title}, Due: {Due}, State: {State}\n");
    }
}
}
