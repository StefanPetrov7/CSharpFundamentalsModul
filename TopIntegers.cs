namespace TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> result = new List<int>();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int element = arr[i];

                for (int j = i + 1; j < arr.Length; j++)
                {

                    if (element <= arr[j])
                    {
                        break;
                    }

                    if (j == arr.Length - 1)
                    {
                        result.Add(element);
                    }
                }

            }

            result.Add(arr[arr.Length - 1]);
            Console.WriteLine(string.Join(' ', result));
        }
    }
}


