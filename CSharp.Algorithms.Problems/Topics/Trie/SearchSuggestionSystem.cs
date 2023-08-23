using CSharp.Algorithms.Core.Models;
using System.Collections.Generic;
using static CSharp.Algorithms.Problems.Topics.BFSDFS.BFSDFS;

namespace CSharp.Algorithms.Problems.Topics.Trie
{
    public class SearchSuggestionSystem
    {
        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            if (products.Length == 0 || string.IsNullOrEmpty(searchWord))
            {
                return new List<IList<string>>();
            }

            var res = new List<IList<string>>();

            var trie = new SuggestionSystemTrie();

            foreach (var product in products)
            {
                trie.Insert(product);
            }

            for (var i = 1; i < searchWord.Length + 1; i++)
            {
                res.Add(trie.Search(searchWord[..i]));
            }

            return res;
        }
    }

    public class SuggestionSystemTrie
    {
        private readonly TrieNode _root;

        class TrieNode
        {
            private SortedList<string, string> _suggestions;

            public IList<string> Suggestions => _suggestions.Keys;

            public Dictionary<char, TrieNode> Children = new();
            public bool Word = false;

            public TrieNode()
            {
                _suggestions = new SortedList<string, string>();
            }

            public void AddSuggestion(string substr)
            {
                _suggestions.Add(substr, substr);

                if (_suggestions.Count == 4)
                {
                    _suggestions.RemoveAt(3);
                }
            }
        }

        public SuggestionSystemTrie()
        {
            _root = new TrieNode();
        }

        public void Insert(string word)
        {
            var currentNode = _root;

            for (var i = 0; i < word.Length; i++)
            {
                currentNode.Children.TryAdd(word[i], new TrieNode());
                currentNode = currentNode.Children[word[i]];
                currentNode.AddSuggestion(word[(i + 1)..]);
            }

            currentNode.Word = true;
        }

        public IList<string> Search(string word)
        {
            var currentNode = _root;
            foreach (var ch in word)
            {
                if (!currentNode.Children.TryGetValue(ch, out var node))
                {
                    return new List<string>();
                }

                currentNode = node;
            }

            return currentNode
                .Suggestions
                .Select(substr => word + substr)
                .ToList();
        }
    }

    // Не мое решение, использует предварительную сортировку продуктов

    //public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    //{
    //    Array.Sort(products);
    //    var r = new TrieNode();
    //    foreach (string p in products)
    //    {
    //        var curr = r;
    //        foreach (var c in p)
    //        {
    //            if (curr.trie[c - 'a'] == null)
    //                curr.trie[c - 'a'] = new TrieNode();
    //            curr = curr.trie[c - 'a'];
    //            if (curr.suggestion.Count < 3)
    //                curr.suggestion.Add(p);
    //        }

    //    }
    //    List<IList<string>> list = new List<IList<string>>();
    //    var cur = r;
    //    foreach (var s in searchWord)
    //    {
    //        if (cur != null)
    //            cur = cur.trie[s - 'a'];
    //        list.Add(cur == null ? new List<string>() : cur.suggestion);

    //    }

    //    return list;


    //}
    //public class TrieNode
    //{
    //    public List<string> suggestion;
    //    public TrieNode[] trie;
    //    public TrieNode()
    //    {
    //        suggestion = new List<string>();
    //        trie = new TrieNode[26];
    //    }
    //}
}
