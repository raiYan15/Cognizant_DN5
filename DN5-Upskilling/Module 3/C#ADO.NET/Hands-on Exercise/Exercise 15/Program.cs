namespace Exercise15;

// 1. Interface (Defines capability / behavioral contract)
public interface IDrivable
{
    void Drive(double distanceKm);
    void Brake();
}

public interface IRefuelable
{
    void Refuel(double amount);
}

// 2. Abstract Class (Provides core identity & common state/methods)
public abstract class Vehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public double FuelLevel { get; protected set; }

    public Vehicle(string brand, string model, double initialFuel)
    {
        Brand = brand;
        Model = model;
        FuelLevel = initialFuel;
    }

    // Concrete method shared by all vehicles
    public void DisplayVehicleStatus()
    {
        Console.WriteLine($"Vehicle: {Brand} {Model} | Fuel/Energy: {FuelLevel:F1}%");
    }

    // Abstract method that MUST be implemented by derived classes
    public abstract void StartEngine();
}

// 3. Concrete Class implementing Abstract Class and Multiple Interfaces
public class Car : Vehicle, IDrivable, IRefuelable
{
    public Car(string brand, string model, double initialFuel)
        : base(brand, model, initialFuel)
    {
    }

    public override void StartEngine()
    {
        Console.WriteLine($"[Car] {Brand} {Model} engine started with a smooth ignition.");
    }

    public void Drive(double distanceKm)
    {
        FuelLevel = Math.Max(0, FuelLevel - (distanceKm * 0.15));
        Console.WriteLine($"[Car] Drove {distanceKm} km. Remaining fuel: {FuelLevel:F1}%");
    }

    public void Brake()
    {
        Console.WriteLine($"[Car] {Brand} {Model} brakes engaged safely.");
    }

    public void Refuel(double amount)
    {
        FuelLevel = Math.Min(100.0, FuelLevel + amount);
        Console.WriteLine($"[Car] Refueled +{amount}%. Current fuel: {FuelLevel:F1}%");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 15: Abstract Classes vs Interfaces");
        Console.WriteLine("=================================================\n");

        Car myCar = new("Toyota", "RAV4 Hybrid", 80.0);

        // Polymorphism via Abstract Class reference
        Vehicle vehicleRef = myCar;
        vehicleRef.DisplayVehicleStatus();
        vehicleRef.StartEngine();
        Console.WriteLine();

        // Polymorphism via Interface references
        IDrivable drivableRef = myCar;
        drivableRef.Drive(45.0);
        drivableRef.Brake();
        Console.WriteLine();

        IRefuelable refuelableRef = myCar;
        refuelableRef.Refuel(15.0);

        Console.WriteLine("\n-------------------------------------------------");
        Console.WriteLine("Key Architectural Differences:");
        Console.WriteLine(" • Abstract Class : Represents 'IS-A' relationship, provides shared state & base logic.");
        Console.WriteLine(" • Interface      : Represents 'CAN-DO' capability contract, supports multiple inheritance.");
        Console.WriteLine("=================================================");
    }
}
