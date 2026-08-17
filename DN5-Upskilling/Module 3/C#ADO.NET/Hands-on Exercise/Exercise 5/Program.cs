namespace Exercise5;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 5: Conditional Logic & Pattern Matching");
        Console.WriteLine("=================================================\n");

        int[] sampleScores = { 95, 84, 72, 63, 45, 105, -5 };

        foreach (var score in sampleScores)
        {
            Console.WriteLine($"--- Evaluating Score: {score} ---");

            // 1. If-Else If-Else Evaluation
            string ifGrade = CalculateGradeIfElse(score);
            Console.WriteLine($"[If-Else]             Grade: {ifGrade}");

            // 2. Classic Switch Statement
            string switchGrade = CalculateGradeClassicSwitch(score);
            Console.WriteLine($"[Classic Switch]      Grade: {switchGrade}");

            // 3. Switch Expression with Relational Pattern Matching (C# 9+)
            string patternGrade = CalculateGradePatternMatching(score);
            Console.WriteLine($"[Pattern Switch]      Grade: {patternGrade}\n");
        }
    }

    // Method 1: Using If-Else
    static string CalculateGradeIfElse(int score)
    {
        if (score < 0 || score > 100)
            return "Invalid Score";
        else if (score >= 90)
            return "A (Excellent)";
        else if (score >= 80)
            return "B (Very Good)";
        else if (score >= 70)
            return "C (Good)";
        else if (score >= 60)
            return "D (Pass)";
        else
            return "F (Fail)";
    }

    // Method 2: Using Classic Switch with Range Mapping
    static string CalculateGradeClassicSwitch(int score)
    {
        if (score < 0 || score > 100) return "Invalid Score";

        switch (score / 10)
        {
            case 10:
            case 9:
                return "A (Excellent)";
            case 8:
                return "B (Very Good)";
            case 7:
                return "C (Good)";
            case 6:
                return "D (Pass)";
            default:
                return "F (Fail)";
        }
    }

    // Method 3: Using Switch Expression with Relational Pattern Matching
    static string CalculateGradePatternMatching(int score) => score switch
    {
        < 0 or > 100 => "Invalid Score",
        >= 90        => "A (Excellent)",
        >= 80        => "B (Very Good)",
        >= 70        => "C (Good)",
        >= 60        => "D (Pass)",
        _            => "F (Fail)"
    };
}
