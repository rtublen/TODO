using System;
using System.Globalization;
using System.Collections.Generic;
using static System.Console;
using TODO.Domain;
using System.Threading;

namespace TODO
{
    class Program
    {

        static List<Task> taskList = new List<Task>();
        static int taskId = 0;


        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            bool applicationRunning = true;

            string addTask;
            DateTime dueDate;

            bool saveTask = false;



            do
            {
                Console.WriteLine("1. Add task");

                Console.WriteLine("2. Exit");

                ConsoleKeyInfo input = Console.ReadKey(true);

                Console.Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        Console.Write("Task: ");
                        addTask = Console.ReadLine();

                        Console.Write("Due Date: ");
                        string dueDateString = Console.ReadLine();

                        dueDate = DateTime.ParseExact(dueDateString, "yyMMdd", CultureInfo.InvariantCulture);


                        ConsoleKeyInfo addTaskInput;
                        bool addTaskConfirmation = false;

                        WriteLine("\nIs this correct? (Y)es (N)o");
                        do
                        {
                            addTaskInput = ReadKey(true);
                            addTaskConfirmation = (addTaskInput.Key == ConsoleKey.Y
                                || addTaskInput.Key == ConsoleKey.N);

                        } while (addTaskConfirmation == false);


                        switch (addTaskInput.Key)
                        {
                            case ConsoleKey.Y:
                                saveTask = true;
                                break;

                            case ConsoleKey.N:
                                break;
                        }

                        if (saveTask == true)
                        {


                            Task task = new Task(addTask, dueDate);
                            taskList.Add(task);

                            taskId++;
                            WriteLine("\nAdding Task");
                            Thread.Sleep(1000);
                            Clear();

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
