using System;
using System.Collections.Generic;
using TODO.Domain;
namespace TODO
{
    class Program
    {

        public static List<Task> tasksList = new List<Task>();
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

                

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        AddTaskMenu();
                        break;

                    case ConsoleKey.D2:

                        applicationRunning = false;

                        break;

                }

            } while (applicationRunning);

        }

        public static void AddTaskMenu() 
        {
            Console.Clear();
            Console.WriteLine(@"    Task:");
            Console.WriteLine(@"Due Date:");

            Console.SetCursorPosition(11,0);
            string taskInput = Console.ReadLine();

            Console.SetCursorPosition(11, 1);
            string taskDueDate = Console.ReadLine();

            var temporaryTask = new Task(taskInput,taskDueDate);

            if (YesOrNo()) 
            {
                tasksList.Add(temporaryTask);
            }
            


        }


        public static bool YesOrNo(string text = "\nIs this correct? (Y)es (N)o")
        {
            Console.WriteLine("\n" + text);

            bool validInput = false;

            bool userChoice = false;

            while (!validInput)
            {
                var userInput = Console.ReadKey(true);

                switch (userInput.Key)
                {
                    case ConsoleKey.Y:
                        validInput = true;
                        userChoice = true;
                        break;
                    case ConsoleKey.N:
                        validInput = true;
                        userChoice = false;
                        break;

                    default:
                        break;


                }
            }

            return userChoice;

        }

    }
}
