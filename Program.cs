using System;
using System.Collections.Generic;

namespace TODO
{
    class Program
    {
        static List<Task> taskList = new List<Task>();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            bool applicationRunning = true;

            do
            {
                Console.WriteLine("1. Add task");

                Console.WriteLine("2. Exit");

                ConsoleKeyInfo input = Console.ReadKey(true);

                Console.Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        AddTask();

                        break;

                    case ConsoleKey.D2:

                        applicationRunning = false;

                        break;
                }

            } while (applicationRunning);

        }

        public static void AddTask()
        {
            Console.CursorVisible = true;

            string taskDescription;
            DateTime dueDate;

            bool addInfo = true;
            
            do
            {
                Console.WriteLine("Task: ");
                Console.WriteLine("Due date: ");

                Console.SetCursorPosition(10, 0);
                taskDescription = Console.ReadLine();

                Console.SetCursorPosition(10, 1);
                dueDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("Is this correct? (Y)es (N)o");

                Task task = new Task(taskDescription, dueDate);

                bool userDidNotTypeYorN = true;

                do
                {
                    ConsoleKeyInfo inputYorN = Console.ReadKey(true);

                    if (inputYorN.Key == ConsoleKey.Y)
                    {
                        taskList.Add(task);

                        userDidNotTypeYorN = false;

                        addInfo = false;
                    }
                    else if (inputYorN.Key == ConsoleKey.N)
                    {
                        userDidNotTypeYorN = false;
                    }

                } while (userDidNotTypeYorN);

            } while (addInfo);

            Console.Clear();
        }
    }
}
