using System;
using System.Collections.Generic;
using System.Threading;
using static System.Console;
using TODO.Model;

namespace TODO
{
    class Program
    {
        static List<Task> taskList = new List<Task>();

        static ConsoleKeyInfo input;
        static bool invalidInput;

        static void Main(string[] args)
        {
            CursorVisible = false;

            bool applicationRunning = true;

            do
            {
                WriteLine("1. Add task");

                WriteLine("2. Exit");

                input = ReadKey(true);

                Clear();

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
            bool taskNotRegistered = true;

            do
            {
                CursorVisible = true;
                WriteLine("Task: ");
                WriteLine("Due Date: ");

                SetCursorPosition(6, 0);
                string yourTask = ReadLine();

                SetCursorPosition(10, +1);
                string dueDate = ReadLine();

                Task task = new Task(yourTask, dueDate);

                CursorVisible = false;

                WriteLine("\nIs this correct info? (Y)es (N)o");

                input = ReadKey(true);

                Clear();

                do
                {
                    invalidInput = !(input.Key == ConsoleKey.Y || input.Key == ConsoleKey.N);
                } while (invalidInput);

                if (input.Key == ConsoleKey.Y)
                {
                    taskList.Add(task);
                    taskNotRegistered = false;
                    WriteLine("Task registered");
                    Thread.Sleep(2000);
                }
                else if (input.Key == ConsoleKey.N)
                {
                    taskNotRegistered = true;
                }

                Clear();

            } while (taskNotRegistered);
        }
    }
}
