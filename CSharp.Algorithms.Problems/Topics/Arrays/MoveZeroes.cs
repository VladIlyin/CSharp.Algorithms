namespace CSharp.Algorithms.Problems.Topics.Arrays;

public partial class ArraysProblem
{
    /// <summary>
    /// This method takes an integer array nums as input and rearranges
    /// the elements in the array such that all the zeroes are moved
    /// to the end of the array while maintaining the relative order
    /// of the non-zero elements.
    /// </summary>
    /// <param name="nums"></param>
    /// https://leetcode.com/problems/move-zeroes/
    public void MoveZeroes(int[] nums)
    {
        var lPointer = 0;
        var rPointer = 1;

        while (rPointer < nums.Length)
        {
            // If left pointer points to the first zero element in the array
            // and right pointer points to the first non-zero element after left pointer
            // then swap elements
            if (nums[lPointer] == 0 && nums[rPointer] != 0)
            {
                nums[lPointer] = nums[rPointer];
                nums[rPointer] = 0;
                lPointer++;
            }
            else if (nums[lPointer] != 0)
            {
                lPointer++;
            }

            // If both pointers point to zero elements then move right pointer
            rPointer++;
        };
    }
}