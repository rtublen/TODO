using System;
using System.Threading;
using static System.Console;

namespace TODO
{
    internal class Program
    {
        private static void Main()
        {

            bool appIsRunning = true;
            CursorVisible = false;

            do
            {
                WriteLine("1. Add todo");
                WriteLine("2. Exit");

                ConsoleKeyInfo input = ReadKey(true);
                bool inputOk = input.Key == ConsoleKey.D1 || input.Key == ConsoleKey.D2;

                while (!inputOk)
                {
                    input = ReadKey(true);
                    inputOk = input.Key == ConsoleKey.D1 || input.Key == ConsoleKey.D2;
                }

                Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        WriteLine("You pushed 'Add to do'");
                        ReadKey(true);
                        Clear();
                        break;

                    case ConsoleKey.D2:
                        WriteLine("Shutting down the program");
                        Thread.Sleep(3000);
                        Clear();
                        appIsRunning = false;
                        break;
                }


            } while (appIsRunning);



        }
    }
}
