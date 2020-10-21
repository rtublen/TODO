using System;
using System.Collections.Generic;
using System.Text;

namespace TODO
{
    public class MyTask
    {
        public MyTask(string name, DateTime dueDate)
        {
            Name = name;
            DueDate = dueDate;
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("A task is required to have a name.", "Name");
                }
            }
        }

        private DateTime dueDate;

        public DateTime DueDate
        {
            get { return dueDate; }
            private set
            {
                if (value.Date < DateTime.Now.Date)
                {
                    throw new ArgumentException("A new task due date must be on a future or present date.", "DueDate");
                } }
        }




    }
}
