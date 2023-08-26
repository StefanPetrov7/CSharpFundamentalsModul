namespace Practice_2023;

class CountRealNumbers
{
    static void Main(string[] args)
    {

        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Dictionary<int, int> result = new Dictionary<int, int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            if (result.ContainsKey(numbers[i]))
            {
                result[numbers[i]] += 1;
            }
            else
            {
                result.Add(numbers[i], 1);
            }
        }

        foreach (var kvp in result.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
        }
    }
}