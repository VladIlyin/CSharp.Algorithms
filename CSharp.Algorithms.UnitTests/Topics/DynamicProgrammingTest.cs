using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Algorithms.Problems.Topics.Techniques.DynamicProgramming._1_FibonacciNumbers;

namespace CSharp.Algorithms.UnitTests.Topics
{
    public class DynamicProgrammingTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 8)]
        [InlineData(7, 13)]
        public void FibonacciNumbersTest(int n, int expected)
        {
            Assert.Equal(expected, DynamicProgrammingTechnique.FibonacciNumber(n));
            Assert.Equal(expected, DynamicProgrammingTechnique.FibonacciNumberIterative(n));
        }

    }
}
