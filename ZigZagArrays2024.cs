namespace ZigZagArrays2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] arrOne = new string[n];
            string[] arrTwo = new string[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (i % 2 == 0)
                {
                    arrOne[i] = input[0];
                    arrTwo[i] = input[1];
                }
                else
                {
                    arrOne[i] = input[1];
                    arrTwo[i] = input[0];
                }
            }

            Console.WriteLine(String.Join(' ', arrOne));
            Console.WriteLine(String.Join(' ', arrTwo));

        }
    }
}


