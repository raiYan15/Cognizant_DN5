namespace Exercise23;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 23: Async File Upload Simulation");
        Console.WriteLine("=================================================\n");

        string[] fileQueue = { "presentation_slides.pdf", "corrupted_archive.dat", "event_banner.png" };

        foreach (var file in fileQueue)
        {
            Console.WriteLine($"Initiating upload for: '{file}'...");
            try
            {
                bool success = await UploadFileAsync(file);
                if (success)
                {
                    Console.WriteLine($"✅ SUCCESS: '{file}' uploaded to cloud storage successfully.\n");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"❌ FAILED: Upload error for '{file}': {ex.Message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ UNEXPECTED ERROR: {ex.Message}\n");
            }
        }

        Console.WriteLine("=================================================");
    }

    public static async Task<bool> UploadFileAsync(string fileName)
    {
        Console.WriteLine($" -> [Thread {Environment.CurrentManagedThreadId}] Connecting to cloud bucket...");
        await Task.Delay(1000); // 1 sec delay

        Console.WriteLine($" -> [Thread {Environment.CurrentManagedThreadId}] Streaming bytes for '{fileName}'...");
        await Task.Delay(2000); // 2 more secs (total 3s simulated async upload)

        // Simulate intentional failure on corrupted files
        if (fileName.Contains("corrupted"))
        {
            throw new InvalidOperationException("File integrity check failed (CRC mismatch).");
        }

        return true;
    }
}
