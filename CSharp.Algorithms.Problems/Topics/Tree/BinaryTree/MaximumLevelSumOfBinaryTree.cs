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
        public static int MaxLevelSum(TreeNode? root)
        {
            var max = int.MinValue;
            var maxLevelSum = 1;

            if (root == null)
            {
                return max;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            var levelNum = 0;

            while (queue.Count > 0)
            {
                var i = 0;
                var level = queue.Count;

                var levelSum = 0;
                levelNum++;

                while (i < level)
                {
                    var node = queue.Dequeue();
                    levelSum += node.val;

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

                if (levelSum > max)
                {
                    max = levelSum;
                    maxLevelSum = levelNum;
                }
            }

            return maxLevelSum;
        }
    }
}
