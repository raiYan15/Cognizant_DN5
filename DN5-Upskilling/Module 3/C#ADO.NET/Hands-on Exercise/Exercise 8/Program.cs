namespace Exercise8;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 8: ref, out, and in Parameter Modifiers");
        Console.WriteLine("=================================================\n");

        // 1. 'ref' Modifier: Passed by reference, must be initialized before call
        int accountBalance = 1000;
        Console.WriteLine("[1] Demonstrating 'ref' parameter:");
        Console.WriteLine($"    Before ApplyBonus(ref balance): {accountBalance}");
        ApplyBonus(ref accountBalance, 250);
        Console.WriteLine($"    After ApplyBonus(ref balance) : {accountBalance}\n");

        // 2. 'out' Modifier: Callee MUST assign value before returning
        int dividend = 47, divisor = 6;
        Console.WriteLine("[2] Demonstrating 'out' parameter:");
        Divide(dividend, divisor, out int quotient, out int remainder);
        Console.WriteLine($"    Divide({dividend}, {divisor}) -> Quotient: {quotient}, Remainder: {remainder}\n");

        // 3. 'in' Modifier: Passed by reference for performance, but READ-ONLY
        double radius = 7.5;
        Console.WriteLine("[3] Demonstrating 'in' parameter (read-only reference):");
        double area = CalculateCircleArea(in radius);
        Console.WriteLine($"    Circle Radius: {radius} -> Area: {area:F4}");
        Console.WriteLine("=================================================");
    }

    // Modifies existing variable directly in-place
    static void ApplyBonus(ref int balance, int bonus)
    {
        balance += bonus;
    }

    // Returns multiple outputs via out
    static void Divide(int dividend, int divisor, out int quotient, out int remainder)
    {
        quotient = dividend / divisor;
        remainder = dividend % divisor;
    }

    // Read-only reference: avoids copying struct, prevents mutation
    static double CalculateCircleArea(in double r)
    {
        // r = 10; // Compiler Error: Cannot assign to variable 'in double' because it is read-only
        return Math.PI * r * r;
    }
}
