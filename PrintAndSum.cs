using System;
using System.Linq;
using System.Collections;
using System.Text;

namespace Practice_2023;

class PrintAndSum
{
    static void Main(string[] args)
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        StringBuilder resultText = new StringBuilder();
        int resultNumber = 0;

        for (int i = start; i <= end; i++)
        {
            resultText.Append(i.ToString() + " ");
            resultNumber += i;
        }

        resultText.AppendLine("\n" + $"Sum: {resultNumber}");
        Console.WriteLine(resultText);
    }
}

