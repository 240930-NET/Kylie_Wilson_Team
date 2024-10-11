using System;

public class Menu
{
    // Displays a welcome message and brief description of the application
    public static void Welcome()
    {
        Console.WriteLine("This is a task manager.\nThis application will help you to organize your tasks and keep you on track.");
        Console.WriteLine("Select one of the options:\n");
    }

    // Displays the main menu options
    public static void Options()
    {
        Console.WriteLine("\n----------------------");
        Console.WriteLine("\t1. Add a task");
        Console.WriteLine("\t2. Delete a task");
        Console.WriteLine("\t3. Display All Tasks");
        Console.WriteLine("\t4. Save Tasks");
        Console.WriteLine("\t5. Close");
        Console.WriteLine("----------------------\n\n");
    }

    // Prompts the user for input and returns the selected menu option as an integer
    public static int Input()
    {
        Console.Write("\tType a number: ");
        string? userInput = Console.ReadLine();

        try
        {
            // Attempt to parse the user input as an integer
            int k = int.Parse(userInput);
            return k;
        }
        catch (Exception error)
        {
            // If parsing fails, print the error message and return 0
            Console.WriteLine(error.Message);
            return 0;
        }
    }

    // Prompts the user to select a task and returns the task name
    public static string Select()
    {
        Console.WriteLine("Input the task you wish to select.");
        string? task = Console.ReadLine();
        // Return the entered task name or an empty string if null
        return task ?? "";
    }

    // Collects information for a new task from the user
    public static UserTask TaskInformation()
    {
        // Prompt for and collect task title
        Console.Write("Enter a Title name for your task: ");
        string? title = Console.ReadLine();

        // Prompt for and collect due date
        Console.Write("Enter a due date (e.g., MM/dd/yyyy): ");
        string input = Console.ReadLine() ?? "";

        // Parse the date input, use current date if parsing fails
        DateTime dueDate = DateTime.TryParse(input, out DateTime parsedDate)
            ? parsedDate
            : DateTime.Now;

        // Prompt for and collect task status
        Console.Write("Enter a state of your task (in progress, finished): ");
        string? status = Console.ReadLine();

        // Create and return a new UserTask object with the collected information
        return new UserTask(title, dueDate, status);
    }

    
}