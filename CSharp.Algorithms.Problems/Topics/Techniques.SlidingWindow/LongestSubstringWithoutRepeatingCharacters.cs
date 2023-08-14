namespace CSharp.Algorithms.Problems.Topics.Techniques.SlidingWindow;

public partial class SlidingWindow
{
    public static int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0)
        {
            return 0;
        }

        HashSet<char> chars = new();
        int i = 0, j = 0, max = 0;

        while (i < s.Length)
        {
            i = j;

            while (i < s.Length)
            {
                var ch = s[i];
                if (!chars.Contains(ch))
                {
                    chars.Add(ch);
                    i++;
                }
                else
                {
                    break;
                }
            };

            if (chars.Count < s.Length)
            {
                j++;
                if (chars.Count > max)
                {
                    max = chars.Count;
                }
                chars.Clear();
            }
            else
            {
                max = i;
                break;
            } 
        }

        return max;
    }
}