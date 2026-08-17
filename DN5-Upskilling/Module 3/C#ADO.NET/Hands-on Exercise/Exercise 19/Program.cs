namespace Exercise19;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 19: Working with Lists & Dictionaries");
        Console.WriteLine("=================================================\n");

        // 1. Working with Generic List<string>
        Console.WriteLine("[1] Generic List<string> Operations:");
        List<string> eventCities = new() { "Austin", "Seattle", "Denver", "Chicago" };
        
        // Add items
        eventCities.Add("San Francisco");
        eventCities.Insert(2, "Boston");

        // Remove item
        eventCities.Remove("Chicago");

        Console.WriteLine($"    Total Cities Count: {eventCities.Count}");
        Console.Write("    Cities List       : ");
        foreach (var city in eventCities)
        {
            Console.Write($"[{city}] ");
        }
        Console.WriteLine("\n");

        // 2. Working with Generic Dictionary<int, string>
        Console.WriteLine("[2] Generic Dictionary<int, string> Operations:");
        Dictionary<int, string> eventsMap = new()
        {
            { 101, "Community Solar Energy Summit" },
            { 102, "AI & Robotics Maker Expo" },
            { 103, "Austin Downtown Art Walk" }
        };

        // Adding key-value pairs
        eventsMap.Add(104, "Cloud Architecture Day");
        eventsMap[105] = "Mindfulness & Yoga in the Park";

        // Checking containment & safe lookup
        int searchId = 102;
        if (eventsMap.TryGetValue(searchId, out string? eventTitle))
        {
            Console.WriteLine($"    Found Event #{searchId}: \"{eventTitle}\"");
        }

        // Removing a key
        eventsMap.Remove(103);

        // Iterating over Dictionary
        Console.WriteLine("\n    Current Events in Dictionary:");
        foreach (KeyValuePair<int, string> kvp in eventsMap)
        {
            Console.WriteLine($"     • Key: {kvp.Key,-4} => Event: {kvp.Value}");
        }

        Console.WriteLine("=================================================");
    }
}
