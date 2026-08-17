namespace Exercise2;

public class Person
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 2: Value Types vs Reference Types");
        Console.WriteLine("=================================================\n");

        // 1. Value Type Demonstration (int, double)
        int originalInt = 100;
        double originalDouble = 45.67;

        Console.WriteLine("[1] Value Types (int, double) Before Method Call:");
        Console.WriteLine($"    originalInt    = {originalInt}");
        Console.WriteLine($"    originalDouble = {originalDouble}");

        ModifyValueTypes(originalInt, originalDouble);

        Console.WriteLine("\n[1] Value Types (int, double) After Method Call (Unchanged):");
        Console.WriteLine($"    originalInt    = {originalInt} (Expected: 100)");
        Console.WriteLine($"    originalDouble = {originalDouble} (Expected: 45.67)\n");

        // 2. Reference Type Demonstration (Custom Class: Person)
        Person person = new Person { Name = "Alice Johnson", Age = 25 };

        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("[2] Reference Type (Custom Class) Before Method Call:");
        Console.WriteLine($"    person.Name = {person.Name}, person.Age = {person.Age}");

        ModifyReferenceType(person);

        Console.WriteLine("\n[2] Reference Type (Custom Class) After Method Call (Modified in Heap):");
        Console.WriteLine($"    person.Name = {person.Name} (Expected: Bob Smith)");
        Console.WriteLine($"    person.Age  = {person.Age} (Expected: 30)\n");

        // 3. Reference Type Immutability Demonstration (string)
        string originalString = "Hello Community";
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("[3] String (Immutable Reference Type) Before Call:");
        Console.WriteLine($"    originalString = \"{originalString}\"");

        ModifyString(originalString);

        Console.WriteLine("\n[3] String After Method Call (Unchanged due to String Immutability):");
        Console.WriteLine($"    originalString = \"{originalString}\" (Expected: Hello Community)");
        Console.WriteLine("=================================================");
    }

    static void ModifyValueTypes(int number, double decimalVal)
    {
        number += 500;
        decimalVal += 100.0;
        Console.WriteLine($"    -> Inside ModifyValueTypes: number={number}, decimalVal={decimalVal}");
    }

    static void ModifyReferenceType(Person p)
    {
        p.Name = "Bob Smith";
        p.Age = 30;
        Console.WriteLine($"    -> Inside ModifyReferenceType: p.Name={p.Name}, p.Age={p.Age}");
    }

    static void ModifyString(string text)
    {
        text = "Modified Inside Method";
        Console.WriteLine($"    -> Inside ModifyString: text=\"{text}\"");
    }
}
