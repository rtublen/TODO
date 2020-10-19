using System;
using System.Threading;
using static System.Console;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            bool applicationRunning = true;

            do
            {
                CursorVisible = false;

                WriteLine("1. Add todo");
                WriteLine("2. Exit");

                ConsoleKeyInfo input = ReadKey(true);

                Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        Clear();
                        CursorVisible = true;
                        Write("Add what?!: ");
                        string addTodo = ReadLine();


                        WriteLine($"{addTodo} added");
                        Thread.Sleep(1000);
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
