using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace TODO
{
    class Program
    {
        static string connectionString = "Server=localhost;Database=TODO;Integrated Security=True";

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool applicationRunning = true;

            do
            {
                Console.WriteLine("1. Add task");
                Console.WriteLine("2. List tasks");
                Console.WriteLine("3. Exit");

                ConsoleKeyInfo input = Console.ReadKey(true);
                Console.Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        AddTask();
                        break;

                    case ConsoleKey.D2:
                        ListTasks();



                        break;
                    case ConsoleKey.D3:
                        applicationRunning = false;
                        break;
                }
            } while (applicationRunning);
        }


        private static IList<MyTask> FetchMyTasks()
        {
            string sql = "SELECT Id, Name, DueDate FROM MyTask";

            List<MyTask> myTaskList = new List<MyTask>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var name = (string)reader["Name"];
                    var dueDate = (DateTime)reader["DueDate"];

                    myTaskList.Add(new MyTask(id, name, dueDate));
                }

                connection.Close();
            }
            return myTaskList;
        }

        private static void ListTasks()
        {
            bool isLookingAtList = true;
            do
            {

                var myTaskList = FetchMyTasks();

                Console.WriteLine("Task".PadLeft(5) + "Due Date".PadLeft(26));
                Console.WriteLine("----------------------------------------");

                foreach (var myTask in myTaskList)
                {
                    Console.WriteLine($" {myTask.Name}".PadRight(23) + $"{myTask.DueDate}");
                }

                Console.WriteLine("----------------------------------------");
                Console.WriteLine("\n(D)elete   (Esc) Main Menu");

                var input = Console.ReadKey(true);

                bool invalidInput;

                do
                {
                    invalidInput = !(input.Key == ConsoleKey.Escape 
                                     || input.Key == ConsoleKey.D);

                } while (invalidInput);

                switch (input.Key)
                {
                    case ConsoleKey.Escape:

                        isLookingAtList = false;

                        break;

                    case ConsoleKey.D:
                    {
                        Console.Clear();

                        Console.Write(" Id" + "Task".PadLeft(6) + "Due Date".PadLeft(27));
                        Console.WriteLine("\n------------------------------------");

                        foreach (var myTask in myTaskList)
                        {
                            Console.WriteLine($" {myTask.Id}".PadRight(5) + $"{myTask.Name}".PadRight(23) + $"{myTask.DueDate}");
                        }

                        Console.CursorVisible = true;

                        Console.Write("\nId: ");
                        string idToDelete = Console.ReadLine();

                        DeleteTaskFromDatabase(idToDelete);

                        Console.Clear();

                        Console.CursorVisible = false;

                        Console.WriteLine("Task deleted");

                        Thread.Sleep(2000);

                        isLookingAtList = false;
                        break;
                    }
                }
            } while (isLookingAtList);


            Console.Clear();
        }

        private static void DeleteTaskFromDatabase(string idToDelete)
        {
            var sql = @"
                DELETE FROM MyTask 
                WHERE Id = @Id";

            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            command.Parameters.AddWithValue("@Id", idToDelete);
            command.ExecuteNonQuery();

            connection.Close();
        }

        private static void AddTask()
        {

            while (true)
            {
                Console.Clear();
                Console.CursorVisible = true;
                Console.WriteLine("Task:  ");
                Console.WriteLine("Due date (yyyy-MM-dd):  ");
                Console.SetCursorPosition(36, 0);

                var taskName = Console.ReadLine();

                Console.SetCursorPosition(36, 1);
                var dueDateString = Console.ReadLine();
                Console.CursorVisible = false;
                Console.WriteLine("Is this correct? (Y)es (N)o ");
                var isCorrectInput = Console.ReadKey(true).Key;
                while (isCorrectInput != ConsoleKey.Y && isCorrectInput != ConsoleKey.N)
                {
                    isCorrectInput = Console.ReadKey(true).Key;
                }
                if (isCorrectInput == ConsoleKey.Y)
                {
                    MyTask myTask;

                    if (string.IsNullOrWhiteSpace(dueDateString))
                    {
                        myTask = new MyTask(name: taskName);
                    }

                    else if (DateTime.TryParseExact(dueDateString, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dueDate))
                    {
                        myTask = new MyTask(name: taskName, dueDate: dueDate);
                    }
                    else
                    {
                        throw new ArgumentException("DueDate was of invalid format or empty, please use the format yyyy-MM-dd", "DueDate");
                    }

                    InsertMyTask(myTask);

                    // MyTaskList.Add(myTask);

                    Console.WriteLine("Task registered.");
                    Thread.Sleep(2000);
                }
                else
                {
                    continue;
                }
                break;
            }
            Console.Clear();
        }

        private static void InsertMyTask(MyTask myTask)
        {
            var sql = $@"
                INSERT INTO MyTask (Name, DueDate)
                VALUES (@Name, @DueDate)";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Name", myTask.Name);
            command.Parameters.AddWithValue("@DueDate", myTask.DueDate);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}