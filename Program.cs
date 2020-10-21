using System;
using System.Collections.Generic;
using System.Threading;

namespace TODO
{
    class Program
    {
        public static List<Task> addTaskList = new List<Task>();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            bool applicationRunning = true;

            do
            {
                Console.WriteLine("1. Add task");

                Console.WriteLine("2. Exit");

                ConsoleKeyInfo input;

                bool validInput;

                do
                {
                    input = Console.ReadKey(true);

                    validInput = !(input.Key == ConsoleKey.D1 || input.Key == ConsoleKey.NumPad1
                                || input.Key == ConsoleKey.D2 || input.Key == ConsoleKey.NumPad2);

                } while (validInput);

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

        public static void AddTask()
        {
            bool programRunning = true;

            do
            {
                Console.SetCursorPosition(10, 2);
                Console.WriteLine("Add task: ");
                Console.SetCursorPosition(10, 4);
                Console.WriteLine("Due Date: ");
                try
                {
                Console.SetCursorPosition(20, 2);
                string userTask = Console.ReadLine();
                Console.SetCursorPosition(20, 4);
                DateTime userDate = DateTime.Parse(Console.ReadLine()); ;

                Console.SetCursorPosition(3, 12);
                Console.WriteLine("Is this correct [Y]es / [N]o");
                ConsoleKeyInfo userInput;

                bool isCorrect;
               
                do
                {
                    userInput = Console.ReadKey(true);

                    isCorrect = !(userInput.Key == ConsoleKey.Y || userInput.Key == ConsoleKey.N);

                } while (isCorrect);

                Console.Clear();

                Task newTask = new Task(userTask, userDate);

                switch (userInput.Key)
                {
                    case ConsoleKey.Y:
                        addTaskList.Add(newTask);
                        Console.Clear();
                        Console.SetCursorPosition(6, 4);
                        Console.WriteLine("Saved to list");
                        Thread.Sleep(2000);
                        Console.Clear();
                        programRunning = false;
                        break;

                    case ConsoleKey.N:
                        break;
                }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.SetCursorPosition(6, 4);
                    Console.WriteLine(e.Message);
                    Thread.Sleep(2000);
                    Console.Clear();
                }

            } while (programRunning);
           
        }
    }
}
