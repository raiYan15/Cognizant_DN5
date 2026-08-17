namespace Exercise21;

public record User(string Name, string Role);
public record EventSession(string Title, int DurationMinutes);

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 21: Advanced Pattern Matching (is & switch)");
        Console.WriteLine("=================================================\n");

        object[] mixedData = {
            100,
            -25,
            "Hello C# World",
            "",
            new User("Alice Johnson", "Admin"),
            new User("Bob Martinez", "Participant"),
            new EventSession("Solar Grid Optimization", 90),
            new EventSession("Lightning Talk", 15),
            3.14159,
            null!
        };

        foreach (var item in mixedData)
        {
            Console.WriteLine(DescribeItem(item));
        }

        Console.WriteLine("=================================================");
    }

    static string DescribeItem(object? obj) => obj switch
    {
        null => "-> Null value detected.",

        // Type + Property pattern on User record
        User { Role: "Admin" } u => $"-> Administrator: {u.Name} (Has Full Permissions)",
        User u => $"-> Regular User: {u.Name} with role '{u.Role}'",

        // Type + Relational property pattern on EventSession
        EventSession { DurationMinutes: <= 30 } s => $"-> Short Session: \"{s.Title}\" ({s.DurationMinutes} mins)",
        EventSession s => $"-> Standard Session: \"{s.Title}\" ({s.DurationMinutes} mins)",

        // Relational and logical patterns on primitives
        int n and > 0 and <= 100 => $"-> Positive Integer in range [1..100]: {n}",
        int n and < 0 => $"-> Negative Integer: {n}",
        int n => $"-> Large Integer: {n}",

        // String patterns
        string s when string.IsNullOrWhiteSpace(s) => "-> Empty or whitespace string",
        string s => $"-> String literal: \"{s}\" (Length: {s.Length})",

        // Catch-all
        var other => $"-> Other Type: {other.GetType().Name} with value {other}"
    };
}
