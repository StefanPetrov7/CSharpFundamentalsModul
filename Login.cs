using System;
using System.Linq;
using System.Collections;
using System.Text;

namespace Practice_2023;

class Login
{
    static void Main(string[] args)
    {
        string userName = Console.ReadLine();
        char[] passArr = userName.Reverse().ToArray();
        string pass = String.Join("", passArr);
        int loigInAttemnpts = 4;

        while (true)
        {
            string attempt = Console.ReadLine();
            loigInAttemnpts--;

            if (attempt == pass)
            {
                Console.WriteLine($"User {userName} logged in.");
                return;
            }

            if (loigInAttemnpts == 0)
            {
                Console.WriteLine($"User {userName} blocked!");
                return;
            }

            if (attempt != pass)
            {
                Console.WriteLine("Incorrect password. Try again.");
            }
        }
    }
}

