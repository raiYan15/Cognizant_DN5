# Design Patterns - Comprehensive Notes

## 📌 Overview

Design Patterns are reusable solutions to common problems in software design. They represent best practices and can be categorized into Creational, Structural, and Behavioral patterns. Understanding design patterns helps write more maintainable, scalable, and efficient code.

**Key Point:** Design patterns are blueprints for solving recurring design problems in object-oriented software.

---

## 🎯 Learning Objectives

By the end of this module, you will:
- [ ] Understand Gang of Four (GoF) design patterns
- [ ] Master Creational, Structural, and Behavioral patterns
- [ ] Identify when to use each pattern
- [ ] Implement patterns effectively in C#
- [ ] Recognize patterns in existing code
- [ ] Apply SOLID principles alongside patterns

---

## 📚 Core Concepts Learned

### 1. **Creational Patterns**

Patterns that focus on object creation mechanisms.

**Singleton:**
```csharp
public class Database
{
    private static Database instance;
    
    private Database() { }
    
    public static Database GetInstance()
    {
        if (instance == null)
            instance = new Database();
        return instance;
    }
}

// Thread-safe version
public class DatabaseThreadSafe
{
    private static readonly DatabaseThreadSafe instance = new DatabaseThreadSafe();
    
    private DatabaseThreadSafe() { }
    
    public static DatabaseThreadSafe GetInstance() => instance;
}
```

**Factory Pattern:**
```csharp
public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine(message);
}

public class FileLogger : ILogger
{
    public void Log(string message) => File.WriteAllText("log.txt", message);
}

public class LoggerFactory
{
    public static ILogger CreateLogger(string type)
    {
        return type.ToLower() switch
        {
            "console" => new ConsoleLogger(),
            "file" => new FileLogger(),
            _ => throw new ArgumentException("Unknown logger type")
        };
    }
}
```

**Builder Pattern:**
```csharp
public class User
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public int Age { get; private set; }
    
    private User() { }
    
    public class Builder
    {
        private string name;
        private string email;
        private int age;
        
        public Builder WithName(string name)
        {
            this.name = name;
            return this;
        }
        
        public Builder WithEmail(string email)
        {
            this.email = email;
            return this;
        }
        
        public Builder WithAge(int age)
        {
            this.age = age;
            return this;
        }
        
        public User Build()
        {
            return new User { Name = name, Email = email, Age = age };
        }
    }
}

// Usage
var user = new User.Builder()
    .WithName("John")
    .WithEmail("john@example.com")
    .WithAge(30)
    .Build();
```

### 2. **Structural Patterns**

Patterns that focus on composition of objects.

**Decorator Pattern:**
```csharp
public interface IComponent
{
    void Operation();
}

public class ConcreteComponent : IComponent
{
    public void Operation() => Console.WriteLine("Base operation");
}

public class Decorator : IComponent
{
    protected IComponent component;
    
    public Decorator(IComponent component)
    {
        this.component = component;
    }
    
    public virtual void Operation() => component.Operation();
}

public class ConcreteDecorator : Decorator
{
    public ConcreteDecorator(IComponent component) : base(component) { }
    
    public override void Operation()
    {
        base.Operation();
        Console.WriteLine("Additional operation");
    }
}
```

**Adapter Pattern:**
```csharp
// Old interface
public interface ILegacyDatabase
{
    void Query(string sql);
}

// New interface
public interface IModernDatabase
{
    void Execute(string command);
}

public class DatabaseAdapter : IModernDatabase
{
    private ILegacyDatabase legacyDb;
    
    public DatabaseAdapter(ILegacyDatabase db) => legacyDb = db;
    
    public void Execute(string command)
    {
        legacyDb.Query(command); // Adapt old interface to new
    }
}
```

