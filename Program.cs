using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace TODO
{
    class Program
    {
        static void Main()
        {
            string todoPath = Path.GetFullPath(@"..\..\..\DataBase\TodoFile.txt");

            //List<string> todoList = File.ReadAllLines(todoPath).ToList();
            string answer = string.Empty;
            int top = 2;
            int left = 5;

            do
            {
                Console.Clear();
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"1. Add todo");
                Console.SetCursorPosition(left, top + 2);
                Console.WriteLine($"2. Delete todo");
                Console.SetCursorPosition(left, top + 4);
                Console.WriteLine($"3. Exit ");
                Console.SetCursorPosition(left, top + 6);
                Console.WriteLine($"Please choose on of the options above:");

                Regex keyOptionRegex = new Regex(@"[1-3]$");
                string keyOption;
                List<string> todoList;
                do
                {
                    todoList = File.ReadAllLines(todoPath).ToList();
                    Console.SetCursorPosition(left + 39, top + 6);
                    Console.WriteLine("                      ");
                    Console.SetCursorPosition(left + 39, top + 6);
                    keyOption = Console.ReadKey().KeyChar.ToString();
                } while (!keyOptionRegex.IsMatch(keyOption));

                AddOptions userOption = (AddOptions)int.Parse(keyOption) - 1;

                switch (userOption)
                {
                    case AddOptions.AddTodo:

                        do
                        {
                            Console.Clear();
                            int todoNumber = File.ReadAllLines(todoPath).Length + 1;

                            Console.SetCursorPosition(left, top + 1);
                            Console.Write($@"Do you want to add in to TODO List? Y/N ");

                            PrintTodoList(todoPath, left, top);

                            Regex answerRegex = new Regex(@"[yYnN]$");
                            do
                            {
                                Console.SetCursorPosition(left + 41, top + 1);//70
                                Console.WriteLine("   ");
                                Console.SetCursorPosition(left + 41, top + 1); //70
                                answer = Console.ReadKey().KeyChar.ToString().ToUpper();
                            } while (!answerRegex.IsMatch(answer));

                            Console.SetCursorPosition(left, top + 1);
                            Console.Write($@"                                               ");

                            if (answer == "Y")
                            {
                                Console.SetCursorPosition(left, top + 1); 
                                Console.WriteLine("Please write what you have to do then press enter:\n");
                                Console.SetCursorPosition(left, top + 3);
                                Console.WriteLine("Please Enter the due date:\n");

                                Regex todoTextRegex = new Regex(@"^[A-Za-z0-9]+");
                                string todo;
                                do
                                {
                                    Console.SetCursorPosition(left + 51, top + 1); 
                                    Console.Write($"{todoNumber}. ");
                                    PrintTodoList(todoPath, left, top);
                                    Console.SetCursorPosition(left + 54, top + 1); 
                                    todo = Console.ReadLine();

                                } while (!todoTextRegex.IsMatch(todo ?? string.Empty));


                                //Console.SetCursorPosition(left, top + 1); 
                                //Console.WriteLine("                                                                ");
                                //Console.SetCursorPosition(left, top + 3);
                                //Console.WriteLine("                                                                ");

                                //Console.SetCursorPosition(left, top + 1); //30
                                //Console.WriteLine("Please Enter the due date:\n");

                                Regex todoDateRegex = new Regex(@"^[0-9]+");
                                string todoDate;
                                do
                                {
                                    Console.SetCursorPosition(left+27, top + 3); //30
                                    Console.Write($"{todoNumber}. ");
                                    PrintTodoList(todoPath, left, top);
                                    Console.SetCursorPosition(left+31, top + 3); //30
                                    todoDate = Console.ReadLine();

                                } while (!todoDateRegex.IsMatch(todoDate ?? string.Empty));

                                todo = todo + ":" + todoDate;

                                Console.Clear();

                                todoList.Add(todo);
                                File.WriteAllLines(todoPath, todoList);
                            }

                            PrintTodoList(todoPath, left, top);

                        } while (answer == "Y");

                        Console.Clear();
                        answer = "Y";
                        break;

                    case AddOptions.Delete:

                        do
                        {
                            Console.Clear();
                            Console.SetCursorPosition(left, top + 1);
                            Console.Write($@"Do you want to Delete from TODO List? Y/N ");

                            PrintTodoList(todoPath, left, top);

                            Regex annswerRegex = new Regex(@"[yYnN]$");
                            do
                            {
                                Console.SetCursorPosition(left + 42, top + 1); //72
                                Console.WriteLine("   ");
                                Console.SetCursorPosition(left + 42, top + 1);  //72
                                answer = Console.ReadKey().KeyChar.ToString().ToUpper();
                            } while (!annswerRegex.IsMatch(answer));

                            if (answer == "Y" && todoList.Count > 0)
                            {
                                Console.SetCursorPosition(left, top + 1);
                                Console.Write($@"                                                         ");

                                Console.SetCursorPosition(left, top + 1);
                                Console.Write($@"Please enter Line number you want to delete: ");

                                Regex lineNumberRegex = new Regex(@"^[1-9][0-9]*");
                                string lineNumber;
                                do
                                {
                                    Console.SetCursorPosition(left + 45, top + 1);  //74
                                    Console.WriteLine("                   ");
                                    Console.SetCursorPosition(left + 45, top + 1);  //74
                                    lineNumber = Console.ReadLine();
                                    if (!lineNumberRegex.IsMatch(lineNumber ?? throw new InvalidOperationException()) || int.Parse(lineNumber) > todoList.Count)
                                    {
                                        Console.SetCursorPosition(left, top + 3);
                                        Console.WriteLine("Invalid line's number! Pleas try again...");
                                        Thread.Sleep(2000);
                                        Console.SetCursorPosition(left, top + 3);
                                        Console.WriteLine("                                          ");
                                        lineNumber = "IsWrong";
                                    }

                                } while (!lineNumberRegex.IsMatch(lineNumber));


                                todoList = File.ReadAllLines(todoPath).ToList();
                                todoList.RemoveAt(int.Parse(lineNumber) - 1);


                            }
                            File.WriteAllLines(todoPath, todoList);
                            Console.Clear();
                            PrintTodoList(todoPath, left, top);

                        } while (answer == "Y");

                        answer = "Y";
                        break;

                    case AddOptions.Exit:
                        Console.Clear();
                        Console.SetCursorPosition(left, 10); //40
                        Console.WriteLine("TODO App is going to be closed ...");
                        Console.SetCursorPosition(0, 22);
                        Thread.Sleep(2000);
                        answer = "N";
                        break;
                }

            } while (answer == "Y");

        }

        public static void PrintTodoList(string path, int left, int top)
        {
            List<string> todoList = File.ReadAllLines(path).ToList();
            top = top + 5;
            //int left = 5; //30

            if (todoList.Count == 0)
            {

                Console.SetCursorPosition(left, top);  //30
                Console.WriteLine($" {"List To Do",-23} {"Date",-10}");
                Console.SetCursorPosition(left, top + 1);//30
                Console.WriteLine("====================================");
                Console.SetCursorPosition(left, top + 3); //30
                Console.WriteLine(">>ToDo List is empty!<<");

            }
            else
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($" {"List To Do",-23} {"Date", -10}");
                Console.SetCursorPosition(left, top + 1);
                Console.WriteLine("====================================");
                int n = 1;
                int m = 1;
                foreach (var action in todoList)
                {
                    var actionSplit = action.Split(":"); 
                    if (m < 10)
                    {
                        Console.SetCursorPosition(left, top + 2 + n);
                        Console.WriteLine($"0{m}. {actionSplit[0],-20} {actionSplit[1],-10} ");
                    }
                    else
                    {
                        Console.SetCursorPosition(left, top + 2 + n);
                        Console.WriteLine($"{m}. {action[0],-20} {action[1],-10}");
                    }

                    n += 2;
                    m++;
                }
            }


        }
    }

    public enum AddOptions
    {
        AddTodo,
        Delete,
        Exit
    }

}
