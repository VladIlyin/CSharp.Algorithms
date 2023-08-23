namespace CSharp.Algorithms.Core.Models
{
    public class AvlTreeNode
    {
        public int val;

        public AvlTreeNode? left;

        public AvlTreeNode? right;

        public int height;

        public AvlTreeNode(
            int val,
            AvlTreeNode? left = null,
            AvlTreeNode? right = null,
            byte height = 1)
        {
            this.val = val;
            this.left = left;
            this.right = right;
            this.height = height;
        }

        public AvlTreeNode Balance()
        {
            this.FixHeight();

            if (this.BFactor() == 2)
            {
                if (this.right.BFactor() < 0)
                {
                    this.right = this.right.RotateRight();
                }

                return this.RotateLeft();
            }

            if (this.BFactor() == -2)
            {
                if (this.left.BFactor() > 0)
                {
                    this.left = this.left.RotateLeft();
                }

                return this.RotateRight();
            }

            return this;
        }

        public IEnumerable<AvlTreeNode?> Traverse()
        {
            Queue<AvlTreeNode?> queueTreeNodes = new();
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

        public static AvlTreeNode Insert(AvlTreeNode? root, int value)
        {
            if (root == null)
            {
                return new AvlTreeNode(value);
            }

            if (value < root.val)
                root.left = Insert(root.left, value);
            else
                root.right = Insert(root.right, value);

            return root.Balance();
        }

        static AvlTreeNode FindMin(AvlTreeNode p)
        {
            return p.left != null ? FindMin(p.left) : p;
        }

        static AvlTreeNode? RemoveMin(AvlTreeNode p)
        {
            if (p.left == null)
            {
                return p.right;
            }

            p.left = RemoveMin(p.left);

            return p.Balance();
        }

        public static AvlTreeNode? Remove(AvlTreeNode? p, int k)
        {
            if (p == null)
            {
                return null;
            }

            if (k < p.val)
            {
                p.left = Remove(p.left, k);
            }
            else if (k > p.val)
            {
                p.right = Remove(p.right, k);
            }
            else
            {
                var left = p.left;
                var right = p.right;

                if (right == null)
                {
                    return left;
                }

                var min = FindMin(right);

                min.right = RemoveMin(right);
                min.left = left;

                return min.Balance();
            }

            return p.Balance();
        }
    }

    public static class AvlTreeNodeExtension
    {
        public static AvlTreeNode ToAvlTree(this int[] arr)
        {
            var node = new AvlTreeNode(arr[0]);

            for (var i = 1; i < arr.Length; i++)
            {
                node = AvlTreeNode
                    .Insert(node, arr[i]);
            }

            return node;
        }

        public static int GetHeight(this AvlTreeNode? node)
        {
            return node?.height ?? 0;
        }

        public static int BFactor(this AvlTreeNode? node)
        {
            return (node?.right.GetHeight() - node?.left.GetHeight()) ?? 0;
        }        
        
        public static void FixHeight(this AvlTreeNode? node)
        {
            var (hLeft, hRight) = (node?.left.GetHeight() ?? 0, node?.right.GetHeight() ?? 0);
            node.height = (hLeft > hRight ? hLeft : hRight) + 1;
        }

        public static AvlTreeNode RotateRight(this AvlTreeNode node)
        {
            var r = node.left;
            node.left = r.right;
            r.right = node;
            node.FixHeight();
            r.FixHeight();
            return r;
        }

        public static AvlTreeNode RotateLeft(this AvlTreeNode node)
        {
            var r = node.right;
            node.right = r.left;
            r.left = node;
            node.FixHeight();
            r.FixHeight();
            return r;
        }
    }
}
