using System.Text.RegularExpressions;

namespace Practice2024
{
    internal class EmojiDetector
    {
        static void Main(string[] args)
        {
            // Only 80 PTS :D

            string text = Console.ReadLine();
            string pattern = @"(::)[A-Z][a-z]{2,}(::)|(\*\*)[A-Z][a-z]{2,}(\*\*)";
            string numPatern = @"\d";

            int coolNumber = Regex.Matches(text, numPatern)
                .Select(x => int.Parse(x.ToString()))
                .ToArray()
                .Aggregate((acc, x) => acc * x);

            MatchCollection mathes = Regex.Matches(text, pattern);
            Dictionary<string, int> coolMathces = new Dictionary<string, int>();

            for (int i = 0; i < mathes.Count; i++)
            {
                coolMathces[mathes[i].ToString().TrimEnd()] = mathes[i].ToString().ToCharArray().Sum(x => x);
            }

            Console.WriteLine($"Cool threshold: {coolNumber}");
            Console.WriteLine($"{coolMathces.Keys.Count()} emojis found in the text. The cool ones are:");
            Console.WriteLine(String.Join('\n', coolMathces
                .Where(x => x.Value >= coolNumber)
                .ToDictionary(x => x.Key, y => y.Value)
                .Keys));
        }
    }
}
