using System;
using static System.Console;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {

            CursorVisible = false;

            bool applicationRunning = true;

            do
            {
                WriteLine("1. Add todo");
                WriteLine("2. Exit");

                ConsoleKeyInfo input = ReadKey(true);

                Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        break;

                    case ConsoleKey.D2:

                        applicationRunning = false;

                        break;
                }

            } while (applicationRunning);

        }
    }
}
