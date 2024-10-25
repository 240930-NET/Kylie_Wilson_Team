namespace TaskManager.Models.DTO; 

public class ToDoDto
{
    public string Title { get; set; } = string.Empty;
    public string? Due { get; set; }
    public string State { get; set; } = "In progress"; // Default state
}