namespace CSharp.Algorithms.Problems.Topics.String
{
    public partial class StringProblem
    {
        /// <summary>
        /// Returns a string of the words in reverse order concatenated by a single space
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// https://leetcode.com/problems/reverse-words-in-a-string/
        public static string ReverseWords(string s)
        {
            var sArr = s.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var (lPtr, rPtr) = (0, sArr.Length - 1);

            while (lPtr < rPtr)
            {
                (sArr[lPtr], sArr[rPtr]) = (sArr[rPtr], sArr[lPtr]);
                (lPtr, rPtr) = (lPtr + 1, rPtr - 1);
            }

            return string.Join(" ", sArr);
        }
    }
}
