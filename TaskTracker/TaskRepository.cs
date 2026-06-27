using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TaskTracker
{
    public static class TaskRepository
    {
        private static readonly string FilePath = "tasks.json";

        public static List<TodoTask> LoadTasks()
        {
            if (!File.Exists(FilePath)) 
                return new List<TodoTask>();

            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<TodoTask>>(json) ?? new List<TodoTask>();
        }

        public static void SaveTasks(List<TodoTask> tasks)
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}