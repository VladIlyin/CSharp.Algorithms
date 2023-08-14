namespace CSharp.Algorithms.Problems.Topics.CombinationPermutation;

public partial class Combinatorics
{
    public static IList<string> LetterCasePermutation(string s)
    {
        List<string> res = new List<string>();
        LetterCasePermutationInternal(s, string.Empty, 0, res);
        return res;

        static void LetterCasePermutationInternal(string s,  string current, int id, List<string> res)
        {
            if (id == s.Length)
            {
                res.Add(current);
                return;
            }

            if (Char.IsDigit(s[id]))
            {
                LetterCasePermutationInternal(s, current + s[id], id + 1, res);
            }
            else
            {
                LetterCasePermutationInternal(s, current + char.ToUpper(s[id]), id + 1, res);
                LetterCasePermutationInternal(s, current + char.ToLower(s[id]), id + 1, res);
            }
        }
    }
}