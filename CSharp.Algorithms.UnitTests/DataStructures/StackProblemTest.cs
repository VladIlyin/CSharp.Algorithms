using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Algorithms.Problems.DataStructures.Stack;

namespace CSharp.Algorithms.UnitTests.DataStructures
{
    public class StackProblemTest
    {
        [Theory]
        [InlineData("3[a]2[bc]", "aaabcbc")]
        [InlineData("3[a2[bc]]", "abcbcabcbcabcbc")]
        [InlineData("2[abc]3[cd]ef", "abcabccdcdcdef")]
        public void DecodeStringTest(string str, string expected)
        {
            Assert.Equal(expected, StackProblem.DecodeString(str));
        }
    }
}
