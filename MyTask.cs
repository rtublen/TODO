using System;
using System.Collections.Generic;
using System.Text;

namespace TODO
{
    public class MyTask
    {
        public MyTask(string name, string dueDate)
        {
            Name = name;
            DueDate = dueDate;
        }

        public string Name { get; set; }
        public string DueDate { get; set; }

    }
}
