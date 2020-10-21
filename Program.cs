using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TODO.Domain;

namespace TODO
{
    class Program
    {
        static List<TodoTask> taskList = new List<TodoTask>();
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
        static void AddTask()
        {

            Console.Clear();

            Console.WriteLine("    Task: ");
            Console.WriteLine("Due date: ");

            Console.CursorVisible = true;

            Console.SetCursorPosition("    Task: ".Length, 0);
            var inputDescription = Console.ReadLine();

            Console.SetCursorPosition("    Task: ".Length, 1);
            var inputDueDate = Console.ReadLine();
            var inputDueDateTime = DateTime.Parse(inputDueDate);

            Console.CursorVisible = false;

            Console.WriteLine("\nIs this correct? [Y]es [N]o");

            var inputYesNo = Console.ReadKey(true);

            if(inputYesNo.Key == ConsoleKey.Y)
            {
                taskList.Add(new TodoTask(inputDescription, inputDueDateTime));

                Console.Clear();

                Console.WriteLine("Task successfully added");
                Thread.Sleep(2000);
            }
            else { 
            
            }

            
        }
    }
}
