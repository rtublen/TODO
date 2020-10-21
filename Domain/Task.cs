using System;

namespace TODO.Domain
{
    class Task
    {
        public Task(string tasks, DateTime dueDate)
        {
            Tasks = tasks;
            DueDate = dueDate;
        }

        public string Tasks { get; }
        public DateTime DueDate { get; }
    }
}
