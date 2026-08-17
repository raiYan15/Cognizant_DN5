namespace Exercise6;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 6: Loop Types and Flow Control");
        Console.WriteLine("=================================================\n");

        int[] scores = { 12, 25, 37, 48, 55, 64, 78, 89, 95, 100 };

        // 1. For Loop (Skip odd numbers using continue)
        Console.WriteLine("[1] For Loop (Even numbers only, skip odds):");
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] % 2 != 0) continue; // Skip odd
            Console.Write($"{scores[i]} ");
        }
        Console.WriteLine("\n");

        // 2. Foreach Loop (Break when score > 75)
        Console.WriteLine("[2] Foreach Loop (Stop/Break when score > 75):");
        foreach (int score in scores)
        {
            if (score > 75)
            {
                Console.WriteLine($"\n    -> Reached threshold score: {score}. Breaking loop!");
                break;
            }
            Console.Write($"{score} ");
        }
        Console.WriteLine();

        // 3. While Loop
        Console.WriteLine("[3] While Loop (Traverse up to index 5):");
        int index = 0;
        while (index < scores.Length && index <= 5)
        {
            Console.Write($"scores[{index}]={scores[index]}  ");
            index++;
        }
        Console.WriteLine("\n");

        // 4. Do-While Loop
        Console.WriteLine("[4] Do-While Loop (Executes at least once):");
        int count = 0;
        do
        {
            Console.WriteLine($"    Executing iteration #{count + 1} with score: {scores[count]}");
            count++;
        } while (count < 3);

        Console.WriteLine("=================================================");
    }
}
