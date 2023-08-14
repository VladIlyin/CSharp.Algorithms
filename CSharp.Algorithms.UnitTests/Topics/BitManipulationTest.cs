using CSharp.Algorithms.Problems.Topics.Arrays;
using CSharp.Algorithms.Problems.Topics.BitManipulation;
using CSharp.Algorithms.Problems.Topics.Techniques.TwoPointers;

namespace CSharp.Algorithms.UnitTests.Topics;

public class BitManipulationTests
{
    [Theory]
    [InlineData(2, 6, 5, 3)]
    [InlineData(4, 2, 7, 1)]
    [InlineData(1, 2, 3, 0)]
    [InlineData(10, 50, 1000, 7)]
    public void MinimumFlipsTest(int a, int b, int c, int expected)
    {
        Assert.Equal(expected, BitManipulation.MinFlips(a, b, c));
    }
}