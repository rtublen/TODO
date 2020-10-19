using System;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while(true)
            {
                MainMenu();
            }

            


        }

        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Add todo");
            Console.WriteLine("2. Exit");


            bool validInput = false;


            while(!validInput){

                var userKeyInput = Console.ReadKey(true);

                switch (userKeyInput.Key)
                {
                    case ConsoleKey.D1:
                        validInput = true;
                        //...
                        
                        break;
                    case ConsoleKey.D2:
                        validInput = true;
                        //...
                        break;

                    default:
                        break;
                }

            }
        }



    }
}
