namespace Exercise7;

public class OrderCalculator
{
    // Overload 1: Base price and quantity
    public double CalculateTotal(double unitPrice, int quantity)
    {
        return unitPrice * quantity;
    }

    // Overload 2: Base price, quantity, and tax percentage
    public double CalculateTotal(double unitPrice, int quantity, double taxPercentage)
    {
        double subtotal = unitPrice * quantity;
        return subtotal + (subtotal * (taxPercentage / 100.0));
    }

    // Overload 3: Base price, quantity, tax percentage, and flat discount
    public double CalculateTotal(double unitPrice, int quantity, double taxPercentage, double flatDiscount)
    {
        double subtotal = unitPrice * quantity;
        double withTax = subtotal + (subtotal * (taxPercentage / 100.0));
        return Math.Max(0, withTax - flatDiscount);
    }

    // Overload 4: Array of item prices with tax
    public double CalculateTotal(double[] itemPrices, double taxPercentage)
    {
        double subtotal = 0;
        foreach (var price in itemPrices) subtotal += price;
        return subtotal + (subtotal * (taxPercentage / 100.0));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 7: Method Overloading (CalculateTotal)");
        Console.WriteLine("=================================================\n");

        OrderCalculator calc = new();

        // 1. Basic total
        double total1 = calc.CalculateTotal(50.0, 3);
        Console.WriteLine($"[1] Price: $50.00 x 3              -> Total: ${total1:F2}");

        // 2. Total with tax
        double total2 = calc.CalculateTotal(50.0, 3, 8.5);
        Console.WriteLine($"[2] Price: $50.00 x 3 + 8.5% Tax   -> Total: ${total2:F2}");

        // 3. Total with tax and discount
        double total3 = calc.CalculateTotal(50.0, 3, 8.5, 20.0);
        Console.WriteLine($"[3] With 8.5% Tax - $20.00 Disc    -> Total: ${total3:F2}");

        // 4. Multiple items total
        double[] cart = { 19.99, 45.50, 8.25, 120.00 };
        double total4 = calc.CalculateTotal(cart, 7.0);
        Console.WriteLine($"[4] Multi-Item Cart (4 items) + 7% -> Total: ${total4:F2}");

        Console.WriteLine("=================================================");
    }
}
