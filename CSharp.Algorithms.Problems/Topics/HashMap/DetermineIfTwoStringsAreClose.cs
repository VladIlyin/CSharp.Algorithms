using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Algorithms.Problems.Topics.HashMap
{
    public partial class HashMapProblem
    {
        public static bool CloseStrings(string word1, string word2)
        {
            if (word1.Length != word2.Length)
            {
                return false;
            }

            var dict1 = new Dictionary<char, int>();
            var dict2 = new Dictionary<char, int>();

            foreach (var ch in word1)
            {
                if (!dict1.TryAdd(ch, dict1.GetValueOrDefault(ch, 0) + 1))
                {
                    dict1[ch]++;
                }
            }

            foreach (var ch in word2)
            {
                if (!dict2.TryAdd(ch, dict2.GetValueOrDefault(ch, 0) + 1))
                {
                    dict2[ch]++;
                }
            }

            if (!new HashSet<char>(dict1.Keys).SetEquals(dict2.Keys))
            {
                return false;
            }

            if (!dict1.Values.OrderBy(x => x).SequenceEqual(dict2.Values.OrderBy(x => x)))
            {
                return false;
            }

            return true;
        }
    }
}
