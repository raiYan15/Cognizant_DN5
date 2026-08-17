using System.Text;

namespace Exercise25;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 25: Streams (FileStream & MemoryStream)");
        Console.WriteLine("=================================================\n");

        string sampleFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "portal_log.txt");
        string originalData = "Community Portal System Event: User Alice registered for Solar Summit at 10:00 AM.";

        // 1. Writing to file using FileStream
        Console.WriteLine("[1] Writing string to file using FileStream...");
        byte[] writeBytes = Encoding.UTF8.GetBytes(originalData);
        using (FileStream fs = new FileStream(sampleFile, FileMode.Create, FileAccess.Write))
        {
            fs.Write(writeBytes, 0, writeBytes.Length);
            Console.WriteLine($"    Wrote {fs.Length} bytes to '{Path.GetFileName(sampleFile)}'.");
        }

        // 2. Reading from file into MemoryStream
        Console.WriteLine("\n[2] Reading file bytes and transferring into MemoryStream...");
        using (MemoryStream ms = new MemoryStream())
        {
            using (FileStream readFs = new FileStream(sampleFile, FileMode.Open, FileAccess.Read))
            {
                readFs.CopyTo(ms);
            }

            Console.WriteLine($"    MemoryStream Length: {ms.Length} bytes");
            Console.WriteLine($"    MemoryStream Capacity: {ms.Capacity} bytes");

            // Convert MemoryStream buffer back to string
            byte[] buffer = ms.ToArray();
            string readText = Encoding.UTF8.GetString(buffer);

            Console.WriteLine("\n[3] Decoded Content from MemoryStream buffer:");
            Console.WriteLine($"    \"{readText}\"");
        }

        Console.WriteLine("=================================================");
    }
}
