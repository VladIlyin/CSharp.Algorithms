using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.Problems.Topics.Tree.BinaryTree
{
    public partial class BinaryTreeProblem
    {
        public static int GoodNodes(TreeNode root)
        {
            var stack = new Stack<(TreeNode, int)>();
            var goodNodesCount = 0;

            stack.Push((root, root.val));

            while (stack.Any())
            {
                var (node, currentValue) = stack.Pop();

                if (node.left != null)
                {
                    if (node.left.val >= currentValue)
                    {
                        goodNodesCount++;
                        stack.Push((node.left, node.left.val));
                    }
                    else
                    {
                        stack.Push((node.left, currentValue));
                    }
                }

                if (node.right != null)
                {
                    if (node.right.val >= currentValue)
                    {
                        goodNodesCount++;
                        stack.Push((node.right, node.right.val));
                    }
                    else
                    {
                        stack.Push((node.right, currentValue));
                    }
                }
            }

            return goodNodesCount + 1;
        }
    }
}
