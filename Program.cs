using System;
using System.Collections.Generic;
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

            while (true)
            {
                Console.Clear();

                Console.CursorVisible = true;
                Console.WriteLine("Task:  ");
                Console.WriteLine("Due date:  ");
             

                Console.SetCursorPosition(36, 0);

                var task = Console.ReadLine();

                Console.SetCursorPosition(36, 1);

                var dueDate = Console.ReadLine();

                Console.CursorVisible = false;

                Console.WriteLine("Is this correct? (Y)es (N)o ");

                var isCorrectInput = Console.ReadKey(true).Key;

                while (isCorrectInput != ConsoleKey.Y && isCorrectInput != ConsoleKey.N)
                {
                    isCorrectInput = Console.ReadKey(true).Key;
                }

                switch (isCorrectInput)
                {
                    case ConsoleKey.Y:

                        
                        MyTask newTask = new MyTask(task, dueDate);

                        
                        MyTaskList.Add(newTask);

                        Console.WriteLine("Task registered.");
                        Thread.Sleep(2000);
                        break;

                    case ConsoleKey.N:
                        continue;

                    default:
                        continue;
                }
                break;
            }
            Console.Clear();

        }
    }
}
