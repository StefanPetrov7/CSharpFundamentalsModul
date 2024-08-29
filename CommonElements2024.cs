namespace CommonElements2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arrOne = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] arrTwo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<string> result = new List<string>();   

            for (int i = 0; i < arrTwo.Length; i++) 
            {
                for (int j = 0; j < arrOne.Length; j++)
                {
                    if (arrTwo[i] == arrOne[j])
                    {
                        result.Add(arrOne[j]);
                    }
                }
            }

            Console.WriteLine(String.Join(' ', result));
        }
    }
}

