using CSharp.Algorithms.Problems.DataStructures.Arrays;

namespace CSharp.Algorithms.UnitTests.DataStructures;

public class ArraysTests
{
    [Theory]
    [InlineData(1, new int[] { 1 })]
    [InlineData(2, new int[] { 1, -1, 1, 1 })]
    [InlineData(15, new int[] { 1, 2, 3, 4, 5 })]
    [InlineData(7, new int[] { 4, -1, 2, -7, 3, 4 })]
    [InlineData(7, new int[] { 4, -1, 2, -7, 3, 4, -12, 1, 3 })]
    [InlineData(11, new int[] { 4, -1, 2, -7, 3, 4, -10, 1, 3, 7 })]
    [InlineData(-1, new int[] { -4, -1, -2, -7, -3, -4 })]
    public void KadanesAlgorithmsTest(int maxSum, int[] inputArray)
    {
        Assert.Equal(maxSum, ArraysProblem.FindMaxSumSubarray(inputArray));
    }

    [Theory]
    [InlineData(0, 0, new int[] { 1 })]
    [InlineData(0, 3, new int[] { 1, -1, 1, 1 })]
    [InlineData(0, 4, new int[] { 1, 2, 3, 4, 5 })]
    [InlineData(4, 5, new int[] { 4, -1, 2, -7, 3, 4 })]
    [InlineData(4, 5, new int[] { 4, -1, 2, -7, 3, 4, -10, 1, 3 })]
    [InlineData(1, 1, new int[] { -4, -1, -2, -7, -3, -4 })]
    public void KadanesAlgorithmsReturnsSubarrayIndixesTest(int left, int right, int[] inputArray)
    {
        Assert.Equal((left, right), ArraysProblem.FindMaxSumSubarrayIndexes(inputArray));
    }

    [Fact]
    public void IntersectArraysTest()
    {
        Assert.Equal(new int[] { 2, 2 }, ArrayOperations.Intersect(
            new int[] { -10, 2, 2, 5 },
            new int[] { 2, 2 }));

        Assert.Equal(new int[] { 2, 8, 9 }, ArrayOperations.Intersect(
            new int[] { -10, 2, -3, 51, -7, 8, 9, 15, 12, 15 },
            new int[] { -1, 2, 3, 8, 17, 8, 9 }));
    }

    [Theory]
    [MemberData(nameof(BinarySearchArraysTestData))]
    public void BinarySearchArraysTest(int start, int count, int target, int expected)
    {
        var arr = new int[count];
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] = i + start;
        }

        Assert.Equal(ArrayOperations.BinarySearch(arr, target), expected);
    }

    public static IEnumerable<object[]> BinarySearchArraysTestData()
    {
        yield return new object[] { 1, 1, 1, 0 };
        yield return new object[] { 1, 1, 2, -1 };
        yield return new object[] { 1, 3, 4, -1 };
        yield return new object[] { 1, 3, -4, -1 };
        yield return new object[] { 1, 3, 1, 0 };
        yield return new object[] { 1, 3, 2, 1 };
        yield return new object[] { 1, 3, 3, 2 };
        yield return new object[] { 2_140_000_000, 5_000_000, 2_140_000_001, 1 };
        yield return new object[] { 1, 100_000_000, 12345, 12344 };
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 2, 1)]
    [InlineData(new[] { 1, 2, 3, 9, 10 }, 5, 3)]
    [InlineData(new[] { 1, 2, 3, 9, 10 }, 11, 5)]
    [InlineData(new[] { 1, 2, 3, 9, 10 }, -11, 0)]
    [InlineData(new[] { 1, 3, 8, 8, 8, 10 }, 8, 2)]
    [InlineData(new[] { 1, 3, 8, 8, 8, 10 }, 7, 2)]
    [InlineData(new[] { 1, 8, 8, 8, 8, 10 }, 7, 1)]
    [InlineData(new[] { 1, 8, 8, 8, 8, 10 }, 9, 5)]
    [InlineData(new[] { 1, 8, 8, 8, 8, 10 }, 8, 1)]
    [InlineData(new[] { 8, 8, 8, 8, 8, 10 }, 8, 0)]
    public void BinarySearchGoeTest(int[] arr, int target, int expected)
    {
        Assert.Equal(expected, ArrayOperations.BinarySearchLowerBound(arr, target));
    }
}