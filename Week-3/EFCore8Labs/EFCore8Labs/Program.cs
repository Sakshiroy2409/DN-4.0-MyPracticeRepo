using EFCore8Labs.Labs;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== EF Core 8 Labs ===\n");

        // Run all labs in sequence
        Lab1.Run();
        Lab2.Run();
        Lab3.Run();

        await Lab4.RunAsync();
        await Lab5.RunAsync();

        Console.WriteLine("\nAll labs executed successfully.");
    }
}