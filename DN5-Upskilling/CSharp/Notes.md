# C# - Comprehensive Notes

## 📌 Overview

C# (pronounced "C Sharp") is a modern, object-oriented programming language developed by Microsoft. It combines the power of C++ with the simplicity of Visual Basic and runs on the .NET platform. C# is used for building Windows applications, web applications, games, and more.

**Key Point:** C# is about object-oriented design, type safety, and leveraging the .NET ecosystem.

---

## 🎯 Learning Objectives

By the end of this module, you will:
- [ ] Understand C# fundamentals and syntax
- [ ] Master object-oriented programming principles
- [ ] Work with collections and LINQ
- [ ] Understand async/await and multithreading basics
- [ ] Implement error handling and exceptions
- [ ] Build real-world applications with C#

---

## 📚 Core Concepts Learned

### 1. **C# Fundamentals**

**Variables & Data Types:**
```csharp
// Primitive types
int age = 30;
float price = 19.99f;
double precise = 3.14159;
decimal money = 99.99m;
bool isActive = true;
char grade = 'A';
string name = "John";

// Nullable types
int? nullableInt = null;
if (nullableInt.HasValue) { }

// Type conversion
string numStr = "42";
int num = int.Parse(numStr);           // Parse string to int
int num2 = Convert.ToInt32(numStr);    // Convert
int.TryParse(numStr, out int result);  // Safe conversion
```

**Constants & Variables:**
```csharp
const int MAX_USERS = 100;           // Compile-time constant
readonly string dbConnection = "..."; // Runtime constant
var inferred = "Type inferred";       // Type inference
```

### 2. **Object-Oriented Programming (OOP)**

**Classes & Objects:**
```csharp
public class User
{
    // Properties
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; private set; }

    // Auto-property
    public string Email { get; set; }

    // Constructor
    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Methods
    public void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }

    // Static method
    public static int GetMaxAge()
    {
        return 150;
    }
}

// Usage
var user = new User("John", 30);
user.PrintInfo();
```

**Inheritance:**
```csharp
public class Person
{
    public string Name { get; set; }
    
    public virtual void Introduce()
    {
        Console.WriteLine($"I'm {Name}");
    }
}

public class Employee : Person
{
    public string Department { get; set; }
    
    public override void Introduce()
    {
        base.Introduce(); // Call parent method
        Console.WriteLine($"I work in {Department}");
    }
}
```

**Interfaces & Abstraction:**
```csharp
public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public abstract class Animal
{
    public abstract void MakeSound();
    
    public void Sleep()
    {
        Console.WriteLine("Zzz...");
    }
}
```

**Encapsulation:**
```csharp
public class BankAccount
{
    private decimal balance;
    
    public decimal Balance
    {
        get { return balance; }
        private set { balance = value; }
    }
    
    public void Deposit(decimal amount)
    {
        if (amount > 0)
            balance += amount;
    }
}
```

### 3. **Collections & LINQ**

**Collections:**
```csharp
// List
List<string> names = new List<string> { "John", "Jane", "Bob" };
names.Add("Alice");
names.Remove("John");
names.Sort();

// Dictionary
Dictionary<int, string> users = new Dictionary<int, string>();
users[1] = "John";
users[2] = "Jane";

// Array
int[] numbers = { 1, 2, 3, 4, 5 };

// HashSet
HashSet<int> uniqueNumbers = new HashSet<int> { 1, 2, 3, 3 };
```

**LINQ (Language Integrated Query):**
```csharp
var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Filter
var evenNumbers = numbers.Where(n => n % 2 == 0);

// Transform
var doubled = numbers.Select(n => n * 2);

// Combine
var result = numbers
    .Where(n => n > 3)
    .Select(n => n * 2)
    .OrderByDescending(n => n);

// Aggregation
int sum = numbers.Sum();
double average = numbers.Average();
int max = numbers.Max();
int count = numbers.Count();

// Any/All
bool hasEven = numbers.Any(n => n % 2 == 0);
bool allPositive = numbers.All(n => n > 0);
```

### 4. **Strings & String Handling**

```csharp
string text = "Hello World";

// String methods
text.ToUpper();          // HELLO WORLD
text.ToLower();          // hello world
text.Substring(0, 5);    // Hello
text.Contains("World");  // true
text.Replace("World", "C#"); // Hello C#
text.Split(' ');         // ["Hello", "World"]

// String interpolation
string name = "John";
int age = 30;
string message = $"Name: {name}, Age: {age}";

// String builder (for performance)
StringBuilder sb = new StringBuilder();
sb.Append("Hello");
sb.Append(" ");
sb.Append("World");
string result = sb.ToString();
```

