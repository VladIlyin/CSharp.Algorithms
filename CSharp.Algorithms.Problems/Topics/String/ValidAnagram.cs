namespace CSharp.Algorithms.Problems.Topics.String;

public partial class StringProblem
{
    public static bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;

        var sMap = new int[26];

        foreach (var ch in s)
        {
            sMap[ch - 'a']++;
        }

        foreach (var ch in t)
        {
            if (--sMap[ch - 'a'] < 0)
            {
                return false;
            }
        }

        return true;
    }
}