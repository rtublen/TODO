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





        private static IList<MyTask> FetchMyTasks()
        {
            string sql = @"
                         SELECT Id, Name, DueDate FROM MyTask
                         WHERE CompletedAt IS NULL";

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
                    if (reader.IsDBNull(2))
                    {
                        myTaskList.Add(new MyTask(id, name, null));
                    }
                    else
                    {
                        var dueDate = (DateTime)reader["DueDate"];
                        myTaskList.Add(new MyTask(id, name, dueDate));
                    }
                }

                connection.Close();
            }
            return myTaskList;
        }

        private static void ListTasks()
        {
            bool listNavigationOn = true;
            do
            {
                var myTaskList = FetchMyTasks();
                
                Console.WriteLine($"{"Name",-50}Due Date");
                Console.WriteLine("============================================================");

                foreach (var myTask in myTaskList)
                {
                    Console.WriteLine($"{myTask.Name,-50}{(myTask.DueDate.HasValue ? myTask.DueDate.Value.ToShortDateString() : "")}");
                }

                Console.CursorTop++;
                Console.WriteLine("[C] Complete | [D] Delete | [Esc] Return");
                ConsoleKeyInfo input;

                while (
                    (input = Console.ReadKey(true)).Key != ConsoleKey.C &&
                    input.Key != ConsoleKey.D &&
                    input.Key != ConsoleKey.Escape)
                { }

                if (input.Key == ConsoleKey.C) MarkTaskAsCompleteFrom(myTaskList);
                else if (input.Key == ConsoleKey.D) RemoveTask(myTaskList);
                else if (input.Key == ConsoleKey.Escape) listNavigationOn = false;
                
                Console.Clear();

            } while (listNavigationOn);
        }

        private static void MarkTaskAsCompleteFrom(IList<MyTask> myTaskList)
        {
            ListTasksShortVersion();

            Console.CursorVisible = true;
            Console.CursorTop++;
            Console.Write("ID: ");

            bool idOk = int.TryParse(Console.ReadLine(), out int idToMarkAsComplete);
            Console.CursorVisible = false;

            if (idOk && MarkAsComplete(idToMarkAsComplete)) Console.WriteLine("Task completed");
            else Console.WriteLine("Task not found");

            Thread.Sleep(3000);
        }

        private static bool MarkAsComplete(int idToMarkAsComplete)
        {
            // Specify sql command
            string sql = @"
                        UPDATE MyTask
                        SET CompletedAt = @CompletedAt
                        WHERE Id=@Id";

            int numberOfRowsAffected;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                // Add parameters to sql command
                command.Parameters.AddWithValue("@Id", idToMarkAsComplete);
                command.Parameters.AddWithValue("@CompletedAt", DateTime.Today);

                // Open connection
                connection.Open();

                // Execute command
                numberOfRowsAffected = command.ExecuteNonQuery();

                // Close connection
                connection.Close();
            }

            return numberOfRowsAffected > 0;
        }

        private static void RemoveTask(IList<MyTask> myTaskList)
        {
            ListTasksShortVersion();

            Console.CursorVisible = true;
            Console.CursorTop++;
            Console.Write("ID: ");

            bool idOk = int.TryParse(Console.ReadLine(), out int idToRemove);
            Console.CursorVisible = false;

            if (idOk && DeleteTask(idToRemove)) Console.WriteLine("Task Deleted");
            else Console.WriteLine("Task not found");

            Thread.Sleep(2000);
        }

        private static void ListTasksShortVersion()
        {
            var myTaskList = FetchMyTasks();

            Console.Clear();
            Console.WriteLine($"{"ID",-4}{"Name",-50}Due Date");
            Console.WriteLine("================================================================");

            foreach (var myTask in myTaskList)
            {
                Console.WriteLine(
                    $"{myTask.Id,-4}{myTask.Name,-50}{(myTask.DueDate.HasValue ? myTask.DueDate.Value.ToShortDateString() : "")}");
            }
        }

        private static bool DeleteTask(int idToRemove)
        {
            var sql = $@"
                DELETE FROM MyTask
                WHERE Id = @Id";

            int numberOfRowsAffected;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Id", idToRemove);

                connection.Open();
                numberOfRowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }

            return numberOfRowsAffected > 0;
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
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            if (!(myTask.DueDate == null))
            {
                var sql = $@"
                INSERT INTO MyTask (Name, DueDate)
                VALUES (@Name, @DueDate)";

                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Name", myTask.Name);

                command.Parameters.AddWithValue("@DueDate", myTask.DueDate);

            }
            else
            {
                var sql = $@"
                INSERT INTO MyTask (Name)
                VALUES (@Name)";

                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Name", myTask.Name);

            }


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}