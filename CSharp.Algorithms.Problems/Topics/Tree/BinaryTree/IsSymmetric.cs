using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.Problems.Topics.Tree.BinaryTree
{
    public partial class BinaryTreeProblem
    {
        /// <summary>
        /// Check whether a binary tree is a mirror of itself (i.e., symmetric around its center)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsSymmetric(TreeNode? root)
        {
            return root == null || IsMirror(root.left, root.right);

            static bool IsMirror(TreeNode? left, TreeNode? right)
            {
                if (left == null && right == null)
                {
                    return true;
                }

                if (left == null || right == null || left.val != right.val)
                {
                    return false;
                }

                return IsMirror(left.left, right.right) && IsMirror(left.right, right.left);
            }
        }
    }
}