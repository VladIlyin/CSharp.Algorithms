using CSharp.Algorithms.Core.Helpers;

namespace CSharp.Algorithms.Problems.Topics.Techniques.TwoPointers;

public partial class TwoPointers
{
    /// <summary>
    /// This code rotates an array nums of integers to the right by k steps.
    /// The rotation is performed in-place,
    /// meaning the original array is modified without creating a new one.
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// https://leetcode.com/problems/rotate-array/
    public void RotateArrayInPlace(int[] nums, int k)
    {
        if (k < 0 || nums.Length == 0 || nums.Length == k)
        {
            return;
        }

        k %= nums.Length;

        SwapElements(nums, 0, nums.Length - k - 1);
        SwapElements(nums, nums.Length - k, nums.Length - 1);
        SwapElements(nums, 0, nums.Length - 1);

        void SwapElements(int[] arr, int startIndex, int endIndex)
        {
            while (startIndex < endIndex)
            {
                arr.Swap(startIndex++, endIndex--);
            }
        }
    }
    
    public void RotateArrayWithCopying(int[] nums, int k)
    {
        if (k < 0 || nums.Length == 0 || nums.Length == k)
        {
            return;
        }

        k %= nums.Length;

        var temp = new int[nums.Length];
        Array.Copy(nums, temp, nums.Length);

        for (var i = 0; i < nums.Length; i++)
        {
            nums[(i + k) % nums.Length] = temp[i];
        }
    }
}