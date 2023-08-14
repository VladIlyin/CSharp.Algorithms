namespace CSharp.Algorithms.Problems.Topics.String
{
    public partial class StringProblem
    {
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
