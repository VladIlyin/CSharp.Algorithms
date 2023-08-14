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
    public static int[] SortedSquares(int[] nums)
    {
        if (nums.Length == 0) return new int[] { };

        var res = new int[nums.Length];

        int left,
            right,
            pLeft = 0,
            pRight = nums.Length - 1,
            i = nums.Length - 1;

        while (i >= 0)
        {
            left = nums[pLeft] * nums[pLeft];
            right = nums[pRight] * nums[pRight];

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