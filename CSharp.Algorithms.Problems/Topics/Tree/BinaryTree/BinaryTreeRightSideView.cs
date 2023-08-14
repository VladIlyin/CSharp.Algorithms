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
        public static IList<int> RightSideView(TreeNode? root)
        {
            List<int> list = new();

            Dfs(root, 0);
            return list;

            void Dfs(TreeNode root, int level)
            {
                if (root == null)
                {
                    return;
                }

                if (list.Count == level)
                {
                    list.Add(root.val);
                }

                Dfs(root.right, level + 1);
                Dfs(root.left, level + 1);
            }
        }

        public static IList<int> RightSideViewIterativeBFS(TreeNode? root)
        {
            var res = new List<int>();
            if (root == null)
            {
                return res;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var i = 0;
                var level = queue.Count;
                var last = 0;

                while (i < level)
                {
                    var node = queue.Dequeue();
                    last = node.val;

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }

                    i++;
                }

                res.Add(last);
            }

            return res;
        }
    }
}
