using System;
using System.Threading;
using static System.Console;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {

            ConsoleKeyInfo menuSelection;
            bool programRunning = true;
            string tempTODO;
            do
            {
                WriteLine("1. Add TODO");
                WriteLine("2. Exit");

                menuSelection = ReadKey(true);
                Clear();

                switch (menuSelection.Key)
                {
                    case ConsoleKey.D1:
                        Write("TODO: ");
                        tempTODO = ReadLine();
                        
                        Clear();
                        Write("TODO ADDED (not really since this is a dummy program)"); //TODO : delete this when you add Add Todo functionallity
                        Thread.Sleep(2000);
                        break;

                    case ConsoleKey.D2:
                        programRunning = false;
                        Write("Quitting Program, goodbye");
                        Thread.Sleep(2000);
                        break;
                }
                Clear();

            } while (programRunning);

        }
    }
}
