namespace Exercise12;

public class Product
{
    // Auto-properties
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = "General";

    // Backing field for price validation
    private decimal _price;

    // Full property with backing field and business validation
    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Product price cannot be negative!");
            }
            _price = value;
        }
    }

    // Read-only computed auto-property
    public string ProductCode => $"PRD-{Category.ToUpper().Substring(0, 3)}-{Id:D4}";

    public void DisplayProduct()
    {
        Console.WriteLine($"[{ProductCode}] {Name,-20} | Category: {Category,-10} | Price: ${Price:F2}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 12: Auto-Properties & Backing Fields");
        Console.WriteLine("=================================================\n");

        // Valid Product
        Product p1 = new()
        {
            Id = 101,
            Name = "Solar Inverter 5kW",
            Category = "Electronics",
            Price = 799.99m
        };

        p1.DisplayProduct();

        // Testing Backing Field Validation with Negative Price
        Console.WriteLine("\nTesting Price Validation with Negative Value (-50.00)...");
        try
        {
            p1.Price = -50.00m;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"[Validation Success] Caught expected exception: {ex.Message}");
        }

        Console.WriteLine($"Confirmed Product Price remained: ${p1.Price:F2}");
        Console.WriteLine("=================================================");
    }
}
