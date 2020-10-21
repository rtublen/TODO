using System;
using System.Collections.Generic;
using System.Threading;
using TODO.Domain;
using static System.Console;

namespace TODO
{
    class Program
    {

        static void Main(string[] args)
        {
            CursorVisible = false;
            List<TheTask> taskList = new List<TheTask>();
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
                        bool addTaskrunning = true;
                        do
                        {
                            WriteLine("Task: ");
                            WriteLine("Due Date: ");

                            SetCursorPosition(6, 0);
                            string task = ReadLine();

                            SetCursorPosition(10, 1);
                            DateTime dueDate = DateTime.Parse(ReadLine());

                            TheTask newTask = new TheTask(task, dueDate);

                            WriteLine("");
                            WriteLine("Is this correct? (Y)es (N)o");
                            ConsoleKeyInfo keyInput = ReadKey(true);

                            Clear();

                            switch (keyInput.Key)
                            {
                                case ConsoleKey.Y:

                                    taskList.Add(newTask);
                                    WriteLine("Task added");
                                    Thread.Sleep(750);
                                    Clear();
                                    addTaskrunning = false;
                                    break;

                                case ConsoleKey.N:

                                    break;
                            }

                            
                        } while (addTaskrunning);
                        break;
                    case ConsoleKey.D2:

                        applicationRunning = false;

                        break;

                }

            } while (applicationRunning);

        }
    }
}
