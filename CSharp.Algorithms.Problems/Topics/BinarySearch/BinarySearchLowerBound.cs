namespace CSharp.Algorithms.Problems.Topics.BinarySearch;

public partial class BinarySearchProblem
{
    /// <summary>
    /// Find index of the first occurrence that greater or equals target.
    /// </summary>
    /// <param name="nums">Sorted array.</param>
    /// <param name="target">Target.</param>
    /// <returns></returns>
    public int BinarySearchLowerBound(int[] nums, int target)
    {
        var low = 0;
        var high = nums.Length;

        while (low < high)
        {
            var mid = low + (high - low) / 2;
            if (nums[mid] < target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return low;
    }
}