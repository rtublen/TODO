using System;
using System.Collections.Generic;
using System.Text;

namespace TODO.Domain
{
    class TheTask
    {
        public TheTask(string task, DateTime dueDate)
        {
            pTask = task;
            DueDate = dueDate;
        }

        public string pTask { get; }

        public DateTime DueDate { get; }
    }
}
