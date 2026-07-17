using System;
using System.Collections.Generic;


namespace FinancialForecasting
{
    class FinancialCalculator
    {
        
        public static double FutureValueRecursive(double presentValue, double growthRate, int periods)
        {
            if (periods < 0)
                throw new ArgumentException("Periods cannot be negative.");
            if (periods == 0)
                return presentValue;                          
            return FutureValueRecursive(presentValue, growthRate, periods - 1) * (1 + growthRate);
        }

        
        private static Dictionary<int, double> memo = new Dictionary<int, double>();

        public static double FutureValueMemoized(double presentValue, double growthRate, int periods)
        {
            if (periods == 0)
                return presentValue;

            if (memo.ContainsKey(periods))
                return memo[periods];

            double result = FutureValueMemoized(presentValue, growthRate, periods - 1) * (1 + growthRate);
            memo[periods] = result;
            return result;
        }

        
        public static double FutureValueIterative(double presentValue, double growthRate, int periods)
        {
            double value = presentValue;
            for (int i = 0; i < periods; i++)
                value *= (1 + growthRate);
            return value;
        }

        
        public static double FutureValueFormula(double presentValue, double growthRate, int periods)
        {
            return presentValue * Math.Pow(1 + growthRate, periods);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double presentValue = 10_000.00; 
            double annualGrowthRate = 0.08;  
            int[] forecastYears = { 1, 5, 10, 20 };

            Console.WriteLine(" Financial Forecast (PV = $10,000 | Rate = 8%) \n");
            Console.WriteLine($"{"Years",-8} {"Recursive",-18} {"Memoized",-18} {"Iterative",-18} {"Formula",-18}");
            Console.WriteLine(new string('-', 80));

            foreach (int years in forecastYears)
            {
                double recursive  = FinancialCalculator.FutureValueRecursive(presentValue, annualGrowthRate, years);
                double memoized   = FinancialCalculator.FutureValueMemoized(presentValue, annualGrowthRate, years);
                double iterative  = FinancialCalculator.FutureValueIterative(presentValue, annualGrowthRate, years);
                double formula    = FinancialCalculator.FutureValueFormula(presentValue, annualGrowthRate, years);

                Console.WriteLine($"{years,-8} ${recursive,-17:F2} ${memoized,-17:F2} ${iterative,-17:F2} ${formula,-17:F2}");
            }

            Console.WriteLine("\n Approach Comparison ");
            Console.WriteLine("Recursive (naive)  : O(n) time, O(n) space – risk of stack overflow for large n.");
            Console.WriteLine("Memoized recursive : O(n) first call, O(1) cached – good when same n queried repeatedly.");
            Console.WriteLine("Iterative          : O(n) time, O(1) space – simple and safe for large n.");
            Console.WriteLine("Closed-form formula: O(1) time and space – best choice for single future-value queries.");
        }
    }
}
