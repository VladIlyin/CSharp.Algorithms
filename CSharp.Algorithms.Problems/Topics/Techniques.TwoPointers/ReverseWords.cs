using System.Text;

namespace CSharp.Algorithms.Problems.Topics.Techniques.TwoPointers;

public partial class TwoPointers
{
    /// <summary>
    /// Method returns a new string with each word 
    /// in the input string reversed, while maintaining
    /// the original order of the words.
    /// </summary>
    /// <param name="s"></param>
    /// <returns>Reversed words</returns>
    /// https://leetcode.com/problems/reverse-words-in-a-string-iii/
    public static string ReverseWords(string s)
    {
        var sb = new StringBuilder(s.Length);
        string[] words = s.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            for (int j = words[i].Length - 1; j >= 0; j--)
            {
                sb.Append(words[i][j]);
            }

            if (i < words.Length - 1)
            {
                sb.Append(' ');
            }
        }

        return sb.ToString();
    }
}