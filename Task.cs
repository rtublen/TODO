using System;

namespace TODO
{
    class Task
    {
        public Task(string addTask, DateTime dateTime)
        {
            AddTask = addTask;
            DateTime = dateTime;

        }

        public string AddTask { get; }
        public DateTime DateTime { get; }

    }
}
