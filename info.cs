using System;

namespace Practice_2023;

class Program
{
    static void Main(string[] args)
    {

        int number = int.Parse(Console.ReadLine());

        int[] even = new int[] { 2, 6, 10 };
        int[] odd = new int[] { 3, 7 };

        for (int i = even.Length - 1; i >= 0; i--)
        {
            if (number % even[i] == 0)
            {
                Console.WriteLine(even[i]);
                return;
            }
        }

        for (int i = odd.Length - 1; i >= 0; i--)
        {
            if (number % odd[i] == 0)
            {
                Console.WriteLine(odd[i]);
                return;
            }
        }

    }
}

