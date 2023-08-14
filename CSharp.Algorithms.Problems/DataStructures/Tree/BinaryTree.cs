using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.Problems.DataStructures.Tree;

public class BinaryTreeOperations
{
    /// <summary>
    /// Invert binary tree.
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    /// https://leetcode.com/problems/invert-binary-tree/
    public static TreeNode? Invert(TreeNode? root)
    {
        foreach (var node in BinaryTreeTraversalIterative.PostOrder(root))
        {
            (node.left, node.right) = (node.right, node.left);
        }

        return root;
    }

    /// <summary>
    /// Invert binary tree recursively.
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    /// https://leetcode.com/problems/invert-binary-tree/
    public static TreeNode? InvertRecursively(TreeNode? root)
    {
        if (root == null)
        {
            return null;
        }

        (root.left, root.right) = (root.right, root.left);

        InvertRecursively(root.left);
        InvertRecursively(root.right);

        return root;
    }

    /// <summary>
    /// Merge two binary trees.
    /// </summary>
    /// <param name="root1"></param>
    /// <param name="root2"></param>
    /// <returns></returns>
    public static TreeNode? Merge(TreeNode? root1, TreeNode? root2)
    {
        if (root1 == null)
        {
            return root2;
        }

        if (root2 == null)
        {
            return root1;
        }

        root1.val += root2.val;
        root1.left = Merge(root1.left, root2.left);
        root1.right = Merge(root1.right, root2.right);

        return root1;
    }

    public static int GetHeight(TreeNode? root)
    {
        return root == null ? 0 : Math.Max(GetHeight(root.left) + 1, GetHeight(root.right) + 1);
    }

    /// <summary>
    /// Find all leaves of binary tree recursively.
    /// </summary>
    /// <param name="root">Root node</param>
    /// <param name="leaves"></param>
    public static List<TreeNode> FindLeafNodes(TreeNode? root, List<TreeNode> leaves)
    {
        if (root == null)
        {
            return leaves;
        }

        if (root.left == null && root.right == null)
        {
            leaves.Add(root);
        }

        FindLeafNodes(root.left, leaves);
        FindLeafNodes(root.right, leaves);

        return leaves;
    }
}