### 5. **Exception Handling**

```csharp
try
{
    int result = 10 / 0;
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"General error: {ex.Message}");
}
finally
{
    Console.WriteLine("Cleanup code here");
}

// Throwing exceptions
public void ValidateAge(int age)
{
    if (age < 0)
        throw new ArgumentException("Age cannot be negative");
}
```

### 6. **Delegates & Events**

```csharp
// Delegate definition
public delegate void NotifyDelegate(string message);

// Event
public class Button
{
    public event EventHandler OnClick;
    
    public void Click()
    {
        OnClick?.Invoke(this, EventArgs.Empty);
    }
}

// Usage
var button = new Button();
button.OnClick += (sender, e) => Console.WriteLine("Button clicked!");
button.Click();

// Lambda expressions
Func<int, int, int> add = (a, b) => a + b;
int result = add(5, 3);  // 8
```

### 7. **Async & Await**

```csharp
// Async method
public async Task<string> FetchDataAsync()
{
    using (var client = new HttpClient())
    {
        var response = await client.GetAsync("https://api.example.com/data");
        return await response.Content.ReadAsStringAsync();
    }
}

// Calling async method
var data = await FetchDataAsync();

// Async void (use sparingly)
public async void LoadData()
{
    var data = await FetchDataAsync();
}
```

### 8. **SOLID Principles**

**Single Responsibility:**
```csharp
public class UserService { /* User operations */ }
public class EmailService { /* Email operations */ }
```

**Open/Closed:**
```csharp
public abstract class Logger
{
    public abstract void Log(string message);
}

public class ConsoleLogger : Logger
{
    public override void Log(string message) => Console.WriteLine(message);
}
```

**Liskov Substitution:**
```csharp
public interface IPaymentProcessor
{
    void Process(decimal amount);
}

public class CreditCardProcessor : IPaymentProcessor
{
    public void Process(decimal amount) { /* Implementation */ }
}
```

**Interface Segregation:**
```csharp
public interface ILogger
{
    void Log(string message);
}

public interface IEMailService
{
    void SendEmail(string to, string subject);
}
```

**Dependency Inversion:**
```csharp
public class UserService
{
    private readonly ILogger logger;
    
    public UserService(ILogger logger)
    {
        this.logger = logger;
    }
}
```

---

## 💻 Hands-On Exercises

### Exercise 1: Class Design
**Task:** Design and implement a class hierarchy for a bank system

### Exercise 2: LINQ Queries
**Task:** Practice LINQ operations on various collections

### Exercise 3: Exception Handling
**Task:** Implement proper error handling in an application

### Exercise 4: Async Programming
**Task:** Build an application with async HTTP calls

### Exercise 5: Interfaces & Inheritance
**Task:** Implement multiple interfaces and inheritance hierarchies

---

## 📝 Assignments

1. **Library Management System**
   - Design classes for books, members, borrowing
   - Implement borrowing/returning functionality
   - Create reports (books available, member history)
   - Use LINQ for queries

2. **Student Grade Management**
   - Store student information and grades
   - Calculate GPA and statistics
   - Generate reports
   - Use proper OOP principles

3. **Task Management Application**
   - Create tasks with priority and due dates
   - Implement filtering and sorting
   - Save/load from file
   - Use LINQ

---

## 🔗 References

### Official Documentation:
- [Microsoft Docs - C#](https://docs.microsoft.com/dotnet/csharp/)
- [C# Language Reference](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/)

### Tutorials:
- [C# Player's Guide](https://csharpplayersguide.com/)
- [Codecademy C#](https://www.codecademy.com/learn/learn-csharp)
- [C# Station](https://www.csharp-station.com/)

### Practice:
- [LeetCode](https://leetcode.com/) - Algorithm problems
- [HackerRank](https://www.hackerrank.com/domains/csharp)
- [Codewars](https://www.codewars.com/)

---

## 📋 Personal Notes

**Date Started:** _______________
**Topics Mastered:**
- [ ] Fundamentals
- [ ] OOP Principles
- [ ] Collections & LINQ
- [ ] String Handling
- [ ] Exception Handling
- [ ] Async/Await
- [ ] SOLID Principles

**Challenges Faced:**
_________________________________
_________________________________

**Key Takeaways:**
_________________________________
_________________________________

**Projects Completed:**
1. ___________
2. ___________
3. ___________

**Next Steps:**
- Move to DN5-DeepSkilling track
- Learn ASP.NET Core
- Study Design Patterns

---

**Last Updated:** June 2026
**Completion Status:** Not Started
