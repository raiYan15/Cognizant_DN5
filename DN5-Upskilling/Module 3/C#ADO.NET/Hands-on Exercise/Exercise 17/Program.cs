#nullable enable
namespace Exercise17;

public class Address
{
    public string Street { get; set; } = string.Empty;
    public string? City { get; set; }
    public string? ZipCode { get; set; }
}

public class Company
{
    public string Name { get; set; } = string.Empty;
    public Address? OfficeAddress { get; set; }
}

public class Contact
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Address? HomeAddress { get; set; }
    public Company? Employer { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 17: Null-Conditional Chaining");
        Console.WriteLine("=================================================\n");

        List<Contact> contacts = new()
        {
            new Contact
            {
                FirstName = "Sarah",
                LastName = "Connor",
                HomeAddress = new Address { Street = "100 Innovation Way", City = "Seattle", ZipCode = "98101" },
                Employer = new Company
                {
                    Name = "Cyberdyne Systems",
                    OfficeAddress = new Address { Street = "500 Tech Blvd", City = "San Francisco" }
                }
            },
            new Contact
            {
                FirstName = "David",
                LastName = "Kim",
                HomeAddress = new Address { Street = "42 Pine Street", City = "Austin" },
                Employer = null // No employer
            },
            new Contact
            {
                FirstName = "Hannah",
                LastName = "Abbott",
                HomeAddress = null, // No address
                Employer = null
            }
        };

        Console.WriteLine("Displaying Directory with Safe Deep Chaining (?.) and Fallbacks (??):\n");

        foreach (var contact in contacts)
        {
            string homeCity = contact.HomeAddress?.City ?? "City Not Provided";
            string employerName = contact.Employer?.Name ?? "Self-Employed / Independent";
            string workCity = contact.Employer?.OfficeAddress?.City ?? "N/A";

            Console.WriteLine($"👤 Contact     : {contact.FullName}");
            Console.WriteLine($"   Home City   : {homeCity}");
            Console.WriteLine($"   Company     : {employerName}");
            Console.WriteLine($"   Work City   : {workCity}");
            Console.WriteLine("   ----------------------------------------------");
        }

        Console.WriteLine("All contacts processed cleanly without any NullReferenceException!");
        Console.WriteLine("=================================================");
    }
}
