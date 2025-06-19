using System;
using System.Collections.Generic;

class FinancialForecast
{
    
    public static double FutureValue(double principal, double rate, int years)
    {
        if (years == 0)
            return principal;

        return FutureValue(principal, rate, years - 1) * (1 + rate);
    }

    
    public static double FutureValueMemo(double principal, double rate, int years, Dictionary<int, double> memo)
    {
        if (years == 0)
            return principal;

        if (memo.ContainsKey(years))
            return memo[years];

        double result = FutureValueMemo(principal, rate, years - 1, memo) * (1 + rate);
        memo[years] = result;
        return result;
    }

    static void Main()
    {
        double principal = 10000;   
        double rate = 0.1;          
        int years = 5;              

        Console.WriteLine("Recursive Future Value (Simple Recursion):");
        double value = FutureValue(principal, rate, years);
        Console.WriteLine($"After {years} years: {value:F2}");

        Console.WriteLine("\nRecursive Future Value (With Memoization):");
        Dictionary<int, double> memo = new Dictionary<int, double>();
        double valueMemo = FutureValueMemo(principal, rate, years, memo);
        Console.WriteLine($"After {years} years: {valueMemo:F2}");
    }
}