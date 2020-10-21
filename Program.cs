using System;

namespace TODO.Domain
{
    class Program
    {
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

                        AddTaskView();

                        break;

                    case ConsoleKey.D2:

                        applicationRunning = false;

                        break;

                }

            } while (applicationRunning);

        }

        private static void AddTaskView()
        {
            Console.Clear();

            Console.CursorVisible = true;

            Console.WriteLine("Task: ");

            Console.WriteLine("Due date (yyyy-mm-dd): ");

            Console.SetCursorPosition(6, 0);
            string taskToDo = Console.ReadLine();

            Console.SetCursorPosition(23, 1);

            DateTime dueDateParse;

            DateTime.TryParse(Console.ReadLine(), out dueDateParse);

            TaskToDo newTask = new TaskToDo(taskToDo, dueDateParse);

            Console.CursorVisible = false;

            Console.WriteLine("Is this correct? (Y)es (N)o");

            ConsoleKeyInfo confirmTask = Console.ReadKey(true);

            if (confirmTask.Key == ConsoleKey.Y)
            {
                TaskToDo.taskToDoList.Add(newTask);
            }
            else if (confirmTask.Key == ConsoleKey.N)
            {
                AddTaskView();
            }

        }

    }
}
