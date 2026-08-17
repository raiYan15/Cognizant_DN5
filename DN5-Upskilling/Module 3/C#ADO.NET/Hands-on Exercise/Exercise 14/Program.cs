namespace Exercise14;

// Base Class
public class Shape
{
    public string Name { get; set; }

    public Shape(string name)
    {
        Name = name;
    }

    // Virtual method to be overridden
    public virtual void Draw()
    {
        Console.WriteLine($"[Base Shape] Drawing a generic shape: {Name}");
    }

    public virtual double CalculateArea() => 0.0;
}

// Derived Class 1: Circle
public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius) : base("Circle")
    {
        Radius = radius;
    }

    public override void Draw()
    {
        Console.WriteLine($"[Circle] ⭕ Drawing a circle with Radius = {Radius:F2} | Area = {CalculateArea():F2}");
    }

    public override double CalculateArea() => Math.PI * Radius * Radius;
}

// Derived Class 2: Rectangle
public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height) : base("Rectangle")
    {
        Width = width;
        Height = height;
    }

    public override void Draw()
    {
        Console.WriteLine($"[Rectangle] ▭ Drawing a rectangle with Width = {Width:F2}, Height = {Height:F2} | Area = {CalculateArea():F2}");
    }

    public override double CalculateArea() => Width * Height;
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 14: Inheritance & Method Overriding");
        Console.WriteLine("=================================================\n");

        // Demonstrating Polymorphic Collection
        List<Shape> shapes = new()
        {
            new Circle(5.0),
            new Rectangle(4.0, 6.0),
            new Circle(2.5),
            new Rectangle(10.0, 2.0),
            new Shape("Generic Polygonal Form")
        };

        Console.WriteLine("Iterating through Polymorphic Shape Collection (Runtime Dispatch):\n");
        foreach (var shape in shapes)
        {
            shape.Draw();
        }

        Console.WriteLine("=================================================");
    }
}
