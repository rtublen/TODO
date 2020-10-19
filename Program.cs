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
                WriteLine("1. Add employee");
                WriteLine("2. Search employee");
                WriteLine("3. Exit");

                ConsoleKeyInfo input;
                
                do
                {
                    input = ReadKey(true);
                } while (input.Key != ConsoleKey.D1 && input.Key != ConsoleKey.D2);

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        
                        break;

                    case ConsoleKey.D2:

                        break;
                }

                Clear();

            } while (appliationRunning);
                
        }
    }
}
