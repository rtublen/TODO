using System;

namespace TODO
{
    class Tasks
    {
        public Tasks(string task, DateTime dueDate)
        {
            Task = task;
            DueDate = dueDate;
        }
        public string Task { get; }
        public DateTime DueDate { get; }
    }
}