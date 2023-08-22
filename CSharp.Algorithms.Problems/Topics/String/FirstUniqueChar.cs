namespace CSharp.Algorithms.Problems.Topics.String;

public partial class StringProblem
{
    // Solution using int map
    // It also can be possible to solve it just searching every char in the string in a loop
    // But that approach would be much slower
    public static int FirstUniqChar(string s)
    {
        var map = new int[26];

        foreach (var ch in s)
        {
            map[ch - 'a']++;
        }

        for (var i = 0; i < s.Length; i++)
        {
            if (map[s[i] - 'a'] == 1)
            {
                return i;
            }
        }

        return -1;
    }
}