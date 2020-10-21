using System;
using System.Collections.Generic;
using System.Text;

namespace TODO.Domain
{
    class Task
    {

        private string taskContent;

        private string dueDate;

        public Task(string taskContent,string dueDate)
        {
            TaskContent = this.taskContent;

            
        }


        public string TaskContent
        {
            get { return taskContent; }
            set { taskContent = value; }
        }

        public string DueDate
        {
            get
            {
                return dueDate;
            }

            set 
            {
                dueDate = value;
            }
        }



    }
}
