using System;
using System.Collections.Generic;
using System.Threading;

namespace TODO
{
    class Program
    {
        static List<PlannedTask> taskList = new List<PlannedTask>();
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

        private static void AddTask()
        {
            bool correctInfo = false;
            do
            {
                Console.Clear();
                Console.CursorVisible = true;
                Console.WriteLine("    Task: \n\n" +
                                  "Due date: ");
                Console.SetCursorPosition(10, 0);
                string task = Console.ReadLine();
                Console.SetCursorPosition(10, 2);
                string dueDate = Console.ReadLine();

                Console.CursorVisible = false;
                Console.WriteLine("Is this information correct? (Y)es (N)o");

                ConsoleKeyInfo input = Console.ReadKey(true);

                while (input.Key != ConsoleKey.N && input.Key != ConsoleKey.Y) 
                {
                    input = Console.ReadKey(true);
                }

                switch (input.Key)
                {
                    case ConsoleKey.N:

                        break;
                    case ConsoleKey.Y:

                        Console.WriteLine("Task added!");
                        Thread.Sleep(2000);
                        correctInfo = true;
                        PlannedTask plannedTask = new PlannedTask(task, dueDate);
                        taskList.Add(plannedTask);
                        break;
                }
            } while (!correctInfo);
            Console.Clear();
        }
    }
}
