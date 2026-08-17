using System.Net;
using System.Text.RegularExpressions;

namespace Exercise29;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 29: Input Sanitization & XSS Prevention");
        Console.WriteLine("=================================================\n");

        string[] untrustedUserInputs = {
            "Alice Johnson",
            "<script>alert('XSS Attack!');</script>",
            "Clean Community Event <img src='x' onerror='stealCookies()' />",
            "<b>Bold Feedback</b> & 'Quotes' \"Double Quotes\"",
            "javascript:void(document.location='http://evil.com')"
        };

        foreach (var rawInput in untrustedUserInputs)
        {
            Console.WriteLine($"Raw Input       : {rawInput}");

            // 1. HTML Encoding (Neutralizes tags into safe entity representations)
            string encodedInput = WebUtility.HtmlEncode(rawInput);
            Console.WriteLine($"HTML Encoded    : {encodedInput}");

            // 2. HTML Tag Stripping via Regex
            string strippedInput = StripHtmlTags(rawInput);
            Console.WriteLine($"Tags Stripped   : {strippedInput}");
            Console.WriteLine(new string('-', 50));
        }

        Console.WriteLine("\nSecurity Best Practices:");
        Console.WriteLine(" • Always HTML-Encode untrusted input before rendering to web views.");
        Console.WriteLine(" • Validate whitelist characters for names, numbers, and emails.");
        Console.WriteLine("=================================================");
    }

    static string StripHtmlTags(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;
        return Regex.Replace(input, "<.*?>", string.Empty);
    }
}
