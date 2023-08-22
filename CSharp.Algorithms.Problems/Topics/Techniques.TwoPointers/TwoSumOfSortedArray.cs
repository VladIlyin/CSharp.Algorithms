namespace CSharp.Algorithms.Problems.Topics.Techniques.TwoPointers;

public partial class TwoPointers
{
    /// <summary>
    /// Returns two indices of two elements which sum up to target value.
    /// Given array is sorted.
    /// There is exactly one solution.
    /// </summary>
    /// <param name="arr">Sorted array</param>
    /// <returns></returns>
    public (int left, int right) TwoSumOfSortedArray(int[] arr, int target)
    {
        if (arr.Length <= 1)
        {
            return (-1, -1);
        }

        var (lPtr, rPtr) = (0, arr.Length - 1);

        while (lPtr < rPtr)
        {
            if (arr[lPtr] + arr[rPtr] > target)
            {
                rPtr--;
            }
            else if (arr[lPtr] + arr[rPtr] < target)
            {
                lPtr++;
            }
            else
            {
                return (lPtr, rPtr);
            }
        }

        return (-1, -1);
    }
}