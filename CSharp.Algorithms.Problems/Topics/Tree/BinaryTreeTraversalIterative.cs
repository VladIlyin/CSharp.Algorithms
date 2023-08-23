using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.Problems.Topics.Tree;

//https://leetcode.com/problems/binary-tree-inorder-traversal/submissions/
public class BinaryTreeTraversalIterative
{
    /// <summary>
    /// Pre-order traversal.
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    //https://leetcode.com/problems/binary-tree-preorder-traversal/
    public static IEnumerable<TreeNode> PreOrder(TreeNode root)
    {
        if (root != null)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var currNode = root;

            while (stack.Count > 0 || currNode != null)
            {
                if (currNode != null)
                {
                    stack.Push(currNode);
                    yield return currNode;

                    currNode = currNode.left;
                    continue;
                }
                else
                {
                    currNode = stack.Pop()?.right;
                }
            }
        }
    }

    /// <summary>
    /// In-order traversal.
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static IEnumerable<TreeNode> InOrder(TreeNode root)
    {
        if (root != null)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var currNode = root;

            while (stack.Count > 0 || currNode != null)
            {
                if (currNode != null)
                {
                    stack.Push(currNode);
                    currNode = currNode.left;
                    continue;
                }
                else
                {
                    currNode = stack.Pop();
                    yield return currNode;
                    currNode = currNode.right;
                }
            }
        }
    }

    /// <summary>
    /// Post-order traversal.
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public static IEnumerable<TreeNode> PostOrder(TreeNode? root)
    {
        Stack<TreeNode> stack = new();
        var currentNode = root;

        while (stack.Count > 0 || currentNode != null)
        {
            if (currentNode == null)
            {
                currentNode = stack.Pop();

                if (stack.Count > 0 && stack.Peek() == currentNode)
                    currentNode = currentNode.right;
                else
                {
                    yield return currentNode;
                    currentNode = null;
                }
            }
            else
            {
                stack.Push(currentNode);
                stack.Push(currentNode);
                currentNode = currentNode.left;
            }
        }
    }

    public static IEnumerable<int?> LevelOrderTraversal(TreeNode? root)
    {
        if (root == null)
        {
            yield break;
        }

        Queue<TreeNode?> queueTreeNodes = new();
        queueTreeNodes.Enqueue(root);

        while (queueTreeNodes.Any(x => x is not null))
        {
            var currentTreeNode = queueTreeNodes.Dequeue();

            yield return currentTreeNode?.val;

            if (currentTreeNode == null) continue;

            queueTreeNodes.Enqueue(currentTreeNode.left);
            queueTreeNodes.Enqueue(currentTreeNode.right);
        }
    }
}