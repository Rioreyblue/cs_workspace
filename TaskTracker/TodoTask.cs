using System;

namespace TaskTracker
{
    public class TodoTask
    {
        public string Description { get; set; } = string.Empty;
        public bool isComplete { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
