using System;
using System.Linq;
using System.Collections;

namespace Practice_2023;

class Vacation
{
    static void Main(string[] args)
    {

        int groupCount = int.Parse(Console.ReadLine());
        string groupType = Console.ReadLine().ToLower();
        string day = Console.ReadLine().ToLower();
        double totalPrice = 0;

        Dictionary<string, double> students = new Dictionary<string, double>
        {
            { "friday", 8.45 },
            {"saturday", 9.80 },
            {"sunday",10.46  }
        };

        Dictionary<string, double> business = new Dictionary<string, double>
        {
            { "friday", 10.90 },
            {"saturday", 15.60 },
            {"sunday",16  }
        };

        Dictionary<string, double> regular = new Dictionary<string, double>
        {
            { "friday", 15 },
            {"saturday", 20 },
            {"sunday",22.50  }
        };

        if (groupType == "students")
        {
            foreach (var kvp in students)
            {
                if (kvp.Key == day)
                {
                    if (groupCount >= 30)
                    {
                        totalPrice = (kvp.Value * groupCount) * 0.85;
                    }
                    else
                    {
                        totalPrice = kvp.Value * groupCount;
                    }
                }
            }
        }
        else if (groupType == "business")
        {
            foreach (var kvp in business)
            {
                if (kvp.Key == day)
                {
                    if (groupCount >= 100)
                    {
                        totalPrice = (kvp.Value * (groupCount - 10));
                    }
                    else
                    {
                        totalPrice = kvp.Value * groupCount;
                    }
                }
            }
        }
        else if (groupType == "regular")
        {
            foreach (var kvp in regular)
            {
                if (kvp.Key == day)
                {
                    if (groupCount >= 10 && groupCount <= 20)
                    {
                        totalPrice = (kvp.Value * groupCount) * 0.95;
                    }
                    else
                    {
                        totalPrice = kvp.Value * groupCount;
                    }
                }
            }
        }

        Console.WriteLine($"Total price: {totalPrice:f2}");

    }
}

