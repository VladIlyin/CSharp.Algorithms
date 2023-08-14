using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.Problems.Topics.Tree.BinaryTree
{
    public partial class BinaryTreeProblem
    {
        public static TreeNode? LowestCommonAncestor(TreeNode? root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return null;
            }

            if (root == p || root == q)
            {
                return root;
            }

            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);

            if (left != null && right != null)
            {
                return root;
            }

            return left ?? right;
        }
    }
}
