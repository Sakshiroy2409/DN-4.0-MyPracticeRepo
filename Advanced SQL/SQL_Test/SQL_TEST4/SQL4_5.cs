 using System;
using Microsoft.Data.SqlClient;

namespace SQL_TEST4
{
    internal class SQL4_5
    {
        public static void Run()
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=TEST01;Trusted_Connection=True;Encrypt=False;";

            string query = "SELECT EmployeeID, FirstName, LastName, Salary FROM Employees WHERE Salary > 50000;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["EmployeeID"]}, Name: {reader["FirstName"]} {reader["LastName"]}, Salary: {reader["Salary"]}");
                }
            }
        }
    }
}