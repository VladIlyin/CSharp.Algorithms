using CSharp.Algorithms.Core.Models;

namespace CSharp.Algorithms.Problems.DataStructures.Graph;

public partial class GraphProblem
{
    /// <summary>
    /// Breadth-first graph traversal.
    /// </summary>
    /// <returns></returns>
    public static GraphNode? BreadthFirstSearch(GraphNode? root, int val)
    {
        if (root == null) return null;

        Queue<GraphNode> queueTreeNodes = new();
        queueTreeNodes.Enqueue(root);


        while (queueTreeNodes.Count > 0)
        {
            var currentTreeNode = queueTreeNodes.Dequeue();

            if (currentTreeNode.Value == val)
            {
                return currentTreeNode;
            }

            if (currentTreeNode.Neighbors == null) continue;

            foreach (var node in currentTreeNode.Neighbors)
            {
                queueTreeNodes.Enqueue(node);
            }
        }

        return null;
    }
}