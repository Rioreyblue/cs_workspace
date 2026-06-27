using System;

namespace TaskTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: todo [add|list|complete] [arguments]");
                return;
            }

            string command = args[0].ToLower();

            switch (command)
            {
                case "add":
                    HandleAdd(args);
                    break;
                case "list":
                    HandleList();
                    break;
                default:
                    Console.WriteLine($"Unknown command: {command}");
                    break;
            }
        }

        static void HandleAdd(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Error: Please specify a task description.");
                return;
            }

            var tasks = TaskRepository.LoadTasks();
            var newTask = new TodoTask { Description = args[1] };

            if (args.Length >= 3 && DateTime.TryParse(args[2], out DateTime parsedDate))
            {
                newTask.Deadline = parsedDate;
            }

            tasks.Add(newTask);
            TaskRepository.SaveTasks(tasks);
            Console.WriteLine("Task added successfully!");
        }

        static void HandleList()
        {
            var tasks = TaskRepository.LoadTasks();
            // ... Your color-coded printing logic goes here!
        }
    }
}