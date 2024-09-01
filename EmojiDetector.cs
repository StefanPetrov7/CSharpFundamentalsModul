using System.Text.RegularExpressions;

namespace Practice2024
{
    internal class EmojiDetector
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(:{2}|\*{2})[A-Z][a-z]{2,}\1";
            string numPatern = @"\d";
            long coolNumber = 1;

            Regex.Matches(text, numPatern)
            .Select(x => int.Parse(x.ToString()))
            .ToList()
            .ForEach(x => coolNumber *= x);

            MatchCollection mathes = Regex.Matches(text, pattern);
            Dictionary<string, int> coolMathces = new Dictionary<string, int>();

            for (int i = 0; i < mathes.Count; i++)
            {
                coolMathces[mathes[i].ToString().TrimEnd()] = mathes[i].ToString().Substring(2, mathes[i].Length - 4).ToCharArray().Sum(x => x);
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



