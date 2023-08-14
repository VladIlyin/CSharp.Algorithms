namespace CSharp.Algorithms.Core.Models;

public class TreeNode
{
    public int val;

    public TreeNode? left;

    public TreeNode? right;

    public TreeNode(
        int val = 0,
        TreeNode? left = null,
        TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public override string ToString()
    {
        var nodeString = string.Empty;
        if (left is not null)
        {
            nodeString += $"{left.val}<-";
        }

        nodeString += val.ToString();

        if (right is not null)
        {
            nodeString += $"->{right.val}";
        }

        return nodeString;
    }

    public TreeNode this[int index] => Traverse().ElementAt(index);

    public static TreeNode? CreateTree(int?[] arr)
    {
        if (arr.Length == 0 || arr[0] == null)
        {
            return null;
        }

        Queue<TreeNode> queue = new();
        var idx = 0;
            
        var root = new TreeNode(arr[idx]!.Value);
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (2 * idx + 1 < arr.Length 
                && arr[2 * idx + 1] is not null)
            {
                node.left = new TreeNode(arr[2 * idx + 1]!.Value);
                queue.Enqueue(node.left);
            }

            if (2 * idx + 2 < arr.Length
                && arr[2 * idx + 2] is not null)
            {
                node.right = new TreeNode(arr[2 * idx + 2]!.Value);
                queue.Enqueue(node.right);
            }

            idx++;
        }

        return root;
    }

    /// <summary>
    /// Traverse binary tree in level order.
    /// </summary>
    /// <returns><see cref="IEnumerable<TreeNode>"/></returns>
    public IEnumerable<TreeNode?> Traverse()
    {
        Queue<TreeNode?> queueTreeNodes = new();
        queueTreeNodes.Enqueue(this);

        while (queueTreeNodes.Any(x => x is not null))
        {
            var currentTreeNode = queueTreeNodes.Dequeue();

            yield return currentTreeNode;

            if (currentTreeNode == null) continue;

            queueTreeNodes.Enqueue(currentTreeNode.left);
            queueTreeNodes.Enqueue(currentTreeNode.right);
        }
    }

    public IEnumerable<int?> ToValues()
    {
        return Traverse().Select(node => node?.val).ToArray();
    }
}