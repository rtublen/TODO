using System;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {

            CursorVisible = false;

            var isApplicationRunning = true;

            do
            {
                WriteLine("1. Add todo");
                WriteLine("2. Exit");

                var menuSelection = ReadKey(true);

                Clear();

                switch (menuSelection.Key)
                {
                    case ConsoleKey.D1:

                        break;

                    
                    case ConsoleKey.D2:

                        isApplicationRunning = false;

                        break;

                }

            } while (isApplicationRunning);

        }
    }
}
