using System;
using System.Linq;
using System.Collections;
using System.Text;
using System.Drawing;

namespace Practice_2023;

class StrongNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine(CheckIfNumberIsStron(int.Parse(Console.ReadLine())));
    }

    public static int CalFact(int num)
    {
        int sum = 1;

        if (num == 0)
        {
            return sum;
        }

        for (int i = 1; i < num; i++)
        {
            sum *= (i + 1);
        }
        return sum;
    }

    public static int SumOfFact(string numAsText)
    {
        int[] arr = new int[numAsText.ToString().Length];
        int sum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(numAsText[i].ToString());
        }

        for (int i = 0; i < arr.Length; i++)
        {
            sum += CalFact(arr[i]);
        }
        return sum;
    }

    public static string CheckIfNumberIsStron(int num)
    {
        string numAsText = num.ToString();

        if (num == SumOfFact(numAsText))
        {
            return "yes";
        }
        else
        {
            return "no";
        }
    }
}