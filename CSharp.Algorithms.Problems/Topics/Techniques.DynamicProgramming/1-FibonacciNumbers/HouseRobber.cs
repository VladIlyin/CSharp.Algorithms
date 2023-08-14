namespace CSharp.Algorithms.Problems.Topics.Techniques.DynamicProgramming._1_FibonacciNumbers;

public partial class DynamicProgrammingTechnique
{
    // https://www.youtube.com/watch?v=ZwDDLAeeBM0

    public static int Rob(int[] nums)
    {
        int max = nums[0];
        int temp = 0;

        foreach (int i in nums[1..])
        {
            (max, temp) = (Math.Max(i + temp, max), max);
        }

        return max;
    }

    public static int RobDpArray(int[] nums)
    {
        if (nums.Length == 0) return 0;

        // array for memoization to store repetitive calculations results
        var dp = new int[nums.Length + 1];

        dp[0] = 0;
        dp[1] = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            dp[i + 1] = Math.Max(dp[i], dp[i - 1] + nums[i]);
        }

        return dp[nums.Length];
    }
}