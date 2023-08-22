﻿using System.Reflection.Metadata.Ecma335;

namespace CSharp.Algorithms.Problems.Topics.Arrays
{
    public partial class ArraysProblem
    {
        /// <summary>
        /// Returns true if `s` is a subsequence of `t`, or false otherwise.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns>True of false.</returns>
        public static bool IsSubsequence(string s, string t)
        {
            if (s.Length > t.Length) return false;
            if (s.Length == 0) return true;

            var ptr = 0;

            foreach (var ch in t)
            {
                if (ch == s[ptr])
                {
                    ptr++;
                    if (s.Length == ptr)
                    {
                        return true;
                    }
                }
            }

            return s.Length == ptr;
        }

        private readonly Dictionary<string, int?[]> _memo = new();

        public bool IsSubsequenceMemo(string s, string t)
        {
            if (s.Length > t.Length) return false;
            if (s.Length == 0) return true;

            // get or add to memo
            if (!_memo.TryGetValue(t, out var arrChars))
            {
                arrChars = new int?[123];
                for (var i = 0; i < t.Length; i++)
                {
                    arrChars[t[i]] ??= i;
                }

                _memo.TryAdd(t, arrChars);
            }


            var idxArr = -1;

            foreach (var ch in s)
            {
                if (arrChars[ch] == null)
                {
                    return false;
                }

                if (idxArr < arrChars[ch].Value)
                {
                    idxArr = arrChars[ch].Value;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
