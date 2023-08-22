namespace CSharp.Algorithms.Problems.Topics.String;

public partial class StringProblem
{
    public static bool CanConstruct(string ransomNote, string magazine)
    {
        var ransomNoteMap = new int[26];

        foreach (var ch in ransomNote)
        {
            ransomNoteMap[ch - 'a']++;
        }

        var magazineMap = new int[26];

        foreach (var ch in magazine)
        {
            magazineMap[ch - 'a']++;
        }

        for (var i = 0; i < ransomNoteMap.Length; i++)
        {
            if (ransomNoteMap[i] == 0)
            {
                continue;
            }

            if (ransomNoteMap[i] > magazineMap[i])
            {
                return false;
            }
        }

        return true;
    }
}