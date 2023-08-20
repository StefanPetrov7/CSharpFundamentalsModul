namespace Practice_2023;

class Gauss_Trick
{
    static void Main(string[] args)
    {

        List<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        for (int i = 0; i < nums.Count / 2; i++)
        {
            nums[i] += nums[nums.Count - 1 - i];
        }

        nums.RemoveRange(nums.Count - nums.Count / 2, nums.Count / 2);

        Console.WriteLine(String.Join(" ", nums));

    }

}