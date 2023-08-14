using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.Problems.DataStructures.Tree;

public class BinaryTreeTraversalRecursive
{
    /// <summary>
    /// Pre-order traversal recursively.
    /// </summary>
    /// <returns>IEnumerable of T</returns>
    public static IEnumerable<int> PreOrderRecursive(TreeNode? parent)
    {
        if (parent == null) yield break;

        yield return parent.val;

        foreach (var item in PreOrderRecursive(parent.left))
        {
            yield return item;
        }

        foreach (var item in PreOrderRecursive(parent.right))
        {
            yield return item;
        }
    }

    /// <summary>
    /// In-order traversal recursively.
    /// </summary>
    /// <returns>IEnumerable of T</returns>
    public static IEnumerable<int> InOrderRecursive(TreeNode? root)
    {
        if (root == null) yield break;
            
        foreach (var item in InOrderRecursive(root.left))
        {
            yield return item;
        }

        yield return root.val;

        foreach (var item in InOrderRecursive(root.right))
        {
            yield return item;
        }
    }

    /// <summary>
    /// Post-order traversal recursively.
    /// </summary>
    /// <returns>IEnumerable of T</returns>
    public static IEnumerable<int> PostOrderRecursive(TreeNode? parent)
    {
        if (parent == null) yield break;

        foreach (var item in PostOrderRecursive(parent.left))
        {
            yield return item;
        }

        foreach (var item in PostOrderRecursive(parent.right))
        {
            yield return item;
        }

        yield return parent.val;
    }
}