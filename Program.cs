using System;
using System.Collections.Generic;
using static System.Console;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            bool applicationRunning = true;

            List<string[]> taskList = new List<string[]>();

            do
            {
                Console.WriteLine("1. Add task");

                Console.WriteLine("2. Exit");

                ConsoleKeyInfo input = Console.ReadKey(true);

                Console.Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        bool cancel;
                        do
                        {
                            cancel = false;
                            WriteLine("Task: ");
                            WriteLine("Due Date: ");

                            SetCursorPosition(6, 0);
                            string task = ReadLine();

                            SetCursorPosition(10, 1);
                            string dueDate = ReadLine();

                            if (AskForConfirmation() == true)
                            {
                                string[] taskArray = new string[] { task, dueDate };
                                taskList.Add(taskArray);
                            }
                            else
                            {
                                cancel = true;
                            }
                            Clear();

                        } while (cancel);

                        break;

                    case ConsoleKey.D2:

                        applicationRunning = false;

                        break;

                }

            } while (applicationRunning);

        }

        private static bool AskForConfirmation()
        {
            bool returnBool = true;
            bool incorrect;


            ConsoleKeyInfo menuSelection;

            WriteLine("Is this correct? (Y)es (N)o");
            do
            {
                menuSelection = ReadKey(true);

                incorrect = !((menuSelection.Key == ConsoleKey.Y)
                    || (menuSelection.Key == ConsoleKey.N));
            } while (incorrect);

            Clear();

            switch (menuSelection.Key)
            {
                case ConsoleKey.Y:
                    returnBool = true;
                    break;

                case ConsoleKey.N:
                    returnBool = false;
                    break;

            }

            return returnBool;

        }
    }
}
