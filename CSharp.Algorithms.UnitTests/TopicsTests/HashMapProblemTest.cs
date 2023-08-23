using CSharp.Algorithms.Problems.Topics.HashMap;

namespace CSharp.Algorithms.UnitTests.TopicsTests
{
    public class HashMapProblemTest
    {
        [Fact]
        public void FindDifferenceOfTwoArraysTest()
        {
            var diff =HashMapProblem.FindDifference(new int[] { 1, 2, 3, 3 }, new int[] { 1, 1, 2, 2 });

            Assert.Equal(new List<int>() { 3 }, diff[0]);
            Assert.Equal(new List<int>() { }, diff[1]);

        }
        
        [Theory]
        [InlineData("abc", "cba", true)]
        [InlineData("a", "aa", false)]
        [InlineData("cabbba", "abbccc", true)]
        [InlineData("abbzzca", "babzzcz", false)]
        public void DetermineIfTwoStringsAreCloseTest(string word1, string word2, bool expected)
        {
            var isClose = HashMapProblem.CloseStrings(word1, word2);
            Assert.Equal(expected, isClose);
        }
    }
}
