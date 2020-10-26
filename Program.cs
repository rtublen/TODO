﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace TODO
{
    class Program
    {
        public static List<MyTask> MyTaskList = new List<MyTask>();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            bool applicationRunning = true;

            do
            {
                Console.WriteLine("1. Add task");

                Console.WriteLine("2. List tasks");

                Console.WriteLine("3. Exit");

                ConsoleKeyInfo input = Console.ReadKey(true);

                Console.Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        AddTask();

                        break;

                    case ConsoleKey.D2:

                        ListTasks();

                        break;

                    case ConsoleKey.D3:

                        applicationRunning = false;

                        break;

                }

            } while (applicationRunning);

        }

        private static void ListTasks()
        {
            Console.WriteLine("Name              Due Date");

            foreach(var myTask in MyTaskList)
            {
                Console.WriteLine($"{myTask.Name}           {myTask.DueDate}");
            }

            Console.ReadKey(true);
        }

        private static void AddTask()
        {

            while (true)
            {
                Console.Clear();

                Console.CursorVisible = true;
                Console.WriteLine("Task:  ");
                Console.WriteLine("Due date (yyyy-MM-dd):  ");


                Console.SetCursorPosition(36, 0);

                var taskName = Console.ReadLine();

                Console.SetCursorPosition(36, 1);

                var dueDateString = Console.ReadLine();

                Console.CursorVisible = false;

                Console.WriteLine("Is this correct? (Y)es (N)o ");

                var isCorrectInput = Console.ReadKey(true).Key;

                while (isCorrectInput != ConsoleKey.Y && isCorrectInput != ConsoleKey.N)
                {
                    isCorrectInput = Console.ReadKey(true).Key;
                }

                if (isCorrectInput == ConsoleKey.Y)
                {
                    MyTask myTask;

                    if (string.IsNullOrWhiteSpace(dueDateString))
                    {
                        myTask = new MyTask(name: taskName);
                    }
                    else if (DateTime.TryParseExact(dueDateString, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dueDate))
                    {
                        myTask = new MyTask(taskName, dueDate);
                    }
                    else
                    {
                        throw new ArgumentException("DueDate was of invalid format or empty, please use the format yyyy-MM-dd", "DueDate");
                    }

                    System.Console.WriteLine("Task registered.");
                    Thread.Sleep(2000);

                    MyTaskList.Add(myTask);
                }

                else
                {
                    continue;
                }

                break;
            }
            
            Console.Clear();
        }
    }
}
