using CSharp.Algorithms.Problems.Topics.Intervals;

namespace CSharp.Algorithms.UnitTests.TopicsTests;

public class IntervalProblemTests
{
    [Fact]
    public void NonOverlapingIntervalsTest()
    {
        var problem = new IntervalProblem();

        var intervals = new int[4][] { new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 }, new[] { 1, 3 } };
        var minEraseCount = problem.EraseOverlapIntervals(intervals);
        Assert.Equal(1, minEraseCount);

        intervals = new int[3][] { new[] { 1, 2 }, new[] { 1, 2 }, new[] { 1, 2 } };
        minEraseCount = problem.EraseOverlapIntervals(intervals);
        Assert.Equal(2, minEraseCount);
    }
}