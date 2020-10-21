using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace TODO
{
    class Program
    {
        static List<Task> tasks = new List<Task>();
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            bool applicationRunning = true;

            do
            {
                Console.Clear();

                Console.WriteLine("1. Add task");

                Console.WriteLine("2. Exit");

                ConsoleKeyInfo input = Console.ReadKey(true);

                Console.Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        Console.WriteLine("    Task: ");
                        Console.Write("Due Date: ");
                        Console.CursorTop--;
                        Console.CursorVisible = true;
                        string taskInput = Console.ReadLine();
                        Console.CursorLeft = 10;
                        string dateInput = Console.ReadLine();
                        Console.CursorVisible = false;

                        Console.Write("\nIs this correct? (Y)es (N)o");


                        do
                        {
                            input = Console.ReadKey();
                        } while (input.Key != ConsoleKey.Y && input.Key != ConsoleKey.N);

                        if (input.Key == ConsoleKey.Y)
                        {
                            tasks.Add(new Task(description: taskInput, date: DateTime.ParseExact(dateInput, "yyyy-MM-dd", CultureInfo.InvariantCulture)));
                        }

                        break;

                    case ConsoleKey.D2:

                        applicationRunning = false;

                        break;

                }

            } while (applicationRunning);

        }
    }

    class Task
    {
        public Task(string description, DateTime date)
        {
            Description = description;
            Date = date;
        }

        public string Description { get; protected set; }
        public DateTime Date { get; protected set; }
    }
}
