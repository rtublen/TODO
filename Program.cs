using System;
using static System.Console;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            CursorVisible = false;

            bool applicationRunnning = true;

            do
            {
                WriteLine("1. Add employee");
                WriteLine("2. Exit");

                ConsoleKeyInfo input = ReadKey(true);

                Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        break;

                    case ConsoleKey.D2:

                        break;
                }

            } while (applicationRunnning);
        }
    }
}
