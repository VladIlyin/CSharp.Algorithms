using CSharp.Algorithms.Problems.Topics.String;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Algorithms.UnitTests.Topics
{
    public class StringProblemTest
    {
        [Theory]
        [InlineData("the sky is blue", "blue is sky the")]
        [InlineData("  hello world  ", "world hello")]
        [InlineData("a good   example", "example good a")]
        [InlineData("", "")]
        [InlineData("  ", "")]
        public void ReverseWordsTest(string words, string expected)
        {
            var actual = StringProblem.ReverseWords(words);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new char[] { 'a', 'a', 'b', 'b', 'c', 'c', 'c' }, new char[] { 'a', '2', 'b', '2', 'c', '3' }, 6)]
        [InlineData(new char[] { 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b' }, new char[] { 'a', 'b', '1', '2' }, 4)]
        [InlineData(new char[] { 'a', 'a', 'a' }, new char[] { 'a', '3' }, 2)]
        [InlineData(new char[] { 'a', 'b', 'c' }, new char[] { 'a', 'b', 'c' }, 3)]
        [InlineData(new char[] { 'a','a', 'b','b', 'c', 'c' }, new char[] { 'a','2', 'b','2', 'c', '2' }, 6)]
        public void CompressStringTest(char[] chars, char[] charsChanged, int expected)
        {
            var actual = StringProblem.Compress(chars);
            Assert.Equal(expected, actual);
            Assert.Equal(charsChanged, chars.Take(expected));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("A", "A")]
        [InlineData("AAA", "A3")]
        [InlineData("ABC", "ABC")]
        [InlineData("AABBCC", "A2B2C2")]
        [InlineData("ABBCCC", "AB2C3")]
        [InlineData("AAABBC", "A3B2C")]
        [InlineData("AAABBCDE", "A3B2CDE")]
        [InlineData("AAAABBBCCXYZDDDDEEEEAAABBBBBBBBBB", "A4B3C2XYZD4E4A3B10")]
        public void RleTest(string str, string expected)
        {
            var actual = new StringProblem().RLE(str);
            Assert.Equal(expected, actual);
        }
    }
}
