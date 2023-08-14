using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.Problems.Topics.Tree.BinarySearchTree;

public partial class BinarySearchTreeProblem
{
    /*
     * The lowest common ancestor is defined between two nodes p and q
     * as the lowest node in T that has both p and q as descendants
     * (where we allow a node to be a descendant of itself).
     */

    /// <summary>
    /// Find the lowest common ancestor.
    /// </summary>
    /// <param name="root"></param>
    /// <param name="p"></param>
    /// <param name="q"></param>
    /// <returns></returns>
    /// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
    public static TreeNode? LowestCommonAncestor(TreeNode? root, TreeNode p, TreeNode q)
    {
        if (root == null)
        {
            return null;
        }

        if (root.val >= p.val && root.val <= q.val ||
            root.val <= p.val && root.val >= q.val)
        {
            return root;
        }

        return LowestCommonAncestor(root.val >= p.val ? root.left : root.right, p, q);
    }
}