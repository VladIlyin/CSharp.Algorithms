namespace CSharp.Algorithms.Problems.Topics.BinarySearch;

public partial class BinarySearchProblem
{
    public int BinarySearch(int[] nums, int target)
    {
        var low = 0;
        var high = nums.Length - 1;

        while (low <= high)
        {
            var mid = low + (high - low) / 2;

            if (nums[mid] > target)
            {
                high = mid - 1;
            }
            else if (nums[mid] < target)
            {
                low = mid + 1;
            }
            else
            {
                return mid;
            }
        }

        return -1;
    }
}