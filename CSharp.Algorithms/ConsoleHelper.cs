using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms;

public static class ConsoleHelper
{
    public static void PrintHeader(string separator, string? withTitle = null, bool surroundWithNewLines = true)
    {
        if (surroundWithNewLines)
        {
            System.Console.WriteLine();
        }

        if (withTitle == null)
        {
            System.Console.WriteLine(separator);
        }
        else
        {
            System.Console.WriteLine(separator);
            System.Console.WriteLine(withTitle);
            System.Console.WriteLine(separator);
        }


        if (surroundWithNewLines)
        {
            System.Console.WriteLine();
        }
    }

    public static void PrintMatrix(int[][] matrix)
    {
        System.Console.ForegroundColor = ConsoleColor.Green;
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                System.Console.Write(matrix[i][j]);
                System.Console.Write(' ');
            }

            System.Console.WriteLine('\n');
        }
        System.Console.ForegroundColor = ConsoleColor.White;
    }

    public static void Print<T>(IEnumerable<T> arr, string title = default, bool newLine = false)
    {
        if (!string.IsNullOrWhiteSpace(title))
        {
            System.Console.WriteLine(title);
        }

        if (newLine)
        {
            foreach (var item in arr)
            {
                System.Console.WriteLine(item);
            }
        }
        else
        {
            foreach (var item in arr)
            {
                System.Console.Write(item + " ");
            }

            System.Console.WriteLine();
        }
    }

    public static void Print(this TreeNode root)
    {
        System.Console.WriteLine(root.val);
    }

    public static void Print(this ListNode node)
    {
        while (node != null)
        {
            System.Console.Write($"{node.Val} ");
            node = node.Next;
        }

        System.Console.Write(Environment.NewLine);
    }

    public static void PrintLevelOrder(this TreeNode? root)
    {
        if (root == null)
        {
            System.Console.WriteLine("Tree is empty");
        }

        Queue<TreeNode> queue = new();
        TreeNode node;
        queue.Enqueue(root);
        var count = 0;

        while (queue.Count != 0)
        {
            count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                node = queue.Dequeue();

                System.Console.Write($"{node.val} ");

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            System.Console.Write(Environment.NewLine);
        }

        System.Console.Write(Environment.NewLine);
    }

}