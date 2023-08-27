using System.Security.Cryptography;

namespace Practice_2023;

class Word_Filter
{
    static void Main(string[] args)
    {
        Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Where(x => x.Length % 2 == 0)
            .ToList()
            .ForEach(word => Console.WriteLine(word));
    }
}