namespace Exercise18;

public class Student
{
    // C# 11/12 'required' modifier ensures caller initializes these properties
    public required int Id { get; init; }
    public required string FullName { get; init; }
    public required string CourseName { get; init; }
    
    // Optional property
    public double Gpa { get; init; } = 3.0;

    public void DisplayStudent()
    {
        Console.WriteLine($"Student #{Id:D4}: {FullName,-18} | Course: {CourseName,-22} | GPA: {Gpa:F2}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 18: The 'required' Modifier in C#");
        Console.WriteLine("=================================================\n");

        // Valid Initialization with all required fields
        Student student1 = new Student
        {
            Id = 1001,
            FullName = "Elena Rostova",
            CourseName = "Distributed Systems & Cloud",
            Gpa = 3.92
        };

        Student student2 = new Student
        {
            Id = 1002,
            FullName = "Evan Wright",
            CourseName = "Autonomous Robotics"
            // Gpa is optional, will use default 3.0
        };

        student1.DisplayStudent();
        student2.DisplayStudent();

        Console.WriteLine("\n-------------------------------------------------");
        Console.WriteLine("Compiler Guarantee Notes:");
        Console.WriteLine(" • Attempting `new Student { Id = 1003 }` without `FullName` or `CourseName`");
        Console.WriteLine("   will trigger compile-time error CS9035 (Required member must be set).");
        Console.WriteLine(" • Guarantees non-null/initialized invariants without boilerplate constructors!");
        Console.WriteLine("=================================================");
    }
}
