using System.Diagnostics;

namespace Exercise28;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 28: Logging with System.Diagnostics.Trace");
        Console.WriteLine("=================================================\n");

        string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "application.log");

        // 1. Configure Trace Listeners
        Trace.Listeners.Clear();
        
        // Listener 1: Console
        Trace.Listeners.Add(new ConsoleTraceListener());

        // Listener 2: File Listener
        Trace.Listeners.Add(new TextWriterTraceListener(logFilePath));

        // Ensure buffer flushes immediately
        Trace.AutoFlush = true;

        // 2. Perform Logging at various levels
        Trace.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [INFO] Application Started.");
        Trace.TraceInformation($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [INFO] Initializing Event Portal Database Connection...");
        
        Trace.TraceWarning($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [WARN] Memory consumption at 65% capacity.");
        
        Trace.TraceError($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [ERROR] User 'David' failed registration check (Duplicate ID).");

        Trace.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [INFO] Application execution finished cleanly.");

        Console.WriteLine($"\n✅ Logs successfully written to both Console and Log File:");
        Console.WriteLine($"   File: {logFilePath}");
        Console.WriteLine("=================================================");
    }
}
