using System;
using System.Collections.Generic;
using System.Text;

namespace TODO
{
    class Task
    {
        public Task(string taskDescription, DateTime dueDate)
        {
            TaskDescription = taskDescription;
            DueDate = dueDate;
        }

        public string TaskDescription { get; }

        public DateTime DueDate { get; }
    }
}
