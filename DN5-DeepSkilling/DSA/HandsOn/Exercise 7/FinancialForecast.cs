// DSA Exercise 7 - Financial Forecast using Recursion
public class FinancialForecast
{
    // Recursively predicts the future value of an investment
    // Base Case: if years == 0, return current value
    // Recursive Case: apply growth rate and reduce years by 1
    public static double PredictFutureValue(double currentValue, double growthRate, int years)
    {
        // Base Case
        if (years == 0)
            return currentValue;

        // Recursive Case
        return PredictFutureValue(
            currentValue * (1 + growthRate),
            growthRate,
            years - 1
        );
    }

    public static void Main(string[] args)
    {
        double presentValue = 10000.0;
        double growthRate   = 0.10; // 10%
        int    years        = 5;

        double futureValue = PredictFutureValue(presentValue, growthRate, years);

        Console.WriteLine($"Present Value        : ₹{presentValue}");
        Console.WriteLine($"Growth Rate          : {growthRate * 100}%");
        Console.WriteLine($"Years                : {years}");
        Console.WriteLine($"Predicted Future Value: ₹{futureValue:F2}");
    }
}
