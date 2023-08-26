using System.Security.Cryptography;

namespace Practice_2023;

class Odd_Occurrences
{
    static void Main(string[] args)
    {

        string[] words = Console.ReadLine().ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (result.ContainsKey(word))
            {
                result[word]++;
            }
            else
            {
                result.Add(word, 1);
            }
        }

        result.Where(x => x.Value % 2 != 0).ToDictionary(x => x.Key, y => y.Value);

        Console.WriteLine(String.Join(" ", result.Keys));
    }
}