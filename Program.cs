using System;
using System.Collections.Generic;
using System.Threading;
using TODO.Domain;

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
                        Console.WriteLine("    Task: ");
                        Console.WriteLine("Due Date: ");

                        Console.SetCursorPosition(10, 0);
                        string task = Console.ReadLine();

                        Console.SetCursorPosition(10, 1);
                        DateTime date = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Is this correct? (Y)es (N)o");

                        ConsoleKeyInfo correctInformation = Console.ReadKey();

                        if (correctInformation.Key == ConsoleKey.Y)
                        {
                            Console.Clear();

                            Task newTask = new Task(task, date);
                            taskList.Add(newTask);

                            Console.WriteLine("Task added.");

                            Thread.Sleep(2000);
                        }
                        else if (correctInformation.Key == ConsoleKey.N)
                        {
                            Console.Clear();
                            Console.WriteLine("Nothing added.");
                            Thread.Sleep(2000);
                        }

                        break;

                    case ConsoleKey.D2:

                        applicationRunning = false;

                        break;

                }

            } while (applicationRunning);

        }
    }
}
