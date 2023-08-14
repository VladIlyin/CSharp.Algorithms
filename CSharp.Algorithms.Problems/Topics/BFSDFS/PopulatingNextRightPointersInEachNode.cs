namespace CSharp.Algorithms.Problems.Topics.BFSDFS;

//https://leetcode.com/problems/populating-next-right-pointers-in-each-node/
public partial class BFSDFS
{
    public class Node
    {
        public int val;

        public Node left;

        public Node right;

        public Node next;

        public Node(
            int val,
            Node left,
            Node right,
            Node next)
        {
            this.val = val;
            this.left = left;
            this.right = right;
            this.next = next;
        }
    }

    public static Node Connect(Node root)
    {
        if (root == null) return null;

        var queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            Node prev = null;

            foreach (var _ in Enumerable.Range(0, queue.Count))
            {
                var curr = queue.Dequeue();

                if (prev != null)
                {
                    prev.next = curr;
                }

                prev = curr;

                if (curr.left != null) queue.Enqueue(curr.left);

                if (curr.right != null) queue.Enqueue(curr.right);
            }
        }

        return root;
    }
}