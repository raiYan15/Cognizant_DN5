namespace Exercise13;

// Positional record with init-only properties
public record Employee(int Id, string FullName, string Department, decimal Salary, string Role);

// Record using property syntax with init
public record Project
{
    public required string ProjectCode { get; init; }
    public required string Title { get; init; }
    public decimal Budget { get; init; }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 13: Records with init & 'with' Mutation");
        Console.WriteLine("=================================================\n");

        // 1. Create original immutable record
        Employee emp1 = new(101, "Marcus Vance", "Engineering", 85000.00m, "Software Engineer");
        Console.WriteLine("[1] Original Employee Record (emp1):");
        Console.WriteLine($"    {emp1}\n");

        // 2. Non-destructive mutation using 'with' expression
        Employee emp2 = emp1 with { Salary = 98000.00m, Role = "Senior Software Engineer" };
        Console.WriteLine("[2] Mutated Employee Record via 'with' (emp2):");
        Console.WriteLine($"    {emp2}\n");

        // 3. Verify original remains completely unchanged
        Console.WriteLine("[3] Verifying Original Employee (emp1) Unchanged:");
        Console.WriteLine($"    emp1 Salary: ${emp1.Salary:N2} | Role: {emp1.Role}");
        Console.WriteLine($"    emp2 Salary: ${emp2.Salary:N2} | Role: {emp2.Role}\n");

        // 4. Value Equality comparison in records
        Employee emp3 = new(101, "Marcus Vance", "Engineering", 85000.00m, "Software Engineer");
        Console.WriteLine("[4] Record Value Equality Check:");
        Console.WriteLine($"    emp1 == emp3 : {emp1 == emp3} (Same data -> True)");
        Console.WriteLine($"    emp1 == emp2 : {emp1 == emp2} (Different data -> False)");
        Console.WriteLine("=================================================");
    }
}
