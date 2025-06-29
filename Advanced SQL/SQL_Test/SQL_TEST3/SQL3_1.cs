using System;
using System.Data.SqlClient;

namespace EmployeeViewApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Your actual server and database details
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=TEST01;Trusted_Connection=True;";

            string query = "SELECT EmployeeID, FirstName, LastName, DepartmentName FROM vw_EmployeeBasicInfo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    Console.WriteLine("Employee Details:");
                    Console.WriteLine("----------------------------------");

                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["EmployeeID"]}, Name: {reader["FirstName"]} {reader["LastName"]}, Department: {reader["DepartmentName"]}");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}