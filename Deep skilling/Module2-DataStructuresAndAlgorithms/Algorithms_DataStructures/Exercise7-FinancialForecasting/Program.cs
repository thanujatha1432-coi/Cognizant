using System;

class FinancialForecast
{
    public static double CalculateFutureValue(
        double presentValue,
        double growthRate,
        int years)
    {
        if (years == 0)
        {
            return presentValue;
        }

        return CalculateFutureValue(
            presentValue,
            growthRate,
            years - 1
        ) * (1 + growthRate);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Financial Forecasting ===");

        Console.Write("Enter Present Value: ");
        double presentValue = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Annual Growth Rate (%): ");
        double percentage = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Number of Years: ");
        int years = Convert.ToInt32(Console.ReadLine());

        double growthRate = percentage / 100;

        double futureValue =
            FinancialForecast.CalculateFutureValue(
                presentValue,
                growthRate,
                years
            );

        Console.WriteLine("\nForecast Details");
        Console.WriteLine("----------------");
        Console.WriteLine("Present Value : " + presentValue.ToString("F2"));
        Console.WriteLine("Growth Rate   : " + percentage.ToString("F2") + "%");
        Console.WriteLine("Years         : " + years);
        Console.WriteLine("Future Value  : " + futureValue.ToString("F2"));

        Console.WriteLine("\nTime Complexity  : O(n)");
        Console.WriteLine("Space Complexity : O(n)");
    }
}