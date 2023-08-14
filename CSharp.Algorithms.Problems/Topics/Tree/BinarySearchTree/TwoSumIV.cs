using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.Problems.Topics.Tree.BinarySearchTree;

public partial class BinarySearchTreeProblem
{
    private static readonly HashSet<int> set = new();

    /// <summary>
    /// Returns true if there exist two elements in the BST such that
    /// their sum is equal to k, or false otherwise
    /// </summary>
    /// <param name="root"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static bool FindTarget(TreeNode? root, int k)
    {
        if (root == null)
        {
            return false;
        }

        if (set.Contains(root.val))
        {
            return true;
        }

        set.Add(k - root.val);

        return FindTarget(root.left, k)
               || FindTarget(root.right, k);
    }
}