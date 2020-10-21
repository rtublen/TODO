using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> todoList = new List<Task>();
            
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
                        Console.WriteLine("      Task: ");
                        Console.WriteLine("  Due Date: ");
                        Console.CursorVisible = true;

                        Console.SetCursorPosition(12, 0);
                        string taskName = Console.ReadLine();

                        Console.SetCursorPosition(12, 1);
                        bool dueDateOk = DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd",
                            CultureInfo.GetCultureInfo("sv-SE"), 0, out DateTime dueDateFormatted);

                        // Set default due date value to today
                        if (!dueDateOk) dueDateFormatted = DateTime.Today;


                        // Request further confirmation of the input data
                        Console.WriteLine("\n  Is this correct? (Y)es (N)o");
                        Console.CursorVisible = false;
                        ConsoleKeyInfo confirmation;
                        bool confirmationIsRecognized = false;

                        do
                        {
                            confirmation = Console.ReadKey(true);
                            confirmationIsRecognized = confirmation.Key == ConsoleKey.Y || confirmation.Key == ConsoleKey.N;

                        } while (!confirmationIsRecognized);


                        // If confirmation is given...
                        if (confirmation.Key == ConsoleKey.Y)
                        {
                            Task newTask = new Task(taskName, dueDateFormatted);
                            todoList.Add(newTask);
                            Console.WriteLine("\n  Task has been added");
                            Thread.Sleep(2000);
                        }

                        Console.Clear();
                        break;

                    case ConsoleKey.D2:

                        applicationRunning = false;

                        break;

                }

            } while (applicationRunning);

        }
    }

    internal class Task
    {
        private string _taskName;
        private DateTime _dueDate;

        public Task(string taskName, DateTime dueDate)
        {
            TaskName = taskName;
            DueDate = dueDate;
        }

        public string TaskName
        {
            get;
            set;
        }

        public DateTime DueDate
        {
            get;
            set;
        }
    }
}
