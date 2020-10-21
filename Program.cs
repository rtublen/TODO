using System;
using System.Collections.Generic;
using TODO.Domain;
using static System.Console;
using Task = System.Threading.Tasks.Task;

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

                        switch(keyInput.Key)
                        {
                            case ConsoleKey.Y:

                                taskList.Add(newTask);
                                break;

                            case ConsoleKey.N:

                                return;
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
