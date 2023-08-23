namespace CSharp.Algorithms.Problems.Topics.Arrays;

/// <summary>
/// In computer science, the maximum sum subarray problem,
/// also known as the maximum segment sum problem,
/// is the task of finding a contiguous subarray with the largest sum,
/// within a given one-dimensional array A[1...n] of numbers.
/// Kadane's original algorithm solves the problem (empty subarrays are admitted).
/// Time complexity: O(n)
/// Space complexity: O(1)
/// </summary>
public partial class ArraysProblem
{
    public int FindMaxSumSubarray(int[] arr)
    {
        var maxSum = arr[0];
        var currentSum = 0;

        foreach (var n in arr)
        {
            currentSum = Math.Max(0, currentSum);
            currentSum += n;
            maxSum = Math.Max(currentSum, maxSum);
        }

        return maxSum;
    }

    public (int leftIndex , int rightIndex) FindMaxSumSubarrayIndexes(int[] arr)
    {
        var maxSum = arr[0];
        var currentSum = 0;
        int maxL = 0, maxR = 0;
        var lPointer = 0;

        for (var rPointer = 0; rPointer <= arr.Length - 1; rPointer++)
        {
            if (currentSum < 0)
            {
                currentSum = 0;
                lPointer = rPointer;
            }

            currentSum += arr[rPointer];

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                (maxL, maxR) = (lPointer, rPointer);
            }
        }

        return (maxL, maxR);
    }
}