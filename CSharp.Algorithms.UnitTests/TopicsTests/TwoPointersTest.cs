using CSharp.Algorithms.Problems.Topics.Techniques.TwoPointers;

namespace CSharp.Algorithms.UnitTests.TopicsTests;

public class TwoPointersTests
{
    [Theory]
    [InlineData(-1, -1, new int[] { }, 3)]
    [InlineData(-1, -1, new int[] { 1 }, 3)]
    [InlineData(0, 1, new int[] { 1, 2 }, 3)]
    [InlineData(1, 2, new int[] { -1, 1, 2 }, 3)]
    [InlineData(2, 4, new int[] { -1, 1, 3, 4, 7, 10 }, 10)]
    [InlineData(-1, -1, new int[] { -1, 1, 3, 4, 7, 10 }, 16)]
    public void TwoSumOfSortedArrayTest(int l, int r,int[] arr, int target)
    {
        Assert.Equal((l, r), new TwoPointers().TwoSumOfSortedArray(arr, target));
    }
}