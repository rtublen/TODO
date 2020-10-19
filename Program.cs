using System.ComponentModel.Design;
using System;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            bool appIsRunning = true;
            do
            {
                Console.WriteLine("1. Add todo");
                Console.WriteLine("2. Exit");

                ConsoleKeyInfo input = Console.ReadKey(true);
                bool inputOk = input.Key == ConsoleKey.D1 ||input.Key == ConsoleKey.D2;

                while(!inputOk) 
                {
                    input = Console.ReadKey(true);
                    inputOk = input.Key == ConsoleKey.D1 ||input.Key == ConsoleKey.D2;
                }
                
    
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("You pushed 'Add to do'");
                        Console.ReadKey(true);
                        break; 

                    case ConsoleKey.D2:
                        appIsRunning = false;
                        break;
                }


            } while (appIsRunning);


            
        }
    }
}
