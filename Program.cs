using System;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menuRunning = true;
            do
            {
                Console.Clear();

                Console.WriteLine("1. Add todo");
                Console.WriteLine("2. Exit");

                ConsoleKeyInfo menuInput = Console.ReadKey(true);

                switch (menuInput.Key)
                {
                    
                    case ConsoleKey.D1:
                        {
                            Console.WriteLine("Add todo.");
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            Console.WriteLine("Exiting");

                            menuRunning = false;

                            break;
                        }
                }
            } while (menuRunning);


        }
    }
}
