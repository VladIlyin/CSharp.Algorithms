using CSharp.Algorithms.Problems.Maths;

namespace CSharp.Algorithms.UnitTests.MathsTests;

public class MathsTest
{
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(11, 0, 11)]
    [InlineData(0, 11, 11)]
    [InlineData(1, 1, 1)]
    [InlineData(2, 1, 1)]
    [InlineData(7, 2, 1)]
    [InlineData(4, 2, 2)]
    [InlineData(6, 4, 2)]
    [InlineData(24, 16, 8)]
    public void GdcTest(int a, int b, int expected)
    {
        Assert.Equal(expected, Maths.GreatestCommonDivisor(a, b));
    }
}