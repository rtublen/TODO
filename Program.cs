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

        public static List<MyTask> MyTaskList = new List<MyTask>();

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


        private static void ListTasks()
        {
            string sql = "SELECT Id, Name, DueDate FROM MyTask";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Id   Name                          Due Date");
                Console.WriteLine("--------------------------------------------------");

                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var name = (string)reader["Name"];
                    var dueDate = reader["DueDate"];

                    Console.WriteLine($"{id}   {name,-20}           {dueDate,-50}");
                }

                connection.Close();
            }

            // Provide further actions choice
            ProvideDeletingOption();

            Console.Clear();
        }

        private static void ProvideDeletingOption()
        {
            // Provide further actions choice
            Console.WriteLine("\n[D] Delete [Esc] Main Menu");
            ConsoleKeyInfo furtherChoice;
            bool furtherChoiceOk;
            do
            {
                furtherChoice = Console.ReadKey(true);
                furtherChoiceOk = furtherChoice.Key == ConsoleKey.D ||
                                  furtherChoice.Key == ConsoleKey.Escape;
            } while (!furtherChoiceOk);


            // Respond to further actions choice
            switch (furtherChoice.Key)
            {
                // D. Delete specified Task
                case ConsoleKey.D:
                    Console.Write("\nID: ");
                    bool inputIdOk = int.TryParse(Console.ReadLine(), out int inputId);

                    if (inputIdOk && ContainsTask(inputId))
                    {
                        DeleteTask(inputId);
                        Console.WriteLine("\nTask deleted");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.WriteLine("\nTask with specified id was not found");
                        Thread.Sleep(2000);
                    }

                    break;

                // Esc. Go back to previous menu
                case ConsoleKey.Escape:
                    break;
            }
        }

        private static bool ContainsTask(int taskId)
        {
            bool containsTask;

            // Specify sql command
            string sql = @"
                        SELECT * FROM MyTask
                        WHERE Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                // Add parameters to sql command
                command.Parameters.AddWithValue("@Id", taskId);

                // Open connection
                connection.Open();

                // Instantiate SqlDataReader
                SqlDataReader reader = command.ExecuteReader();

                // Check if there is a row to read (if there is a task with specified id)
                if (reader.Read()) containsTask = true;
                else containsTask = false;

                // Close connection
                connection.Close();
            }

            return containsTask;
        }

        private static void DeleteTask(int taskId)
        {
            // Specify sql command
            string sql = @"
                        DELETE FROM MyTask
                        WHERE Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                // Add parameters to sql command
                command.Parameters.AddWithValue("@Id", taskId);

                // Open connection
                connection.Open();

                // Execute command
                command.ExecuteNonQuery();

                // Close connection
                connection.Close();
            }
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

                    else if (DateTime.TryParseExact(dueDateString, "yyyy-MM-dd", CultureInfo.CurrentCulture,
                        DateTimeStyles.None, out DateTime dueDate))
                    {
                        myTask = new MyTask(name: taskName, dueDate: dueDate);
                    }
                    else
                    {
                        throw new ArgumentException(
                            "DueDate was of invalid format or empty, please use the format yyyy-MM-dd", "DueDate");
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
            string sql;

            if (myTask.DueDate != null)
            {
                sql = $@"
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
            else
            {
                sql = $@"
                INSERT INTO MyTask (Name)
                VALUES (@Name)";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Name", myTask.Name);
                
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }


        }


    }
}