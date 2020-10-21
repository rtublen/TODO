using System;
using System.Collections.Generic;
using System.Text;

namespace TODO
{
    class PlannedTask
    {
        public PlannedTask (string task, string dueTime)
        {
            Task = task;
            DueTime = dueTime;
        }
        public string Task { get; }
        public string DueTime { get; }
    }
}
