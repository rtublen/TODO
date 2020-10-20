using TODO.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using static System.Console;

namespace TODO
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu mainMenu = new Menu(new string[] 
            {
                 "Add task", "Exit",
            });
            mainMenu.CreateNumberedMenu();
            ConsoleKey[] validChoices =
                    {
                        ConsoleKey.D1, ConsoleKey.NumPad1, ConsoleKey.D2,
                        ConsoleKey.NumPad2,
                    };
            ConsoleKey input = Menu.SeekCertainInput(validChoices);
            switch (input)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    WriteLine("Menuoption 1. Code will be added later...");
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    WriteLine("Menuoption 2. Code will be added later...");
                    break;
            }
        }
    }
}
