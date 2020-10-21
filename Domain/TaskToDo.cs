using System;
using System.Collections.Generic;
using System.Text;

namespace TODO.Domain
{
    public class TaskToDo
    {

        public TaskToDo(string doThis, DateTime dueDate)
        {

            DoThis = doThis;
            DueDate = dueDate;

        }

        public string DoThis { get; }

        public DateTime DueDate { get; }

        public static List<TaskToDo> taskToDoList = new List<TaskToDo>();

    }
}
