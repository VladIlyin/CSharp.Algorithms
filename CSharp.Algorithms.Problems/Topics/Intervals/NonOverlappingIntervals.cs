using CSharp.Algorithms.Problems.Topics.Matrix;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharp.Algorithms.Problems.Topics.Matrix.MatrixProblem;

namespace CSharp.Algorithms.Problems.Topics.Intervals
{
    // https://leetcode.com/problems/non-overlapping-intervals/
    public partial class IntervalProblem
    {
        /// <summary>
        /// Finding the minimum number of intervals to remove is equivalent to finding the maximum number of non-overlapping intervals.
        /// This is the famous interval scheduling problem.
        /// https://en.wikipedia.org/wiki/Interval_scheduling
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns>Returns the minimum number of intervals
        /// you need to remove to make the rest of the intervals
        /// non-overlapping</returns>
        public int EraseOverlapIntervals(int[][] intervals)
        {
            if (intervals.Length < 2) return 0;

            Array.Sort(intervals, new IntervalEndComparer());
            
            var minEraseIntervalCount = 0;
            var k = int.MinValue;

            foreach (var interval in intervals)
            {
                var x = interval[0];
                var y = interval[1];

                if (x >= k)
                {
                    k = y;
                }
                else
                {
                    minEraseIntervalCount++;
                }
            }

            return minEraseIntervalCount;
        }
    }

    public class IntervalEndComparer : IComparer<int[]>
    {
        public int Compare(int[]? x, int[]? y)
        {
            return x[1].CompareTo(y[1]);
        }
    }
}
