using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.Problems.Topics.Tree;

public class BinarySearchTreeOperations
{
    /// <summary>
    /// Insert new node into binary search tree.
    /// </summary>
    /// <param name="root">Root node.</param>
    /// <param name="val">Value to be inserted.</param>
    /// <returns>Root node.</returns>
    public static TreeNode Insert(TreeNode? root, int val)
    {
        TreeNode newNode = new(val);

        if (root == null)
        {
            return newNode;
        }

        var (currentNode, previousNode) = (root, root);

        while (currentNode != null)
        {
            previousNode = currentNode;
            currentNode = currentNode.val > val ? currentNode.left : currentNode.right;
        }

        if (previousNode.val > val)
        {
            previousNode.left = newNode;
        }
        else
        {
            previousNode.right = newNode;
        }

        return root;
    }

    /// <summary>
    /// Remove node from binary search tree.
    /// </summary>
    /// <param name="root"></param>
    /// <param name="key"></param>
    /// <returns>Root node.</returns>
    public static TreeNode? Remove(TreeNode? root, int key)
    {
        if (root == null) return root;

        (var curr, TreeNode? prev) = (root, null);

        while (curr != null)
        {
            if (key == curr.val) break;

            if (key > curr.val)
            {
                (prev, curr) = (curr, curr.right);
            }
            else
            {
                (prev, curr) = (curr, curr.left);
            }
        }

        if (curr == null)
        {
            return root;
        }

        if (curr.left == null && curr.right == null)
        {
            if (prev == null) // root
            {
                root = null;
            }
            else if (prev.left == curr)
            {
                prev.left = null;
            }
            else
            {
                prev.right = null;
            }
        }
        else if (curr.left == null || curr.right == null)
        {
            if (prev == null) // root
            {
                root = curr.left ?? curr.right;
                (curr.left, curr.right) = (null, null);
            }
            else if (prev.left == curr)
            {
                prev.left = curr.left ?? curr.right;
            }
            else
            {
                prev.right = curr.left ?? curr.right;
            }
        }
        else
        {
            var (minNode, parentMinNode) = FindMinNode(curr.right);

            curr.val = minNode.val;

            if (parentMinNode == null) // min value node is first node in the right subtree
            {
                curr.right = minNode.right ?? null;
            }
            else // min value node is somewhere deeper in the right subtree
            {
                parentMinNode.left = minNode.right ?? null;
            }
        }

        return root;

        (TreeNode min, TreeNode? parent) FindMinNode(TreeNode node)
        {
            var temp = node;
            TreeNode? parent = null;

            while (temp.left != null)
            {
                parent = temp;
                temp = temp.left;
            }

            return (temp, parent);
        }
    }

    /// <summary>
    /// Remove node from binary search tree recursively.
    /// </summary>
    /// <param name="root"></param>
    /// <param name="key"></param>
    /// <returns>Root node.</returns>
    public static TreeNode? RemoveRecursively(TreeNode? root, int key)
    {
        if (root == null)
        {
            return root;
        }

        if (key > root.val)
        {
            root.right = RemoveRecursively(root.right, key);
        }
        else if (key < root.val)
        {
            root.left = RemoveRecursively(root.left, key);
        }
        else
        {
            if (root.left == null && root.right == null)
            {
                root = null;
            }
            else if (root.right != null)
            {
                root.val = GetSuccessor(root);
                root.right = RemoveRecursively(root.right, root.val);
            }
            else if (root.left != null)
            {
                root.val = GetPredecessor(root);
                root.left = RemoveRecursively(root.left, root.val);
            }
        }

        return root;

        int GetSuccessor(TreeNode node)
        {
            node = node.right;
            while (node != null && node.left != null)
            {
                node = node.left;
            }
            return node.val;
        }

        int GetPredecessor(TreeNode node)
        {
            node = node.left;
            while (node != null && node.right != null)
            {
                node = node.right;
            }
            return node.val;
        }
    }

    /// <summary>
    /// Search in a binary search tree iteratively.
    /// </summary>
    /// <param name="root"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    public static TreeNode? Search(TreeNode root, int val)
    {
        var currentNode = root;
        while (currentNode != null)
        {
            if (currentNode.val == val)
            {
                break;
            }

            currentNode = currentNode.val > val
                ? currentNode.left
                : currentNode.right;
        }

        return currentNode;
    }

    /// <summary>
    /// Search in a binary search tree recursively.
    /// </summary>
    /// <param name="root"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    public static TreeNode? SearchRecursively(TreeNode? root, int val)
    {
        if (root == null)
        {
            return null;
        }

        return root.val == val
            ? root
            : SearchRecursively(root.val > val ? root.left : root.right, val);
    }

    /// <summary>
    /// Check if a binary search tree valid.
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    /// https://leetcode.com/problems/validate-binary-search-tree
    public static bool IsValid(TreeNode? root)
    {
        return IsValidBinarySearchTree(root, null, null);

        static bool IsValidBinarySearchTree(TreeNode? node, int? min, int? max)
        {
            if (node == null)
                return true;

            // node value should be between min and max, otherwise BST is not valid
            if (node.val <= min || node.val >= max)
                return false;

            // check recursively left and right subtrees
            return IsValidBinarySearchTree(node.left, min, node.val) &&
                   IsValidBinarySearchTree(node.right, node.val, max);
        }
    }
}