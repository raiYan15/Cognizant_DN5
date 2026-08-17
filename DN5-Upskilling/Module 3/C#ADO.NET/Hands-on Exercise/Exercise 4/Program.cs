namespace Exercise4;

public class Event
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;

    public override string ToString() => $"[Event #{Id}] {Title} @ {Location}";
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 4: Type Inference (var and new())");
        Console.WriteLine("=================================================\n");

        // 1. Using 'var' for implicit local variable typing
        var count = 42;                             // Inferred as System.Int32
        var portalRating = 4.85;                     // Inferred as System.Double
        var message = "Welcome to Community Portal"; // Inferred as System.String
        var numbersList = new List<int> { 10, 20, 30 }; // Inferred as List<int>

        Console.WriteLine("[1] Variables declared with 'var':");
        Console.WriteLine($"    count         : Value = {count,-10} | Type = {count.GetType().FullName}");
        Console.WriteLine($"    portalRating  : Value = {portalRating,-10} | Type = {portalRating.GetType().FullName}");
        Console.WriteLine($"    message       : Value = {message,-10} | Type = {message.GetType().FullName}");
        Console.WriteLine($"    numbersList   : Count = {numbersList.Count,-10} | Type = {numbersList.GetType().FullName}\n");

        // 2. Target-typed new() expression (C# 9+)
        Event communityEvent = new() { Id = 101, Title = "Tech Innovators Summit", Location = "Seattle" };
        Dictionary<string, List<string>> cityEvents = new();
        cityEvents.Add("Austin", new() { "Solar Expo", "Art Walk" });

        Console.WriteLine("[2] Object instantiation with target-typed 'new()':");
        Console.WriteLine($"    communityEvent: {communityEvent} | Type = {communityEvent.GetType().FullName}");
        Console.WriteLine($"    cityEvents    : Keys={cityEvents.Count} | Type = {cityEvents.GetType().FullName}\n");

        // 3. Discussion on Best Practices
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("Readability & Best Practices Summary:");
        Console.WriteLine(" • Use 'var' when the type is obvious from the right-hand side (e.g. var list = new List<int>()).");
        Console.WriteLine(" • Use target-typed 'new()' when the explicit type is already declared on the left-hand side.");
        Console.WriteLine(" • Explicitly type primitive literals when ambiguity exists (e.g. decimal d = 10.5m).");
        Console.WriteLine("=================================================");
    }
}
