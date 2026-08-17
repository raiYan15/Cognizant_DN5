using System.Text.Json;

namespace Exercise24;

public class UserProfile
{
    public int UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public List<string> Interests { get; set; } = new();
    public bool IsActive { get; set; } = true;
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 24: JSON Serialization & Deserialization");
        Console.WriteLine("=================================================\n");

        UserProfile originalUser = new()
        {
            UserId = 101,
            FullName = "Alice Johnson",
            Email = "alice.j@example.com",
            City = "Austin",
            Interests = new() { "Solar Energy", "Gardening", "Robotics" },
            IsActive = true
        };

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "user_profile.json");

        // 1. JSON Serialization (with pretty formatting)
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(originalUser, options);

        Console.WriteLine("[1] Serialized JSON string:");
        Console.WriteLine(jsonString);

        // Save to file
        File.WriteAllText(filePath, jsonString);
        Console.WriteLine($"\nSaved JSON payload to: {filePath}\n");

        // 2. JSON Deserialization
        Console.WriteLine("[2] Reading and Deserializing from JSON file...");
        string readJson = File.ReadAllText(filePath);
        UserProfile? deserializedUser = JsonSerializer.Deserialize<UserProfile>(readJson);

        if (deserializedUser != null)
        {
            Console.WriteLine($"    User ID   : {deserializedUser.UserId}");
            Console.WriteLine($"    Full Name : {deserializedUser.FullName}");
            Console.WriteLine($"    Email     : {deserializedUser.Email}");
            Console.WriteLine($"    City      : {deserializedUser.City}");
            Console.WriteLine($"    Interests : {string.Join(", ", deserializedUser.Interests)}");
            Console.WriteLine($"    Active    : {deserializedUser.IsActive}");
        }

        Console.WriteLine("=================================================");
    }
}
