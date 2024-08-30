namespace EqualSums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> result = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int leftSum = i == 0 ? 0 : arr.Take(i).ToArray().Sum(x => x);
                int rightSum = i == arr.Length - 1 ? 0 : arr.Skip(i + 1).ToArray().Sum(x => x);

                if (leftSum == rightSum)
                {
                    result.Add(i);
                }
            }

            string output = result.Count() == 0 ? "no" : string.Join(" ", result);
            Console.WriteLine(output);

        }
    }
}


