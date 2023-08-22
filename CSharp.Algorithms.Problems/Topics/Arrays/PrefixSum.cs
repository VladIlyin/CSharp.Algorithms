namespace CSharp.Algorithms.Problems.Topics.Arrays;

public partial class ArraysProblem
{
    public static PrefixSum GetPrefixSum(int[] array)
    {
        var sums = new int[array.Length];
        sums[0] = array[0];

        for (var i = 1; i < array.Length; i++)
        {
            sums[i] = sums[i - 1] + array[i];
        }

        return new PrefixSum(sums);
    }

    public static int SumOfSubArray(PrefixSum prefixSum, int left, int right)
    {
        return prefixSum.SumArray[right] - prefixSum.SumArray[left - 1];
    }

    public record PrefixSum(int[] SumArray);
}