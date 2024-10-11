namespace TaskManager.APP;

class Program
{
    static void Main(string[] args)
    {
        // Load existing tasks from file
        List<UserTask> userTasks = Data.DeserializeTasks();

        // Display welcome message and menu options
        Menu.Welcome();
        Menu.Options();

        // Get initial user choice
        int choice = Menu.Input();

        // Main program loop
        while (choice != 5) // Continue until user chooses to exit (option 5)
        {
            switch (choice)
            {
                case 1:
                    // Add a new task
                    Logic.AddTask(userTasks);
                    break;
                case 2:
                    // Delete an existing task
                    Console.WriteLine("\t2. Delete a task");
                    Console.WriteLine("\n----- Existing Tasks Below -----\n");
                    Logic.ShowTasks(userTasks); 
                    Console.WriteLine("\n--------------------------------\n");
                    Logic.RemoveTasks(userTasks);
                    break;
                case 3:
                    // Display all tasks
                    Console.WriteLine("\t3. All of the Tasks below ");
                    Logic.ShowTasks(userTasks);
                    break;
                case 4:
                    // Save tasks to file
                    Console.WriteLine("\t4. Save a Task");
                    Logic.SaveTasks(userTasks);
                    break;
                case 5:
                    // Exit the program (this case is actually not needed due to the while condition)
                    Console.WriteLine("\t5. Close");
                    break;
            }

            // Display menu options again
            Menu.Options();

            // Get next user choice
            choice = Menu.Input();
        }
    }
}