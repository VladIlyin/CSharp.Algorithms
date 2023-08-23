namespace CSharp.Algorithms.Problems.Topics.Stack;

//https://leetcode.com/problems/valid-parentheses/
/*
 * Given a string s containing just the characters '(', ')', '{', '}', '[' and ']',
 * determine if the input string is valid.
 */
public partial class StackProblem
{
    private static readonly HashSet<char> OpeningBrackets = new() { '(', '[', '{' };

    private static readonly Dictionary<char, char> PairBrackets = new()
    {
        { ')', '(' },
        { ']', '[' },
        { '}', '{' }
    };

    public bool IsValid(string inputString)
    {
        if (inputString.Length <= 1)
        {
            return false;
        }

        Stack<char> stack = new();

        foreach (var ch in inputString)
        {
            if (OpeningBrackets.Contains(ch))
            {
                stack.Push(ch);
            }
            else
            {
                if (stack.Count == 0 || stack.Pop() != PairBrackets[ch])
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
}