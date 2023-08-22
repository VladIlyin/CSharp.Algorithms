namespace CSharp.Algorithms.Problems.Topics.Techniques.TwoPointers;

public partial class TwoPointers
{
    /// <summary>
    /// This code takes an input array of integers called nums
    /// and returns a new array called res which contains 
    /// the squares of the elements in nums, sorted in non-decreasing order.
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    /// https://leetcode.com/problems/squares-of-a-sorted-array/
    public int[] SortedSquares(int[] nums)
    {
        if (nums.Length == 0)
        {
            return Array.Empty<int>();
        }

        var res = new int[nums.Length];

        var (pLeft, pRight) = (0, nums.Length - 1);
        var i = nums.Length - 1;

        while (i >= 0)
        {
            var left = nums[pLeft] * nums[pLeft];
            var right = nums[pRight] * nums[pRight];

            if (right > left)
            {
                res[i--] = right;
                pRight--;
            }
            else
            {
                res[i--] = left;
                pLeft++;
            }
        }

        return res;
    }
}