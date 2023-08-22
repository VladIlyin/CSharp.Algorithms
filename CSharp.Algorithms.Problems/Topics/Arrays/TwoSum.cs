namespace CSharp.Algorithms.Problems.Topics.Arrays;

public partial class ArraysProblem
{
    // Time-complexity:     O(n)
    // Space-complexity:    O(n)
    public int[]? TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (dict.ContainsKey(nums[i]))
            {
                return new[] { dict[nums[i]], i };
            }

            dict.Add(target - nums[i], i);
        }

        return null;
    }
}