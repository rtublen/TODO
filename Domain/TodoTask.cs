using System;
using System.Collections.Generic;
using System.Text;

namespace TODO.Domain
{
    class TodoTask
    {
        private string description;
        private DateTime dueDate;
        public string Description 
        { 
            get { return description; } 
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Description cannot be left empty");
                }
                else
                {
                    description = value;
                }
            } 
        }
        public DateTime DueDate { get { return dueDate; } private set { dueDate = value; } }
        public TodoTask(string description, DateTime dueDate)
        {
            Description = description;
            DueDate = dueDate;
        }
    }
}
