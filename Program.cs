using System;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Console.WriteLine("1. Add TODO");
            Console.WriteLine("2. Exit");

            var input = Console.ReadKey(true);
            
        }
    }
}
