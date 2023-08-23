using CSharp.Algorithms.Problems.Topics.Trie;

namespace CSharp.Algorithms.UnitTests.TopicsTests;

public class TrieTest
{
    [Fact]
    public void TrieInsertTest()
    {
        var trie = new Trie();
        var words = new[] { "cat", "car", "card", "cart", "cats" };

        foreach (var word in words)
        {
            trie.Insert(word);
        }

        foreach (var word in words)
        {
            var currentNode = trie.Root;

            foreach (var ch in word)
            {
                Assert.True(currentNode.Children.ContainsKey(ch));
                Assert.NotNull(currentNode.Children[ch]);
                currentNode = currentNode.Children[ch];
            }

            Assert.True(currentNode.Word);
        }
    }

    [Fact]
    public void TrieSearchTest()
    {
        var trie = new Trie();

        var words = new[] { "apple", "orange", "cat", };

        foreach (var word in words)
        {
            trie.Insert(word);
        }

        foreach (var word in words)
        {
            Assert.True(trie.Search(word));
        }

        Assert.False(trie.Search("banana"));
    }

    [Fact]
    public void SuggestionSystemTrieTest()
    {
        var search = new SearchSuggestionSystem();

        var products = new string[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" };
        var searchWord = "mouse";

        var res = search.SuggestedProducts(products, searchWord);

        var expected = new List<List<string>>()
        {
            new() { "mobile", "moneypot", "monitor" },
            new() { "mobile", "moneypot", "monitor" },
            new() { "mouse", "mousepad" },
            new() { "mouse", "mousepad" },
            new() { "mouse", "mousepad" },
        };

        for (var i = 0; i < res.Count; i++)
        {
            Assert.Equal(expected[i], res[i]);
        }
    }
}