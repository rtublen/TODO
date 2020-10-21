using System;

namespace TODO.Domain
{
    class Task
    {

        public Task(string addTask, DateTime dueDate)
        {
            AddTask = addTask;
            DueDate = dueDate;
        }



        public string AddTask { get; }

        public DateTime DueDate { get; }

    }
}
