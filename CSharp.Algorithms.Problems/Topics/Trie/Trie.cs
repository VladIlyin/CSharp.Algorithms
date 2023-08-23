using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.Problems.Topics.Trie
{
    public class Trie
    {
        public TrieNode Root { get; }

        public Trie()
        {
            Root = new TrieNode();
        }

        /// <summary>
        /// Insert new word into prefix tree.
        /// </summary>
        /// <param name="word">New word to be added</param>
        public void Insert(string word)
        {
            var currentNode = Root;
            foreach (var ch in word)
            {
                currentNode.Children.TryAdd(ch, new TrieNode());
                currentNode = currentNode.Children[ch];
            }

            currentNode.Word = true;
        }

        /// <summary>
        /// Check if the word is present in the prefix tree
        /// </summary>
        /// <param name="word">Word</param>
        /// <returns>True or false</returns>
        public bool Search(string word)
        {
            var currentNode = Root;
            foreach (var ch in word)
            {
                if (!currentNode.Children.TryGetValue(ch, out var node))
                {
                    return false;
                }

                currentNode = node;
            }

            return currentNode.Word;
        }

        /// <summary>
        /// Check if the prefix is present in the prefix tree
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public bool StartsWith(string prefix)
        {
            var currentNode = Root;
            foreach (var ch in prefix)
            {
                if (!currentNode.Children.TryGetValue(ch, out var node))
                {
                    return false;
                }

                currentNode = node;
            }

            return true;
        }
    }
}
