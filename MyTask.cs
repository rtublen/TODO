using System;
using System.Collections.Generic;
using System.Text;

namespace TODO
{
    public class MyTask
    {
        public MyTask (string name)
        {
            Name = name;
        }

        public MyTask(string name, DateTime? dueDate)
        {
            Name = name;
            DueDate = dueDate;
        }

        public MyTask(int id, string name, DateTime? dueDate)
        {
            Id = id;
            Name = name;
            DueDate = dueDate;
        }


        public int Id { get; }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                     throw new ArgumentException("A task is required to have a name.", "Name");
                }
                name = value;

            }
        }

        private DateTime? dueDate;

        public DateTime? DueDate
        {
            get { return dueDate; }
            private set
            {


                if (value != null && value.Value.Date < DateTime.Now.Date)
                {
                    throw new ArgumentException("A new task due date must be on a future or present date.", "DueDate");
                }
                dueDate = value;
            }
        }

        public DateTime? CompletedAt { get; private set; }

        public void CompleteTask()
        {
            if (CompletedAt != null)
            {
                throw new ArgumentException("Cannot change to completed twice");
            }
            CompletedAt = DateTime.Now;
        }




    }
}


