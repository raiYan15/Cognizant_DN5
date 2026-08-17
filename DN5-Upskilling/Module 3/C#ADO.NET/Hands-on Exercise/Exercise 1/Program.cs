namespace Exercise1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 1: C# Development Environment Setup");
        Console.WriteLine("=================================================");
        
        // Print environment details
        Console.WriteLine($"Hello, World!");
        Console.WriteLine($"Current .NET Version : {Environment.Version}");
        Console.WriteLine($"Operating System     : {Environment.OSVersion}");
        Console.WriteLine($"Current Directory    : {Environment.CurrentDirectory}");
        Console.WriteLine($"Machine Name         : {Environment.MachineName}");
        Console.WriteLine("=================================================");
        Console.WriteLine("Console application compiled and executed successfully!");
    }
}
