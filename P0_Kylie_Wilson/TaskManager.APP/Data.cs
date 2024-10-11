using System.Text.Json; // to be able to access JsonSerializer

public static class Data
{
    // Asynchronously serializes and saves the list of tasks to a file
    public static async Task SerializeAsync(List<UserTask> tasks)
    {
        // Convert the list of tasks to a JSON string
        string taskList = JsonSerializer.Serialize(tasks);

        try
        {
            // Create or overwrite the tasks.txt file
            using StreamWriter writer = File.CreateText("tasks.txt");
            // Asynchronously write the JSON string to the file
            await writer.WriteAsync(taskList);
        }
        catch (Exception error)
        {
            // If an error occurs during saving, print an error message
            Console.WriteLine($"Could not save changes: {error.Message}");
        }
    }

    // Deserializes tasks from the file and returns them as a List<UserTask>
    public static List<UserTask> DeserializeTasks()
    {
        try
        {
            // Open and read the contents of the tasks.txt file
            using (StreamReader reader = File.OpenText("tasks.txt"))
            {
                // Read the entire contents of the file
                string jsonString = reader.ReadToEnd();
                // Deserialize the JSON string to a List<UserTask>
                // If deserialization fails or returns null, return an empty list
                return JsonSerializer.Deserialize<List<UserTask>>(jsonString) ?? [];
            }
        }
        catch (Exception error)
        {
            // If an error occurs during loading, print an error message
            Console.WriteLine($"Could not load data: {error.Message}");
            // Return an empty list if loading fails
            return [];
        }
    }
}