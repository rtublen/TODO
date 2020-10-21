using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TODO.Domain;
using static System.Console;

namespace TODO
{
    class Program
    {
        static List<Tasks> taskList = new List<Tasks>();

        static void Main(string[] args)
        {
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

                        WriteLine("Task: ");

                        string taskName = ReadLine();

                        WriteLine("Due date: ");

                        DateTime dueDate = DateTime.Parse(ReadLine());

                        WriteLine("Is this information correct= (Y)es  (N)o");

                        ConsoleKeyInfo correctInformationInput = ReadKey(true);

                        switch (correctInformationInput.Key)
                        {
                            case ConsoleKey.Y:

                                WriteLine("Task added");

                                Tasks tasks = new Tasks(taskName, dueDate);

                                taskList.Add(tasks);

                                Thread.Sleep(2000);

                                Clear();

                                break;

                            case ConsoleKey.N:



                                break;
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
