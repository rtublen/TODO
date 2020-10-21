using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using static System.Console;

namespace TODO
{
    class Program
    {
        static List<AddTask> addTasks = new List<AddTask>();
        static void Main(string[] args)
        {

            CursorVisible = false;

            bool applicationRunning = true;

            do
            {
                WriteLine("1. Add task");

                WriteLine("2. Exit");

                ConsoleKeyInfo input = Console.ReadKey(true);

                Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        showAddTaskReview();

                        break;

                    case ConsoleKey.D2:

                        applicationRunning = false;

                        break;

                }

            } while (applicationRunning);

        }

        private static void showAddTaskReview()
        {
            WriteLine(" Task:");
            WriteLine("Due Date:");

            SetCursorPosition(6, 0);
            string task = ReadLine();

            SetCursorPosition(10, 1);
            DateTime dueDate=  DateTime.Parse(ReadLine());

            

            WriteLine(" Is this correct? (Y)es (N)o");

            ConsoleKeyInfo correctInput = Console.ReadKey(true);

            Clear();

            switch (correctInput.Key)
            {
                case ConsoleKey.Y:

                    AddTask addTask = new AddTask(task, dueDate);

                    addTasks.Add(addTask);

                    WriteLine("Task added");

                    Thread.Sleep(2000);
                    Clear();

                    break;

                case ConsoleKey.N:



                    break;

            }
        }
    }
}
