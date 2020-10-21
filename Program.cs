using System;
using System.Collections.Generic;
using static System.Console;

namespace TODO
{
    class Program
    {
        public static List<Tasks> taskList = new List<Tasks>();

        static void Main(string[] args)
        {
            CursorVisible = false;

            bool applicationRunning = true;
            do
            {
                WriteLine("1. Add task");

                WriteLine("2. Exit");

                var input = ReadKey(true);

                Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        AddTaskMenuOption();

                        Clear();
                        
                        break;

                    case ConsoleKey.D2:

                        applicationRunning = false;

                        break;

                }
            } while (applicationRunning);

        }

        private static void AddTaskMenuOption()
        {
            var isAddingTask = true;

            CursorVisible = true;

            do
            {
                WriteLine("Task: ".PadLeft(10));
                WriteLine("\nDue Date: ");

                SetCursorPosition(10, 0);
                var task = ReadLine();

                SetCursorPosition(10, 2);
                var dueDate = Convert.ToDateTime(ReadLine());

                CursorVisible = false;

                SetCursorPosition(0, 6);
                WriteLine("Is this correct? (Y)es (N)o");

                ConsoleKeyInfo choice;

                bool invalidInput;
                do
                {
                    choice = ReadKey(true);

                    invalidInput = !(choice.Key == ConsoleKey.Y
                                     || choice.Key == ConsoleKey.N);
                } while (invalidInput);

                if (choice.Key == ConsoleKey.Y)
                {
                    var newTask = new Tasks(task, dueDate);

                    taskList.Add(newTask);

                    isAddingTask = false;
                }

                Clear();
            } while (isAddingTask);

            CursorVisible = false;
        }
    }
}
