using System;
using System.Collections.Generic;
using System.Text;

namespace TODO.Domain
{
    class Task
    {
        public Task(string task, DateTime date)
        {
            this.task = task;
            this.date = date;
        }

        public string task { get; }
        public DateTime date { get; }
    }
}
