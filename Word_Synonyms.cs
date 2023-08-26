using System.Security.Cryptography;

namespace Practice_2023;

class Word_Synonyms
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, List<string>> synonims = new Dictionary<string, List<string>>();

        for (int i = 0; i < n ; i++)
        {
            string key = Console.ReadLine();
            string synonim = Console.ReadLine();

            if (synonims.ContainsKey(key))
            {
                synonims[key].Add(synonim);
                continue;
            }

            synonims[key] = new List<string> { synonim };
        }

        foreach (var word in synonims)
        {
            Console.WriteLine($"{word.Key} - {String.Join(", ", word.Value)}");
        }
    }
}