namespace Exercise27;

class Program
{
    private static readonly object _lockA = new();
    private static readonly object _lockB = new();

    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 27: Deadlock Simulation & Resolution");
        Console.WriteLine("=================================================\n");

        Console.WriteLine("Demonstrating Deadlock Prevention using Monitor.TryEnter with Timeouts:\n");

        Thread t1 = new(Thread1Work);
        Thread t2 = new(Thread2Work);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine("\nBoth threads completed safely without entering a permanent deadlock state!");
        Console.WriteLine("=================================================");
    }

    static void Thread1Work()
    {
        Console.WriteLine("[Thread 1] Attempting to acquire Lock A...");
        if (Monitor.TryEnter(_lockA, TimeSpan.FromSeconds(2)))
        {
            try
            {
                Console.WriteLine("[Thread 1] Acquired Lock A. Sleeping 500ms...");
                Thread.Sleep(500);

                Console.WriteLine("[Thread 1] Attempting to acquire Lock B...");
                if (Monitor.TryEnter(_lockB, TimeSpan.FromSeconds(2)))
                {
                    try
                    {
                        Console.WriteLine("[Thread 1] ✅ Acquired Lock B. Executing critical section!");
                    }
                    finally
                    {
                        Monitor.Exit(_lockB);
                        Console.WriteLine("[Thread 1] Released Lock B.");
                    }
                }
                else
                {
                    Console.WriteLine("[Thread 1] ⚠️ Timeout acquiring Lock B! Backing off to prevent deadlock.");
                }
            }
            finally
            {
                Monitor.Exit(_lockA);
                Console.WriteLine("[Thread 1] Released Lock A.");
            }
        }
    }

    static void Thread2Work()
    {
        Console.WriteLine("[Thread 2] Attempting to acquire Lock B...");
        if (Monitor.TryEnter(_lockB, TimeSpan.FromSeconds(2)))
        {
            try
            {
                Console.WriteLine("[Thread 2] Acquired Lock B. Sleeping 500ms...");
                Thread.Sleep(500);

                Console.WriteLine("[Thread 2] Attempting to acquire Lock A...");
                if (Monitor.TryEnter(_lockA, TimeSpan.FromSeconds(2)))
                {
                    try
                    {
                        Console.WriteLine("[Thread 2] ✅ Acquired Lock A. Executing critical section!");
                    }
                    finally
                    {
                        Monitor.Exit(_lockA);
                        Console.WriteLine("[Thread 2] Released Lock A.");
                    }
                }
                else
                {
                    Console.WriteLine("[Thread 2] ⚠️ Timeout acquiring Lock A! Backing off to prevent deadlock.");
                }
            }
            finally
            {
                Monitor.Exit(_lockB);
                Console.WriteLine("[Thread 2] Released Lock B.");
            }
        }
    }
}
