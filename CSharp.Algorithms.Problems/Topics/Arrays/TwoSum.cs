namespace CSharp.Algorithms.Problems.Topics.Arrays;

public partial class Arrays
{
    // Time-complexity:     O(n)
    // Space-complexity:    O(n)
    public static int[]? TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dict = new();

        for (int i = 0; i < nums.Length; i++)
        {
            if (dict.ContainsKey(nums[i]))
            {
                return new int[] { dict[nums[i]], i };
            }

            int key = target - nums[i];
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, i);
            }
        }

        return null;
    }
}