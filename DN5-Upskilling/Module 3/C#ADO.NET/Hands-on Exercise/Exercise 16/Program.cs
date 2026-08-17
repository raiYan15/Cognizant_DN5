#nullable enable
namespace Exercise16;

public class Person
{
    public string Name { get; set; }
    public string? MiddleName { get; set; }
    public string? Email { get; set; }

    public Person(string name, string? middleName = null, string? email = null)
    {
        Name = name;
        MiddleName = middleName;
        Email = email;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 16: Safe Null Reference Handling");
        Console.WriteLine("=================================================\n");

        Person p1 = new("Alice Johnson", "Marie", "alice@example.com");
        Person? p2 = new("Bob Martinez", null, null);
        Person? p3 = null;

        // 1. Null-Conditional Operator (?.)
        Console.WriteLine("[1] Null-Conditional Operator (?.):");
        Console.WriteLine($"    p1 Name Length : {p1.Name.Length}");
        Console.WriteLine($"    p2 Middle Length: {p2?.MiddleName?.Length} (Evaluated safely to null)");
        Console.WriteLine($"    p3 Name        : {p3?.Name} (Evaluated safely to null)\n");

        // 2. Null-Coalescing Operator (??)
        Console.WriteLine("[2] Null-Coalescing Operator (??):");
        string middle1 = p1.MiddleName ?? "[No Middle Name]";
        string middle2 = p2.MiddleName ?? "[No Middle Name]";
        Console.WriteLine($"    p1 Middle Name : {middle1}");
        Console.WriteLine($"    p2 Middle Name : {middle2}\n");

        // 3. Null-Coalescing Assignment (??=)
        Console.WriteLine("[3] Null-Coalescing Assignment (??=):");
        p2.Email ??= "default.support@portal.org";
        Console.WriteLine($"    p2 Email after ??= : {p2.Email}\n");

        // 4. Pattern matching null check
        Console.WriteLine("[4] Pattern Matching Null Check (is not null):");
        if (p3 is null)
        {
            Console.WriteLine("    p3 is currently null. Safely bypassed operations!");
        }

        Console.WriteLine("=================================================");
    }
}
