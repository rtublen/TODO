using System;

namespace TODO
{
    internal class AddTask
    {

        public AddTask(string task, DateTime dueDate)
        {
            Task = task;
            DueDate = dueDate;
        }


        public string Task { get; set; }

        public DateTime DueDate { get; set; }
    }
}
