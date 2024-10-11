public class Logic
{
    // Adds a new task to the list
    public static void AddTask(List<UserTask> taskList)
    {
        // Get task information from user input
        UserTask newTask = Menu.TaskInformation();
        // Add the new task to the list
        taskList.Add(newTask);
        // Display confirmation message
        Console.WriteLine($"\n****New task Added: {newTask.Title}***\n");
    }

    // Displays all tasks in the list
    public static void ShowTasks(List<UserTask> taskList)
    {
        // Check if there are any tasks in the list
        if (taskList.Count > 0)
        {
            // Iterate through each task and display its details
            foreach (UserTask task in taskList)
            {
                task.TaskSpecifics();
            }
        }
        else
        {
            // If no tasks are found, display a message
            Console.WriteLine("No tasks found.");
            return;
        }
    }

    // Removes a task from the list
    public static void RemoveTasks(List<UserTask> taskList)
    {
        // Get the title of the task to delete from user input
        string taskToDelete = Menu.Select();
        // Find the task in the list that matches the title
        var taskChosen = taskList.Find(task => task.Title == taskToDelete);

        // If a matching task is found
        if (taskChosen != null)
        {
            // Remove the task from the list
            taskList.Remove(taskChosen);
            // Display confirmation message
            Console.WriteLine("\n###############          ##############");
            Console.WriteLine($"######## {taskChosen} Task Deleted  ####");
            Console.WriteLine("#################           #############\n");

            // Save the updated task list to the file
            SaveTasks(taskList);
        }
        else
        {
            // If no matching task is found, display an error message
            Console.WriteLine("Task with that name wasn't found");
        }
    }

    // Saves the current task list to a file
    public static void SaveTasks(List<UserTask> taskList)
    {
        // Call the SerializeAsync method to save the tasks
        Data.SerializeAsync(taskList);
    }
}