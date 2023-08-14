using System.Text.RegularExpressions;

namespace CSharp.Algorithms.Problems.Topics.String;

//https://www.codewars.com/kata/51e056fe544cf36c410000fb/train/csharp
public static class Top3Words
{
    public static List<string> Top3(string s)
    {
        return Regex.Matches(s.ToLower(), @"('*[a-z]'*)+")
            .GroupBy(str => str.Value)
            .Select(x => new { Key = x.Key, Cnt = x.Count() })
            .OrderByDescending(x => x.Cnt)
            .Take(3)
            .Select(x => x.Key)
            .ToList();
    }

    public static List<string> Top3CodeWarsBest(string s)
    {
        return Regex.Matches(s.ToLowerInvariant(), @"('*[a-z]'*)+")
            .GroupBy(match => match.Value)
            .OrderByDescending(g => g.Count())
            .Select(p => p.Key)
            .Take(3)
            .ToList();
    }
}