**Facade Pattern:**
```csharp
public class ComplicatedLibrary
{
    public void ComplexStep1() { }
    public void ComplexStep2() { }
    public void ComplexStep3() { }
}

public class SimpleFacade
{
    private ComplicatedLibrary library = new ComplicatedLibrary();
    
    public void DoSomething()
    {
        library.ComplexStep1();
        library.ComplexStep2();
        library.ComplexStep3();
    }
}
```

### 3. **Behavioral Patterns**

Patterns that focus on object collaboration and responsibility distribution.

**Observer Pattern:**
```csharp
public interface IObserver
{
    void Update(string message);
}

public class Subject
{
    private List<IObserver> observers = new List<IObserver>();
    
    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }
    
    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }
    
    public void Notify(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }
}

public class ConcreteObserver : IObserver
{
    private string name;
    
    public ConcreteObserver(string name) => this.name = name;
    
    public void Update(string message)
    {
        Console.WriteLine($"{name} received: {message}");
    }
}
```

**Strategy Pattern:**
```csharp
public interface IPaymentStrategy
{
    void Pay(decimal amount);
}

public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(decimal amount) => Console.WriteLine($"Paid ${amount} with credit card");
}

public class PayPalPayment : IPaymentStrategy
{
    public void Pay(decimal amount) => Console.WriteLine($"Paid ${amount} with PayPal");
}

public class PaymentProcessor
{
    private IPaymentStrategy strategy;
    
    public PaymentProcessor(IPaymentStrategy strategy)
    {
        this.strategy = strategy;
    }
    
    public void ProcessPayment(decimal amount)
    {
        strategy.Pay(amount);
    }
}
```

**Command Pattern:**
```csharp
public interface ICommand
{
    void Execute();
    void Undo();
}

public class LightOnCommand : ICommand
{
    private Light light;
    
    public LightOnCommand(Light light) => this.light = light;
    
    public void Execute() => light.TurnOn();
    public void Undo() => light.TurnOff();
}

public class Light
{
    public void TurnOn() => Console.WriteLine("Light is on");
    public void TurnOff() => Console.WriteLine("Light is off");
}

public class RemoteControl
{
    private ICommand command;
    
    public void SetCommand(ICommand command) => this.command = command;
    
    public void PressButton() => command?.Execute();
}
```

---

## 💻 Hands-On Exercises

### Exercise 1: Singleton Pattern
**Task:** Implement a thread-safe Singleton for configuration management

### Exercise 2: Factory Pattern
**Task:** Create a factory for different data access implementations

### Exercise 3: Decorator Pattern
**Task:** Build decorators for a notification system

### Exercise 4: Observer Pattern
**Task:** Implement a pub-sub system

### Exercise 5: Strategy Pattern
**Task:** Create different sorting strategies

---

## 📝 Assignments

1. **Payment System**
   - Use Strategy pattern for payment methods
   - Use Factory for payment processor creation
   - Use Observer for payment notifications

2. **Logging Framework**
   - Design loggers using Singleton
   - Use Decorator for multiple destinations
   - Use Factory for logger creation
   - Use Observer for log subscribers

3. **UI Components Library**
   - Use Builder for complex components
   - Use Decorator for styling
   - Use Observer for event handling
   - Use Strategy for different rendering

---

## 🔗 References

### Books:
- Design Patterns: Elements of Reusable Object-Oriented Software (Gang of Four)
- Refactoring: Improving the Design of Existing Code
- Head First Design Patterns

### Online Resources:
- [Refactoring Guru - Design Patterns](https://refactoring.guru/design-patterns)
- [Microsoft - Design Patterns in C#](https://docs.microsoft.com/en-us/dotnet/architecture/patterns/)

---

## 📋 Personal Notes

**Date Started:** _______________
**Topics Mastered:**
- [ ] Creational Patterns
- [ ] Structural Patterns
- [ ] Behavioral Patterns
- [ ] SOLID Integration

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

---

**Last Updated:** June 2026
**Completion Status:** Not Started
