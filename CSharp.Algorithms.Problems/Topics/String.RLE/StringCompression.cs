using System;
using System.Text;

namespace CSharp.Algorithms.Problems.Topics.String
{
    public partial class StringProblem
    {
        /// <summary>
        /// https://youtu.be/SKwB41FrGgU?t=2724
        /// <param name="chars">String like AAAABBBCCXYZDDDDEEEEAAABBBBBBBBBB</param>
        /// <returns></returns>
        public string RLE(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            void Pack(char ch, int count)
            {
                sb.Append(ch);
                if (count > 1)
                {
                    sb.Append(count);
                }
            }

            var currentChar = str[0];
            var lastPos = 0;

            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] != currentChar)
                {
                    Pack(str[i - 1], i - lastPos);
                    (lastPos, currentChar) = (i, str[i]);
                }
            }

            Pack(str[^1], str.Length - lastPos);

            return sb.ToString();
        }
    }
}
