using System;

namespace TODO.Model
{
    public class Task
    {
        public Task(string yourTask, DateTime dueDate)
        {
            YourTask = yourTask;
            DueDate = dueDate;
        }

        private string yourTask;
        public string YourTask 
        {
            get
            {
                return yourTask;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Parameter youTask cannot be null or empty");
                }

                yourTask = value;
            }
        }

        public DateTime DueDate { get; }

    }
}