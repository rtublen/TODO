using System;

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
                Console.WriteLine("1. Add todo");
                Console.WriteLine("2. Exit");

                ConsoleKeyInfo input = ReadKey(true);

                Console.Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        Console.Write("TODO: ");
                        string userInput = Console.ReadLine();
                        break;

                    case ConsoleKey.D2:
                        appliationRunning = false;
                        break;
                }

            } while (appliationRunning);
                
        }
    }
}
