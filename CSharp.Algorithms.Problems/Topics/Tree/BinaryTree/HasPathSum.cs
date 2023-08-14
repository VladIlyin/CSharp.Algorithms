using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.Problems.Topics.Tree.BinaryTree;

public partial class BinaryTreeProblem
{
    /// <summary>
    /// Returns true if the tree has a root-to-leaf path such that
    /// adding up all the values along the path equals targetSum.
    /// </summary>
    /// <param name="root"></param>
    /// <param name="targetSum"></param>
    /// <returns></returns>
    /// https://leetcode.com/problems/path-sum/
    public static bool HasPathSum(TreeNode? root, int targetSum)
    {
        if (root == null)
        {
            return false;
        }

        if (root.left == null &&
            root.right == null &&
            root.val == targetSum)
        {
            return true;
        }

        return HasPathSum(root.left, targetSum - root.val) ||
               HasPathSum(root.right, targetSum - root.val);
    }
}