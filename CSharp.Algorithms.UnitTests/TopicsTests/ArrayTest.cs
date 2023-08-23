using CSharp.Algorithms.Problems.Topics.Arrays;
using CSharp.Algorithms.Problems.Topics.BinarySearch;

namespace CSharp.Algorithms.UnitTests.TopicsTests;

public class ArraysProblemTests
{

    [Theory]
    [InlineData(new int[] { 1, 2 }, 1)]
    [InlineData(new int[] { 2, 2 }, 2)]
    [InlineData(new int[] { 1, 2, 3 }, 2)]
    [InlineData(new int[] { 1, 2, 1 }, 1)]
    [InlineData(new int[] { 1, 2, 2 }, 2)]
    [InlineData(new int[] { 1, 2, 3, 3 }, 3)]
    [InlineData(new int[] { 1, 2, 2, 3 }, 2)]
    public void SecondMaxTest(int[] arr, int expected)
    {
        var actual = new ArraysProblem().SecondMax(arr);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(2, 4, -1)]
    [InlineData(1, 3, 8)]
    public void SumOfSubArrayTest(int l, int r, int expected)
    {
        var arr = new int[] { -2, 4, 1, 3, -5, 8, 6, 10 };
        var prefixSumStructure = ArraysProblem.GetPrefixSum(arr);

        Assert.Equal(expected, ArraysProblem.SumOfSubArray(prefixSumStructure, l, r));
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 3, 6 })]
    [InlineData(new int[] { -2, 4, 1, 3 }, new int[] { -2, 2, 3, 6 })]
    public void PrefixSumTest(int[] arr, int[] expected)
    {
        var prefixSumStructure = ArraysProblem.GetPrefixSum(arr);

        Assert.Equal(expected, prefixSumStructure.SumArray);
    }    
    
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 24, 12, 8, 6 })]
    [InlineData(new int[] { -1, -2, -3, -4 }, new int[] { -24, -12, -8, -6 })]
    [InlineData(new int[] { -1, 1, 0, -3, 3 }, new int[] { 0, 0, 9, 0, 0 })]
    [InlineData(new int[] { 0, 1, 0, -3, 3 }, new int[] { 0, 0, 0, 0, 0 })]
    public void ProductExceptSelfTest(int[] arr, int[] expected)
    {
        var actual = ArraysProblem.ProductExceptSelf(arr);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("", "dfasc", true)]
    [InlineData("abc", "adfbsc", true)]
    [InlineData("a", "dfasc", true)]
    [InlineData("axc", "ahbgdc", false)]
    [InlineData("abcdefgh", "ahbgdc", false)]
    public void IsSubsequenceTest(string s, string t, bool expected)
    {
        var actual = ArraysProblem.IsSubsequence(s, t);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("", "dfasc", true)]
    [InlineData("abc", "adfbsc", true)]
    [InlineData("a", "dfasc", true)]
    [InlineData("axc", "ahbgdc", false)]
    [InlineData("jbw", "jjqpzarrbmzylwwovezy", true)]
    [InlineData("cmn", "oaxydpqorgzpnzoaybtf", false)]
    public void IsSubsequenceMemoTest(string s, string t, bool expected)
    {
        var actual = new ArraysProblem().IsSubsequenceMemo(s, t);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { "a", "d", "abc", "rxw", "ayw", "jbw" }, new bool[] { true, false, false, false, true, true })]
    public void IsSubsequenceMemoSameStringTest(string[] strs, bool[] expected)
    {
        var instance = new ArraysProblem();
        for (var i = 0; i < strs.Length; i++)
        {
            var actual = instance.IsSubsequenceMemo(strs[i], "jjqpzarrbmzylwwovezy");
            Assert.Equal(expected[i], actual);
        }
    }

    [Theory]
    [InlineData(new int[] { 1, 1 }, 1)]
    [InlineData(new int[] { 1, 2, 1 }, 2)]
    [InlineData(new int[] { 1, 2, 4, 3 }, 4)]
    [InlineData(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
    [InlineData(new int[] { 2, 3, 10, 5, 7, 8, 9 }, 36)]
    public void ContainerWithMostWaterTest(int[] heights, int expected)
    {
        Assert.Equal(expected, ArraysProblem.MaxArea(heights));
    }

    [Theory]
    [InlineData(new[] { 6, 1, 4, 3 }, 10, new[] { 0, 2 })]
    [InlineData(new[] { -1, 2, 1, -5, 3 }, 5, new[] { 1, 4 })]
    [InlineData(new[] { 1, 2, 3, 4 }, 7, new[] { 2, 3 })]
    [InlineData(new[] { 1, 2, 3, 4 }, 3, new[] { 0, 1 })]
    [InlineData(new[] { 1, 2, 3, 4 }, 100, null)]
    public void TwoSumTest(int[] arr, int target, int[]? expected)
    {
        var actual = new ArraysProblem().TwoSum(arr, target);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { 1 }, 1)]
    [InlineData(new int[] { 1, -1, 1, 1 }, 2)]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 15)]
    [InlineData(new[] { 4, -1, 2, -7, 3, 4 }, 7)]
    [InlineData(new[] { 4, -1, 2, -7, 3, 4, -12, 1, 3 }, 7)]
    [InlineData(new[] { 4, -1, 2, -7, 3, 4, -10, 1, 3, 7 }, 11)]
    [InlineData(new[] { -4, -1, -2, -7, -3, -4 }, -1)]
    public void KadanesAlgorithmsTest(int[] inputArray, int expected)
    {
        Assert.Equal(expected, new ArraysProblem().FindMaxSumSubarray(inputArray));
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
        Assert.Equal((left, right), new ArraysProblem().FindMaxSumSubarrayIndexes(inputArray));
    }

    [Theory]
    [InlineData(new int[] { }, new int[] { }, new int[] { })]
    [InlineData(new[] { 1, 2 }, new[] { 3, 4 }, new int[] { })]
    [InlineData(new[] { 1, 2 }, new[] { 2, 3 }, new int[] { 2 })]
    [InlineData(new[] { 2, 2, 2 }, new[] { 2, 2, 2 }, new int[] { 2, 2, 2 })]
    [InlineData(new[] { -10, 2, 2, 5 }, new[] { 2, 2 }, new[] { 2, 2 })]
    [InlineData(new[] { -10, 2, -3, 51, -7, 8, 9, 15, 12, 15 }, new[] { -1, 2, 3, 8, 17, 8, 9 }, new[] { 2, 8, 9 })]
    public void IntersectArraysTest(int[] arr1, int[] arr2, int[] expected)
    {
        Assert.Equal(expected, new ArraysProblem().Intersect(arr1, arr2));
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

        Assert.Equal(new BinarySearchProblem().BinarySearch(arr, target), expected);
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
        Assert.Equal(expected, new BinarySearchProblem().BinarySearchLowerBound(arr, target));
    }
}