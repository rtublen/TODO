using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using static System.Console;


namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            bool applicationRunning = true;

            List<Task> allTasks = new List<Task>();

            do
            {
                Console.WriteLine("1. Add Task");

                Console.WriteLine("2. Exit");

                ConsoleKeyInfo input = Console.ReadKey(true);

                Console.Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        bool invalidTaskCredentials = true;

                        do
                        {
                            Task tasks = new Task();

                            Write("Task: ");
                            tasks.taskName = ReadLine();

                            Write("Due Date: ");
                            tasks.dueDate = ReadLine();

                            Clear();

                            WriteLine($"Task: {tasks.taskName}");
                            WriteLine($"Due Date: {tasks.dueDate}");

                            WriteLine(" ");

                            WriteLine("Is this correct? (Y)es or (N)o.");

                            ConsoleKeyInfo yesNo = ReadKey(true);

                            if (yesNo.Key == ConsoleKey.Y)
                            {
                                allTasks.Add(tasks);

                                Clear();

                                WriteLine("Task registered.");

                                Thread.Sleep(2000);

                                Clear();

                                break;
                            }
                            else if (yesNo.Key == ConsoleKey.N)
                            {
                                Clear();
                            }
                            else
                            {
                                Clear();

                                WriteLine("Invalid key pressed.");

                                Thread.Sleep(2000);

                                Clear();
                            }
                        } while (invalidTaskCredentials);

                        break;

                    case ConsoleKey.D2:

                        applicationRunning = false;

                        break;

                }

            } while (applicationRunning);

        }
    }
}
