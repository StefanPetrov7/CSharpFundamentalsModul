namespace Practice_2023;

class Remove_Negatives_And_Reverse_Trick
{
    static void Main(string[] args)
    {
        List<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        nums = nums.Where(x => x >= 0).ToList();
        nums.Reverse();
        Console.WriteLine(String.Join(" ", nums));

    }
}