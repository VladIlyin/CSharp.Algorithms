using System.Text;

namespace CSharp.Algorithms.Problems.Topics.Stack
{
    public partial class StackProblem
    {
        public static string DecodeString(string s)
        {
            var stack = new Stack<char>();
            var sb = new StringBuilder();

            foreach (var ch in s)
            {
                if (ch == ']')
                {
                    // extract the string
                    while (stack.Count > 0 && stack.Peek() != '[')
                    {
                        sb.Append(stack.Pop());
                    }
                    var strReversedOrder = sb.ToString();

                    // pop [ bracket
                    stack.Pop();

                    // extract the number
                    sb.Clear();
                    while (stack.Count > 0 && char.IsDigit(stack.Peek()))
                    {
                        sb.Insert(0, stack.Pop());
                    }
                    
                    if (!int.TryParse(sb.ToString(), out var n)) throw new ArgumentException($"Cannot parse {sb.ToString()}");

                    sb.Clear();

                    // put string `str` onto stack `n` times
                    while (n > 0)
                    {
                        foreach (var chr in strReversedOrder.Reverse())
                        {
                            stack.Push(chr);
                        }
                        //for (var j = strReversedOrder.Length - 1; j >= 0; j--)
                        //{
                        //    stack.Push(strReversedOrder[j]);
                        //}

                        n--;
                    }
                }
                else
                {
                    stack.Push(ch);
                }
            }

            // collect the string
            var ret = new StringBuilder();

            foreach (var ch in stack.Reverse())
            {
                ret.Append(ch);
            }

            return ret.ToString();
        }
    }
}
