using System;

namespace TODO.Model
{
    public class Task
    {
        public Task(string yourTask, string dueDate)
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
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Parameter youTask cannot be null or empty");
                }

                yourTask = value;
            }


        }

        private string dueDate;
        public string DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Parameter youTask cannot be null or empty");
                }

                dueDate = value;
            }
        }
    }
}