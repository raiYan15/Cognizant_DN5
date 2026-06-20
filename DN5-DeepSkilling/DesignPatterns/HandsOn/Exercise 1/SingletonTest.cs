public class SingletonTest
{
    public static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        logger1.Log("First message");
        logger2.Log("Second message");

        Console.WriteLine("Logger1 HashCode: " + logger1.GetHashCode());
        Console.WriteLine("Logger2 HashCode: " + logger2.GetHashCode());

        if (logger1 == logger2)
        {
            Console.WriteLine("Only one Logger instance exists.");
        }
        else
        {
            Console.WriteLine("Multiple Logger instances exist.");
        }
    }
}