using System;

namespace CSharp.Algorithms.Problems.Topics.String
{
    public partial class StringProblem
    {
        /// <summary>
        /// https://leetcode.com/problems/string-compression/
        /// Given an array of characters chars, compress it using the following algorithm:
        /// Begin with an empty string s. For each group of consecutive repeating characters in chars:
        ///     If the group's length is 1, append the character to s.
        ///     Otherwise, append the character followed by the group's length.
        /// Input: chars = ["a","a","b","b","c","c","c"]
        /// Output: Return 6, and the first 6 characters of the input array should be: ["a","2","b","2","c","3"]
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static int Compress(char[] chars)
        {
            if (chars.Length == 0) return 0;
            
            var j = 0;
            var cnt = 0;
            var currentChar = chars[0];

            for (var i = 0; i < chars.Length; i++)
            {
                if (chars[i] == currentChar)
                {
                    cnt++;
                }

                if (i == chars.Length - 1 || chars[i + 1] != currentChar)
                {
                    chars[j++] = currentChar;
                    if (cnt > 1)
                    {
                        foreach (var num in cnt.ToString())
                        {
                            chars[j++] = num;
                        }
                    }
                    cnt = 0;
                    if (i != chars.Length - 1) currentChar = chars[i + 1];
                }
            }

            return j;
        }
    }
}
