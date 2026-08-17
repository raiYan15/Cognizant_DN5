namespace Exercise3;

// C# 12 Primary Constructor syntax on class
public class Person(string firstName, string lastName, int age, string city)
{
    // Auto-properties initialized with primary constructor parameters
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public int Age { get; set; } = age;
    public string City { get; set; } = city;

    // Full name computed property
    public string FullName => $"{FirstName} {LastName}";

    // Method to display formatted person details
    public void DisplayFullInfo()
    {
        Console.WriteLine($"Full Name : {FullName}");
        Console.WriteLine($"Age       : {Age} years old");
        Console.WriteLine($"City      : {City}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 3: Primary Constructors in C# 12");
        Console.WriteLine("=================================================\n");

        // Instantiate using primary constructor
        var person1 = new Person("Diana", "Prince", 28, "Austin");
        var person2 = new Person("Bruce", "Wayne", 35, "Gotham");

        Console.WriteLine("--- Person 1 Details ---");
        person1.DisplayFullInfo();

        Console.WriteLine("\n--- Person 2 Details ---");
        person2.DisplayFullInfo();

        // Modifying property
        person1.City = "Seattle";
        Console.WriteLine($"\nUpdated Person 1 City: {person1.City}");
        Console.WriteLine("=================================================");
    }
}
