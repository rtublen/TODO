using System;
using System.Collections.Generic;
using System.Text;

namespace TODO.Domain
{
    class Tasks
    {
        public Tasks(string taskName, DateTime dueDate)
        {
            TaskName = taskName;
            DueDate = dueDate;
        }

        public string TaskName { get; }
        public DateTime DueDate { get; }
    }
}
