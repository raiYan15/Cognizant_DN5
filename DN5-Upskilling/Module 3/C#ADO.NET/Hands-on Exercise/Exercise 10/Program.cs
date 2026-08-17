namespace Exercise10;

public class Car
{
    // Properties
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public double Mileage { get; set; }

    // 1. Default (Parameterless) Constructor
    public Car()
    {
        Make = "Unknown";
        Model = "Generic Sedan";
        Year = DateTime.Now.Year;
        Mileage = 0.0;
    }

    // 2. Parameterized Constructor
    public Car(string make, string model, int year, double mileage)
    {
        Make = make;
        Model = model;
        Year = year;
        Mileage = mileage;
    }

    // 3. Overloaded Constructor (Convenience)
    public Car(string make, string model) : this(make, model, DateTime.Now.Year, 0.0)
    {
    }

    // Method to display car info
    public void DisplayDetails()
    {
        Console.WriteLine($"Car: {Year} {Make} {Model} | Mileage: {Mileage:N1} miles");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 10: OOP Basics with Constructors");
        Console.WriteLine("=================================================\n");

        // Object using Default Constructor
        Console.WriteLine("[1] Car instantiated with Default Constructor:");
        Car car1 = new();
        car1.DisplayDetails();

        // Object using Parameterized Constructor
        Console.WriteLine("\n[2] Car instantiated with Parameterized Constructor:");
        Car car2 = new("Tesla", "Model 3", 2024, 12500.5);
        car2.DisplayDetails();

        // Object using Overloaded Chained Constructor
        Console.WriteLine("\n[3] Car instantiated with Chained Constructor:");
        Car car3 = new("Ford", "Mustang Mach-E");
        car3.DisplayDetails();

        Console.WriteLine("=================================================");
    }
}
