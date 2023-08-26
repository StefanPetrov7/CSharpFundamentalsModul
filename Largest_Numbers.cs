using System.Security.Cryptography;

namespace Practice_2023;

class Largest_Numbers
{
    static void Main(string[] args)
    {
        int[] nums = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .OrderByDescending(x => x)
            .ToArray();

        int counter = 0;

        foreach (var n in nums)
        {
            if (counter == 3) return;
            Console.Write(n + " ");
            counter++;
        }
    }
}