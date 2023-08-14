using CSharp.Algorithms.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Algorithms.Problems.Topics.Tree.BinaryTree
{
    public partial class BinaryTreeProblem
    {
        public static bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            var leaves1 = new List<int>();
            var leaves2 = new List<int>();

            FindLeafNodes(root1, leaves1);
            FindLeafNodes(root2, leaves2);

            if (leaves1.Count != leaves2.Count)
            {
                return false;
            }

            if (leaves1.Where((t, i) => t != leaves2[i]).Any())
            {
                return false;
            }

            return true;

            void FindLeafNodes(TreeNode? root, ICollection<int> leaves)
            {
                if (root == null)
                    return;

                if (root.left == null &&
                    root.right == null)
                {
                    leaves.Add(root.val);
                    return;
                }

                if (root.left != null)
                    FindLeafNodes(root.left, leaves);

                if (root.right != null)
                    FindLeafNodes(root.right, leaves);
            }
        }
    }
}
