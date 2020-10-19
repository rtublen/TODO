using System;
using static System.Console;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {

            CursorVisible = false;

            bool appliationRunning = true;

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

                        break;

                    case ConsoleKey.D3:

                        appliationRunning = false;

                        break;
                }

            } while (appliationRunning);

        }
    }
}
