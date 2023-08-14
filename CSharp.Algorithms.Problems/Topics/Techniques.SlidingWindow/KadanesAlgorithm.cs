namespace CSharp.Algorithms.Problems.Topics.Techniques.SlidingWindow;

/// <summary>
/// Kadane's algorithm.
/// </summary>
public partial class SlidingWindow
{
    public static (int leftIndex , int rightIndex) FindMaxSumSubarrayIndexes(int[] arr)
    {
        var maxSum = arr[0];
        var currentSum = 0;
        int maxL = 0, maxR = 0;
        int lPointer = 0;

        for (int rPointer = 0; rPointer <= arr.Length - 1; rPointer++)
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