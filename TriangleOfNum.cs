using System;
using System.Linq;
using System.Collections;
using System.Text;
using System.Drawing;

namespace Practice_2023;

class TriangleOfNum
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i <= n; i++)
        {
            int row = i;

            for (int j = 0; j < row; j++)
            {
                Console.Write(row + " ");
            }

            Console.WriteLine();
        }
    }
}