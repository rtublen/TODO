using System;
using System.Collections.Generic;
using System.Threading;
using TODO.Domain;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            bool applicationRunning = true;

            List<TaskClass> taskList = new List<TaskClass>();

            int addTaskCounter = 0;

            do
            {
                Console.WriteLine("1. Add task");

                Console.WriteLine("2. Exit");

                ConsoleKeyInfo input = Console.ReadKey(true);

                Console.Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        Console.Write("Task: ");
                        string task = Console.ReadLine();

                        Console.Write("Due Date: ");
                        string dueDate = Console.ReadLine();

                        Console.WriteLine("Is this correct? (Y)es (N)o");
                        ConsoleKeyInfo inputTask = Console.ReadKey(true);

                        TaskClass taskAdd = new TaskClass(task, dueDate);

                        if (inputTask.Key == ConsoleKey.Y)
                        {

                            taskList.Add(taskAdd);
                            addTaskCounter++;


                            Console.WriteLine("Task added");
                            Thread.Sleep(2000);
                            Console.Clear();

                        }

                        else if (inputTask.Key == ConsoleKey.N)
                        {
                            Console.WriteLine("Task not added");
                            Thread.Sleep(2000);
                            Console.Clear();
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
