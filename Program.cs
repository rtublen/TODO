using System;
using System.Collections.Generic;
using static System.Console;
using TODO.Domain;
using System.Threading;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> taskList = new List<Task>();

            CursorVisible = false;

            bool applicationRunning = true;

            do
            {
                WriteLine("1. Add task");

                WriteLine("2. Exit");

                ConsoleKeyInfo input = ReadKey(true);

                Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        string tasks;
                        DateTime dateTime;

                        ConsoleKeyInfo userChoice;

                        bool incorrectInformation;

                        do
                        {
                            CursorVisible = true;

                            SetCursorPosition(0, 0);
                            Write("Task: ");

                            SetCursorPosition(0, 1);
                            Write("Due Date: ");

                            SetCursorPosition(6, 0);
                            tasks = ReadLine();

                            SetCursorPosition(10, 1);
                            dateTime = DateTime.Parse(ReadLine());

                            Clear();

                            CursorVisible = false;

                            WriteLine("Is this information correct? (Y)es/(N)o" + "\n");

                            WriteLine($"Task: {tasks}");
                            WriteLine($"Due Date: {dateTime:yy-MM-dd}");

                            userChoice = ReadKey(true);

                            incorrectInformation = !(userChoice.Key == ConsoleKey.Y);

                            Clear();

                        } while (incorrectInformation);

                        Task task = new Task(tasks, dateTime);

                        taskList.Add(task);

                        WriteLine("Task added.");

                        Thread.Sleep(2000);

                        Clear();

                        break;

                    case ConsoleKey.D2:

                        applicationRunning = false;

                        break;
                }

            } while (applicationRunning);
        }
    }
}
