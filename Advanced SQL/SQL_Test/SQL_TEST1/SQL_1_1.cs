using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Use your actual database name
        string connectionString = @"Server=localhost\SQLEXPRESS;Database=TEST01;Trusted_Connection=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connected successfully!\n");

                string query = @"
                -- ROW_NUMBER(): Top 3 expensive products per category
                SELECT * FROM (
                    SELECT 
                        ProductID,
                        ProductName,
                        Category,
                        Price,
                        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
                    FROM Products
                ) AS Ranked
                WHERE RowNum <= 3;

                -- RANK(): Show how ties are handled
                SELECT 
                    ProductID,
                    ProductName,
                    Category,
                    Price,
                    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS Rank
                FROM Products;

                -- DENSE_RANK(): Show how dense rank handles ties
                SELECT 
                    ProductID,
                    ProductName,
                    Category,
                    Price,
                    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRank
                FROM Products;
                ";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("=== ROW_NUMBER() Top 3 Per Category ===");
                while (reader.Read())
                {
                    Console.WriteLine($"[ROW_NUMBER] {reader["Category"]} - {reader["ProductName"]} - ${reader["Price"]}");
                }

                // Move to next result set (RANK)
                reader.NextResult();
                Console.WriteLine("\n=== RANK() Example ===");
                while (reader.Read())
                {
                    Console.WriteLine($"[RANK] {reader["Category"]} - {reader["ProductName"]} - ${reader["Price"]} - Rank: {reader["Rank"]}");
                }

                // Move to next result set (DENSE_RANK)
                reader.NextResult();
                Console.WriteLine("\n=== DENSE_RANK() Example ===");
                while (reader.Read())
                {
                    Console.WriteLine($"[DENSE_RANK] {reader["Category"]} - {reader["ProductName"]} - ${reader["Price"]} - DenseRank: {reader["DenseRank"]}");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}