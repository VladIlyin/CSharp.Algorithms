namespace CSharp.Algorithms.Core.Models;

public class GraphNode
{
    public int Value;
    public IList<GraphNode>? Neighbors;

    public GraphNode()
    {
        Value = 0;
        Neighbors = new List<GraphNode>();
    }

    public GraphNode(int val)
    {
        Value = val;
        Neighbors = new List<GraphNode>();
    }

    public GraphNode(int val, List<GraphNode> neighbors)
    {
        Value = val;
        Neighbors = neighbors;
    }
}