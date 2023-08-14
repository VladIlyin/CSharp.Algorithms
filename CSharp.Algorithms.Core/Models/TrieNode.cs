namespace CSharp.Algorithms.Core.Models;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children = new();
    public bool Word = false;

    public TrieNode()
    {
    }

    public TrieNode(
        Dictionary<char, TrieNode> children,
        bool word = default)
    {
        Children = children;
        Word = word;
    }
}