using System;
using System.Collections.Generic;
using System.Threading;
using static System.Console;

namespace TODO
{
    class Program
    {
        static List<Tasks> taskList = new List<Tasks>();
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

                        WriteLine("Task: ");
                        WriteLine();
                        WriteLine("Due Date: ");

                        SetCursorPosition(11, 0);
                        string task = ReadLine();

                        SetCursorPosition(11, 2);
                        string dueDate = ReadLine();

                        SetCursorPosition(0, 5);
                        WriteLine("Is this correct? (Y)es (N)o");

                        ConsoleKeyInfo yesNo;
                        do
                        {
                            yesNo = ReadKey(true);
                        } while (yesNo.Key != ConsoleKey.Y && yesNo.Key != ConsoleKey.N);

                        if (yesNo.Key == ConsoleKey.Y)
                        {
                            Tasks tasks = new Tasks(task, DateTime.Parse(dueDate));

                            taskList.Add(tasks);
                            Clear();
                            WriteLine("Task added.");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            Clear();
                            WriteLine("Task was never added.");
                            Thread.Sleep(2000);
                        }

                        break;

                    case ConsoleKey.D2:

                        applicationRunning = false;

                        break;

                }
                Clear();

            } while (applicationRunning);

        }
    }
}
