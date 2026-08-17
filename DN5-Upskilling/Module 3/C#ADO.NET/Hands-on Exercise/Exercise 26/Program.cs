namespace Exercise26;

class Program
{
    private static int _unsafeCounter = 0;
    private static int _safeCounter = 0;
    private static readonly object _lockObject = new();

    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 26: Race Conditions & Thread Synchronization");
        Console.WriteLine("=================================================\n");

        const int iterations = 100_000;

        // 1. Unsynchronized Race Condition Demonstration
        Console.WriteLine("[1] Running 5 threads WITHOUT lock (Unsynchronized)...");
        Thread[] unsafeThreads = new Thread[5];
        for (int i = 0; i < unsafeThreads.Length; i++)
        {
            unsafeThreads[i] = new Thread(() =>
            {
                for (int j = 0; j < iterations; j++)
                {
                    _unsafeCounter++; // Non-atomic operation (read, modify, write)
                }
            });
            unsafeThreads[i].Start();
        }

        foreach (var t in unsafeThreads) t.Join();

        Console.WriteLine($"    Expected Count : {5 * iterations:N0}");
        Console.WriteLine($"    Actual Count   : {_unsafeCounter:N0} (Race condition caused data loss!)\n");

        // 2. Synchronized Thread-Safe Demonstration with lock
        Console.WriteLine("[2] Running 5 threads WITH 'lock' Synchronization...");
        Thread[] safeThreads = new Thread[5];
        for (int i = 0; i < safeThreads.Length; i++)
        {
            safeThreads[i] = new Thread(() =>
            {
                for (int j = 0; j < iterations; j++)
                {
                    lock (_lockObject)
                    {
                        _safeCounter++;
                    }
                }
            });
            safeThreads[i].Start();
        }

        foreach (var t in safeThreads) t.Join();

        Console.WriteLine($"    Expected Count : {5 * iterations:N0}");
        Console.WriteLine($"    Actual Count   : {_safeCounter:N0} (100% thread-safe accurate!)");
        Console.WriteLine("=================================================");
    }
}
