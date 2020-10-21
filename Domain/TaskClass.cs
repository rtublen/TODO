using System;
using System.Collections.Generic;
using System.Text;

namespace TODO.Domain
{
    class TaskClass
    {
public TaskClass (string task, string dueDate)
        {
            Task = task;
            DueDate = dueDate;
        }

        public string Task { get; }
        public string DueDate { get; }


    }
}
