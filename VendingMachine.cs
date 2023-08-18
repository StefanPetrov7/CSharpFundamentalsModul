using System;
using System.Linq;
using System.Collections;
using System.Text;
using System.Drawing;

namespace Practice_2023;

class VendingMachine
{
    static void Main(string[] args)
    {

        string input = Console.ReadLine().ToLower();
        double totalCoins = 0;

        while (input != "start")
        {
            double coin = double.Parse(input);

            TakeCoins(coin, ref totalCoins);
            input = Console.ReadLine().ToLower();
        }

        input = Console.ReadLine().ToLower();

        while (input != "end")
        {
            PurchaseProduct(input, ref totalCoins);
            input = Console.ReadLine().ToLower();
        }

        Console.WriteLine($"Change: {totalCoins:f2}");

    }

    public static bool TakeCoins(double coin, ref double totalCoins)
    {
        double[] allowedCoins = new double[] { 0.1, 0.2, 0.5, 1, 2 };

        if (allowedCoins.Contains(coin))
        {
            totalCoins += coin;
            return true;
        }
        else
        {
            Console.WriteLine($"Cannot accept {coin}");
            return false;
        }
    }

    private static bool PurchaseProduct(string product, ref double totalCoins)
    {
        Dictionary<string, double> products = new Dictionary<string, double>
        {
            {"nuts", 2.0 },
            {"water", 0.7 },
            {"crisps", 1.5},
            {"soda", 0.8},
            {"coke", 1.0 }
        };

        if (products.ContainsKey(product))
        {
            double price = products[product];

            if (totalCoins >= price)
            {
                totalCoins -= price;
                Console.WriteLine($"Purchased {product}");
                return true;
            }
            else
            {
                Console.WriteLine("Sorry, not enough money");
                return false;
            }
        }
        else
        {
            Console.WriteLine("Invalid product");
            return false;
        }
    }
}