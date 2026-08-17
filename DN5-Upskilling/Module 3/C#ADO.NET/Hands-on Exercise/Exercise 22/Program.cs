namespace Exercise22;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 22: Creating and Deconstructing Tuples");
        Console.WriteLine("=================================================\n");

        // 1. Calling method returning a named Tuple
        var resultTuple = GetEventStatistics(101);
        Console.WriteLine("[1] Accessing Tuple by named fields:");
        Console.WriteLine($"    Event Id      : {resultTuple.EventId}");
        Console.WriteLine($"    Event Title   : {resultTuple.Title}");
        Console.WriteLine($"    Registrations : {resultTuple.RegistrationCount}");
        Console.WriteLine($"    Avg Rating    : {resultTuple.AverageRating:F2}/5.0\n");

        // 2. Deconstructing Tuple into individual local variables
        Console.WriteLine("[2] Deconstructing Tuple into separate variables:");
        var (id, title, count, rating) = GetEventStatistics(102);
        Console.WriteLine($"    Deconstructed -> ID: {id}, Name: \"{title}\", Regs: {count}, Rating: {rating}");

        // 3. Deconstruction with Discards (_)
        Console.WriteLine("\n[3] Deconstruction ignoring unwanted fields (Discards):");
        var (_, shortTitle, _, highRating) = GetEventStatistics(103);
        Console.WriteLine($"    Only extracted Title: \"{shortTitle}\" and Rating: {highRating}");

        Console.WriteLine("=================================================");
    }

    // Method returning multiple strongly-typed values via named tuple
    public static (int EventId, string Title, int RegistrationCount, double AverageRating) GetEventStatistics(int eventId)
    {
        return eventId switch
        {
            101 => (101, "Community Solar Energy Summit", 45, 4.8),
            102 => (102, "AI & Robotics Maker Expo", 120, 4.95),
            103 => (103, "Austin Downtown Art Walk", 88, 4.6),
            _   => (eventId, "General Community Gathering", 10, 4.0)
        };
    }
}
