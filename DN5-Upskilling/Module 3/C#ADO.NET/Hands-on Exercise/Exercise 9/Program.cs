namespace Exercise9;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 9: Local Functions (CalculateFactorial)");
        Console.WriteLine("=================================================\n");

        int[] testNumbers = { 0, 1, 5, 7, 10, -3 };

        foreach (var num in testNumbers)
        {
            try
            {
                long result = CalculateFactorial(num);
                Console.WriteLine($"Factorial of {num,2}! = {result}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Factorial of {num,2}! = Error: {ex.Message}");
            }
        }
        Console.WriteLine("=================================================");
    }

    // Outer function: handles validation eagerly
    public static long CalculateFactorial(int n)
    {
        if (n < 0)
            throw new ArgumentOutOfRangeException(nameof(n), "Factorial is undefined for negative integers.");

        // Local function: encapsulating recursive calculation cleanly
        return FactorialInternal(n);

        long FactorialInternal(int value)
        {
            if (value <= 1) return 1;
            return value * FactorialInternal(value - 1);
        }
    }
}
